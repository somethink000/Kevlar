

using Sandbox;

namespace GeneralGame;

[Title( "Deathmatch" ), Description( "Kill your friends and have fun" ), Icon( "ui/gamemodes/deathmatch.jpg" )]
public class DeathmatchGame : BaseGame
{
	[Property] public float MatchTime { get; set; } = 50f;
	private TimeUntil UntilMatchEnd { get; set; }
	public override int CountValue => UntilMatchEnd.Relative.CeilToInt();

	protected override void OnAwake()
	{
		base.OnAwake();
		UntilMatchEnd = MatchTime;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();

		if ( UntilMatchEnd <= 0 )
		{
			GameManager.ActiveScene.LoadFromFile( "scenes/basement.scene" );
		}

	}
	/*public override void InitPlayer( PlayerBase player )
	{
		base.InitPlayer( player );


	}*/
	public override void OnPlayerDeath( PlayerBase player, PlayerBase killer )
	{
		player.RespawnWithDelay( 5 );
		killer.Kills++;
	}


}
