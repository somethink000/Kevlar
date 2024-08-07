

using Sandbox;
using System.Runtime.InteropServices;

namespace GeneralGame;

[Title( "Zombie Survival" ),  Description( "Survive" ), Icon( "ui/gamemodes/z_survival.jpg" )]
public class ZombieSurvivalGame : BaseGame
{
	[Property] List<int> Vaves;
	[Property] public float ZombieSpawnDelay = 2f;
	[Property] public float VaveStartColdown = 40f;
	[Property] public GameObject DefendObject;


	public int ZombieLeft { get; set; } = 0;
	private int ZombieSpawned { get; set; } = 0;
	private int CurVave { get; set; } = 0;
	private TimeUntil UntilNextVave { get; set; }
	private TimeSince SinceZombieSpawn { get; set; }
	private IEnumerable<ZombieSpawner> ZombieSpawners { get; set; }


	public override int TimerValue => UntilNextVave.Relative.CeilToInt();
	public override int CountValue => CurVave;
	public override int SecondCountValue => ZombieLeft;
	

	protected override void OnAwake()
	{
		base.OnAwake();
		UntilNextVave = VaveStartColdown;
		SinceZombieSpawn = 0;
		ZombieSpawners = Scene.GetAllComponents<ZombieSpawner>();

	

		RespawnWithDelay( 5 );
	}

	public async void RespawnWithDelay( float delay )
	{
		await GameTask.DelaySeconds( delay );
		DefendObject = Scene.GetAllComponents<PlayerBase>().First().GameObject;
	}

	public override void OnPlayerDeath( PlayerBase player, PlayerBase killer )
	{
		if  (Scene.GetAllComponents<PlayerBase>().Where( x => x.IsAlive).Count() <= 0)
		{
			GameManager.ActiveScene.LoadFromFile( "scenes/basement.scene" );
		}

		player.RespawnWithDelay( 5 );
	}


	public override void OnZombieKilled( PlayerBase ply )
	{
		ZombieLeft--;
		ply.Kills++;
		if (ZombieLeft <= 0 )
		{
			VaveEnd();
			UntilNextVave = VaveStartColdown;
		}

	}

	public void VaveStart()
	{
		ZombieSpawned = 0;
		ZombieLeft = Vaves[CurVave];
		Notificate( "New wave begin, try to stay alive!" );
		CurVave++;
	}

	public void VaveEnd()
	{
		var plys = Scene.GetAllComponents<PlayerBase>().Where( x => !x.IsAlive );

		foreach ( var ply in plys )
		{
			ply.Respawn();
		}

		if( CurVave >= Vaves.Count   )
		{
			GameManager.ActiveScene.LoadFromFile( "scenes/basement.scene" );
		}
	}

	public override void InitPlayer( PlayerBase player )
	{
		base.InitPlayer( player );


		if ( !Game.ActiveScene.IsValid() || IsProxy )
			return;


		var lights = Game.ActiveScene.GetAllComponents<Light>();
			
		foreach ( var light in lights )
		{
			light.Shadows = false;
		}

	}

	protected override void OnUpdate() 
	{
		

		base.OnUpdate();

		if ( ZombieLeft <= 0 && UntilNextVave <= 0 ) VaveStart();
		
		
		if ( ZombieLeft > 0 && SinceZombieSpawn > ZombieSpawnDelay && ZombieSpawned < Vaves[CurVave-1] )
		{
		
			ZombieSpawners.Shuffle()[0].NewZombie( DefendObject );
			ZombieSpawned++;
			SinceZombieSpawn = 0;
		}
	}

}
