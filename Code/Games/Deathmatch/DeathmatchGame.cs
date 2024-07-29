

namespace GeneralGame;

[Title( "Deathmatch" ), Description( "Kill your friends and have fun" ), Icon( "ui/gamemodes/deathmatch.jpg" )]
public class DeathmatchGame : BaseGame
{

	/*public override int TimerValue => UntilNextVave.Relative.CeilToInt();
	public override int CountValue => CurVave;
	public override int SecondCountValue => ZombieLeft;*/


	protected override void OnAwake()
	{
		base.OnAwake();

	}

	public override void InitPlayer( PlayerBase player )
	{
		base.InitPlayer( player );


	}


}
