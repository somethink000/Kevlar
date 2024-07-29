

using Microsoft.VisualBasic;
using Sandbox;

namespace GeneralGame;


public class LootItem : BaseInventory
{

	[Property] public List<PrefabFile> StartItems;
	public int SelectedItem { get; set; } = 0;



	protected override void OnStart()
	{
		foreach ( PrefabFile item in StartItems)
		{
			GiveItem( item );
		}
		//SelectedItem = !(!GameObject.Components.TryGet<ItemComponent>() && !null);

		// Pickup
		var interactions = Components.GetOrCreate<Interactions>();
		interactions.AddInteraction( new Interaction()
		{
			Action = ( PlayerBase interactor, GameObject obj ) => TakeItem( interactor, SelectedItem  ),
			Keybind = "Use",
			Description = "Take",
			Disabled = () => !PlayerBase.GetLocal().Inventory.HasSpaceInBackpack(),
			ShowWhenDisabled = () => true,
			Accessibility = AccessibleFrom.World
		} );
		interactions.AddInteraction( new Interaction()
		{
			Action = ( PlayerBase interactor, GameObject obj ) => OpenLoot( interactor ),
			Keybind = "Reload",
			Description = "Open",
			ShowWhenDisabled = ( ) => true,
			Accessibility = AccessibleFrom.World
		} );
	}

	public void OpenLoot( PlayerBase ply )
	{

		//ply.Inventory.targetStorage = this;
		//UI.FullScreenManager.Instance.Display( UI.FullScreenManager.FullScreenPanel.Inventory );
	
	}


	public void TakeItem( PlayerBase ply, int item )
	{
		ply.Inventory.GiveItem( _backpackItems[ item ] );
		RemoveBackpackItem( item );
	}


	public void NextItem( int value)
	{
		int clamp = Math.Clamp( value, 0, MAX_SLOTS - 1 );
		SelectedItem = clamp;
		
		
	}

}
