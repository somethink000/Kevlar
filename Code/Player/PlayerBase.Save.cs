namespace GeneralGame;

public struct ItemSave
{
	[JsonInclude] public string Path;
	[JsonInclude] public Dictionary<string, string> Data;
	[JsonInclude] public int Index;
}

public struct PlayerSave
{
	public const string FILE_PATH = "kevlar.json";

	[JsonInclude] public int Experience;
	[JsonInclude] public int Level;
	[JsonInclude] public bool DropInvent;

	[JsonInclude] public ItemSave[] Equiped;
	[JsonInclude] public ItemSave[] Inventory;
	[JsonInclude] public ItemSave[] Storage;

}

[AttributeUsage( AttributeTargets.Property )]
public class TargetSaveAttribute : Attribute
{
	public object IgnoreIf { get; set; }
}

partial class PlayerBase
{
	private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
	{
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
	};

	private static PlayerSave? _saveData;

	/// <summary>
	/// Gets current local save data.
	/// </summary>
	/// <returns></returns>
	public static (PlayerSave Save, bool Has) GetSave()
	{
		if ( _saveData.HasValue )
			return (_saveData.Value, true);

		if ( !FileSystem.OrganizationData.FileExists( PlayerSave.FILE_PATH ) )
			return (default, false);

		_saveData = FileSystem.OrganizationData.ReadJson<PlayerSave>( PlayerSave.FILE_PATH );

		return (_saveData.Value, true);
	}

	/// <summary>
	/// Writes a pure PlayerSave struct into a local save.
	/// </summary>
	/// <param name="save"></param>
	public static void WriteSave( PlayerSave save )
		=> FileSystem.OrganizationData.WriteJson( PlayerSave.FILE_PATH, save );

	/// <summary>
	/// Writes a local save based on player or local.
	/// </summary>
	/// <param name="player"></param>
	public static void Save( PlayerBase player = null )
	{
		player ??= GetLocal();

		// Get the data that sticks.
		var data = GetSave();
		var save = data.Has
			? data.Save
			: new PlayerSave()
			{

			};

		var items = PrefabLibrary.FindByComponent<ItemComponent>();

		// Save dynamic data.
		ItemSave Serialize( ItemComponent item )
		{
			if ( item == null )
				return default;

			if ( !ResourceLibrary.TryGet<PrefabFile>( item.Prefab, out var resource ) )
				return default;

			var data = new Dictionary<string, string>();
			foreach ( var component in item.Components.GetAll() )
			{
				var properties = GlobalGameNamespace.TypeLibrary
					?.GetType( component.GetType() )
					?.Properties
					?.Where( property =>
					{
						var attribute = property.GetCustomAttribute<TargetSaveAttribute>();
						if ( attribute == null ) return false;

						var ignore = attribute?.IgnoreIf?.Equals( property.GetValue( component ) ) ?? false;
						return !ignore;
					} );

				foreach ( var property in properties )
				{
					var serialized = JsonSerializer.Serialize( property.GetValue( component ), property.PropertyType, options );
					if ( data.ContainsKey( property.Name ) )
						data[property.Name] = serialized;
					else
						data.Add( property.Name, serialized );
				}
			}

			return new ItemSave
			{
				Path = item.Prefab,
				Data = data.Count > 0 ? data : null,
				Index = player.Inventory.IndexOf( item )
			};
		}
		//DropInvent =

		_saveData = save with
		{
			Experience = player.Experience,
			Level = player.Level,
			DropInvent = player.DropInvent,
			Equiped = player.Inventory.EquippedItems
				.Where( x => x != null )
				.Select( Serialize )
				.ToArray(),
			Inventory = player.Inventory.BackpackItems
				.Where( x => x != null )
				.Select( Serialize )
				.ToArray(),
		};

		// Write save.
		WriteSave( _saveData.Value );
	}


	/// <summary>
	/// Sets up everything for a player or local from local save.
	/// </summary>
	/// <param name="player"></param>
	/// <returns></returns>
	public static bool Setup( PlayerBase player = null )
	{
		player ??= Local;

		var tuple = GetSave();
		if ( !tuple.Has )
		{
			WriteSave(
				new()
				{

				}
			);
			return false;
		}


		// Setup basic player information.
		var save = tuple.Save;

		player.Experience = save.Experience;
		player.Level = save.Level;

		void ReadData( ItemSave data, GameObject obj )
		{
			var components = obj.Components.GetAll();
			foreach ( var component in components )
			{
				var properties = GlobalGameNamespace.TypeLibrary
					?.GetType( component.GetType() )
					?.Properties
					?.Where( x => x.HasAttribute<TargetSaveAttribute>() );

				foreach ( var property in properties )
				{
					if ( data.Data == null || !data.Data.TryGetValue( property.Name, out var serialized ) )
						continue;

					var deserialized = JsonSerializer.Deserialize( serialized, property.PropertyType, options );
					property.SetValue( component, deserialized );
				}
			}
		}

		// Go through all clothes.
		if ( save.Equiped != null && !save.DropInvent )
			foreach ( var data in save.Equiped )
			{
				if ( !ResourceLibrary.TryGet<PrefabFile>( data.Path, out var prefab ) )
					continue;

				var o = SceneUtility.GetPrefabScene( prefab ).Clone();
				o.NetworkMode = NetworkMode.Object;
				if ( !o.Network.Active ) o.NetworkSpawn();
				var equipment = o.Components.Get<ItemEquipment>();
				if ( equipment == null )
					continue;

				player.Inventory.EquipItemFromWorld( equipment );
				ReadData( data, o );
			}

		// Go through all items.
		if ( save.Inventory != null && !save.DropInvent )

			foreach ( var data in save.Inventory )
			{

				if ( !ResourceLibrary.TryGet<PrefabFile>( data.Path, out var prefab ) )
					continue;

				var o = SceneUtility.GetPrefabScene( prefab ).Clone();
				o.NetworkMode = NetworkMode.Object;
				if ( !o.Network.Active ) o.NetworkSpawn();
				var item = o.Components.Get<ItemComponent>();
				if ( item == null )
					continue;

				player.Inventory.SetItem( item, data.Index );
				ReadData( data, o );
			}


		player.DropInvent = !(player.CurrentGame is LobbyGame);

		return true;
	}
}
