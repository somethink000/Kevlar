
using System.Linq;

namespace GeneralGame;

internal class DemoCommands
{

	[ConCmd( "respawn", Help = "Respawns the player (host only)" )]
	public static void Respawn()
	{
		var player = PlayerBase.GetLocal();
		if ( !player.Network.OwnerConnection.IsHost ) return;
		player?.Respawn();
	}

	[ConCmd( "god", Help = "Toggles godmode (host only)" )]
	public static void GodMode()
	{
		var player = PlayerBase.GetLocal();
		if ( !player.Network.OwnerConnection.IsHost ) return;
		player.GodMode = !player.GodMode;
		Log.Info( (player.GodMode ? "Enabled" : "Disabled") + " Godmode" );
	}

	
}
