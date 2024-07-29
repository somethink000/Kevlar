
using System;
using System.Linq;

namespace GeneralGame;


public partial class PlayerBase : Component, Component.INetworkSpawn, IPlayerBase, IHealthComponent
{
	[Property] public GameObject Head { get; set; }
	[Property] public GameObject Body { get; set; }
	[Property] public SkinnedModelRenderer BodyRenderer { get; set; }
	[Property] public CameraComponent Camera { get; set; }
	[Property] public PanelComponent RootDisplay { get; set; }
    [Property] public Inventory Inventory { get; set; }
	[Property] public Vehicle Vehicle { get; set; }


	public int MaxCarryWeight { get; set; }
	public bool IsEncumbered => Inventory.Weight > MaxCarryWeight;

	public BaseGame CurrentGame { get; set; }
	Guid IPlayerBase.Id { get => GameObject.Id; }


	protected override void OnAwake()
	{
		CurrentGame = Scene.GetAllComponents<BaseGame>().First();
		CurrentGame.InitPlayer( this );

		OnCameraAwake();
		OnMovementAwake();
	}

	public void OnNetworkSpawn( Connection connection )
	{
		ApplyClothes( connection );
	}

	protected override void OnStart()
	{


		if ( IsProxy )
		{
			if ( Camera is not null )
				Camera.Enabled = false;
		}

		if ( !IsProxy )
		{
			Respawn();
		}


		base.OnStart();
	}

	public void Respawn()
	{
		if ( IsProxy )
			return;


		MaxCarryWeight = Inventory.MAX_WEIGHT_IN_GRAMS;

		Unragdoll();
		Health = MaxHealth;

		MoveToSpawnPoint();
		
	}

	private void MoveToSpawnPoint()
	{
		if ( IsProxy )
			return;
		
		var spawnpoints = Scene.GetAllComponents<SpawnPoint>();
		var randomSpawnpoint = Game.Random.FromList( spawnpoints.ToList() );
		Network.ClearInterpolation();
		Transform.Position = randomSpawnpoint.Transform.Position;
		Transform.Rotation = Rotation.FromYaw( randomSpawnpoint.Transform.Rotation.Yaw() );
		
		EyeAngles = Transform.Rotation;
	}

	

	[Broadcast]
	public virtual void OnDeath( Vector3 force, Vector3 origin )
	{
		

		if ( IsProxy ) return;

		Deaths += 1;
		CharacterController.Velocity = 0;
		Ragdoll( force, origin );
		RespawnWithDelay( 5 );


	}

	public async void RespawnWithDelay( float delay )
	{
		await GameTask.DelaySeconds( delay );
		GameManager.ActiveScene.LoadFromFile( "scenes/basement.scene" );
	}


	protected override void OnUpdate()
	{
		
		OnCameraUpdate();
		HandleFlinch();
		UpdateClothes();

		if ( IsAlive )
		{
			OnMovementUpdate();
		}
	}

	protected override void OnFixedUpdate()
	{
		if ( !IsAlive ) return;
		OnMovementFixedUpdate();

		if (IsProxy)
			return;

		FixedHealthEffectUpdate();
		UpdateInteractions();
	}
}
