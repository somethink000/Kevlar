

namespace GeneralGame;

public class LobbyGame : BaseGame
{

	/*public override int TimerValue => UntilNextVave.Relative.CeilToInt();
	public override int CountValue => CurVave;
	public override int SecondCountValue => ZombieLeft;*/


	public override void OnPlayerDeath( PlayerBase player, PlayerBase killer )
	{
		player.RespawnWithDelay( 5 );

	}

	[Broadcast]
	public override void ChangeGame()
	{
		if (!IsProxy)
		{
			PlayerBase.Save();
		}
		
	}

	public override void InitPlayer( PlayerBase player )
	{
		base.InitPlayer( player );

	}


}
