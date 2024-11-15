
using GeneralGame.UI;


namespace GeneralGame;

public class EquipmentTable : BaseInventory
{

	public override int MAX_SLOTS { get; set; } = 50;
	public void OnUse( PlayerBase ply )
	{
		if ( IsProxy ) return;
		var screenPanel = ply.RootDisplay;
		Panel equipmentPanel = new EquipmentPanel( this );

		FullScreenManager.Instance.SetOutsider( equipmentPanel );
	}


	protected override void OnStart()
	{
		var interactions = Components.GetOrCreate<Interactions>();
		interactions.AddInteraction( new Interaction()
		{
			Action = ( PlayerBase interactor, GameObject obj ) => OnUse( interactor ),
			Keybind = "use",
			Description = "Manage equipment",
			Disabled = () => false,
			ShowWhenDisabled = () => true,
			Accessibility = AccessibleFrom.World,
		} );
	}
}

