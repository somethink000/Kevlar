
using System;
using System.Linq;
using static Sandbox.Connection;

namespace GeneralGame;


public partial class PlayerBase : Component, Component.INetworkSpawn, IPlayerBase, IHealthComponent
{
	[Property] public GameObject Head { get; set; }
	[Property] public GameObject Body { get; set; }
	[Property] public SkinnedModelRenderer BodyRenderer { get; set; }
	[Property] public CameraComponent Camera { get; set; }
	[Property] public PanelComponent RootDisplay { get; set; }
    [Property] public Inventory Inventory { get; set; }
	[Property] public Voice Voice { get; set; }

	private float SaveDelay = 60f;
	private TimeSince SinceSave { get; set; }
	public int MaxCarryWeight { get; set; }
	public bool IsEncumbered => Inventory.Weight > MaxCarryWeight;

	public int Level;
	public int Experience;
	public bool DropInvent;
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
			Setup( this );
			SinceSave = 0;
			Save();

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

	public void GoodGameEnding()
	{
		DropInvent = false;
		Save();
	}

	private void MoveToSpawnPoint()
	{
		if ( IsProxy )
			return;
		
		var spawnpoints = Scene.GetAllComponents<SpawnPoint>();
		var randomSpawnpoint = Game.Random.FromList( spawnpoints.ToList() );
		Network.ClearInterpolation();
		WorldPosition = randomSpawnpoint.WorldPosition;
		WorldRotation = Rotation.FromYaw( randomSpawnpoint.WorldRotation.Yaw() );
		
		EyeAngles = WorldRotation;
	}

	

	[Rpc.Broadcast]
	public virtual void OnDeath( DamageInfo damage )
	{

		var force = damage.Weapon.WorldRotation.Forward * 10 * damage.Damage;

		if ( IsProxy ) return;

		Deaths += 1;
		CharacterController.Velocity = 0;
		Ragdoll( force, damage.Attacker.WorldPosition );

		
		//var ply = damage.Attacker.Components.GetInAncestorsOrSelf<PlayerBase>();

		
		CurrentGame.OnPlayerDeath( this );

		
	}
	///GameManager.ActiveScene.LoadFromFile( "scenes/basement.scene" );
	public async void RespawnWithDelay( float delay )
	{
		await GameTask.DelaySeconds( delay );
		Respawn();
	}


	protected override void OnUpdate()
	{
		
		OnCameraUpdate();
		HandleFlinch();

		if ( !IsProxy && SinceSave > SaveDelay )
		{
			SinceSave = 0;
			Save();
		}


		if ( !IsProxy && IsAlive && IsFirstPerson )
		{
			BodyRenderer.RenderType = ModelRenderer.ShadowRenderType.ShadowsOnly;
		}
		else
		{
			BodyRenderer.RenderType = ModelRenderer.ShadowRenderType.On;
		}


		if ( IsAlive )
		{
			OnMovementUpdate();
		}
	}

	protected override void OnFixedUpdate()
	{
		if ( !IsAlive ) return;

		OnMovementFixedUpdate();
		if ( !IsProxy )
	
		if (IsProxy)
			return;

		FixedHealthEffectUpdate();
		UpdateInteractions();
	}
}
