
namespace GeneralGame;

[GameResource( "Maps", "map", "A map definition." )]
public partial class MapDefinition : GameResource
{
	[Property] public string Title { get; set; }
	[Property] public string Gamemode { get; set; }
	[Property] public SceneFile SceneFile { get; set; }
	[Property, ImageAssetPath] public string Background { get; set; }
}


public static class MapSystem
{
	public static IEnumerable<MapDefinition> All
	{
		get
		{
			return ResourceLibrary.GetAll<MapDefinition>();
		}
	}

	public static IEnumerable<MapDefinition> ByGame(string gamemode)
	{
		
		return ResourceLibrary.GetAll<MapDefinition>().Where( x => x.Gamemode == gamemode );
		
	}
}
