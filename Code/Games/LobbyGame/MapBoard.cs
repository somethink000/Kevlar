
using GeneralGame.UI;
using Sandbox.UI;

namespace GeneralGame;

public class MapBoard : Component
{


	public void OnUse( PlayerBase ply )
	{
		if ( IsProxy ) return;
		var screenPanel = ply.RootDisplay;
		Panel lobbyPanel = new LobbyPanel();

		FullScreenManager.Instance.SetOutsider( lobbyPanel );
	}


	protected override void OnStart()
	{
		var interactions = Components.GetOrCreate<Interactions>();
		interactions.AddInteraction( new Interaction()
		{
			Action = ( PlayerBase interactor, GameObject obj ) => OnUse( interactor ),
			Keybind = "use",
			Description = "Select Game",
			Disabled = () => false,
			ShowWhenDisabled = () => true,
			Accessibility = AccessibleFrom.World,
		} );
	}
}

