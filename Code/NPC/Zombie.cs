

using Sandbox.Citizen;
using static Sandbox.PhysicsContact;

namespace GeneralGame;


public class Zombie : Component, IHealthComponent
{


	[Property] GroupedCloth Cloths { get; set; }
	[Property] public Model MalModel{ get; set; }
	[Property] public Model FemModel { get; set; }
	[Property] public Material ZombTexture { get; set; }
	[RequireComponent] public CitizenAnimationHelper animationHelper { get; set; }
	[RequireComponent] public Dresser Dresser { get; set; }
	[RequireComponent] public SkinnedModelRenderer Model { get; set; }
	[RequireComponent] public ModelCollider Collider { get; set; }
	[RequireComponent] NavMeshAgent agent { get; set; }

	[Property] public SoundEvent hitSounds { get; set; }
	[Property] public SoundEvent rageSounds { get; set; }
	[Property] public SoundEvent deathSounds { get; set; }
	[Property] public SoundEvent shotedSounds { get; set; }
	[Property] public SoundEvent detectSounds { get; set; }
	[Property] public SoundEvent headshotSounds { get; set; }


	[Sync, Property] public float MaxHealth { get; set; } = 100f;
	[Sync] public LifeState LifeState { get; private set; } = LifeState.Alive;
	[Sync] public float Health { get; private set; } = 100f;

	//public GameObject TargetObject { get; private set; } = null;
	[Property] public GameObject TargetPrimaryObject { get; set; } = null;
	public bool IsAlive => Health > 0;
	private bool IsRunner { get; set; }


	protected override void OnAwake()
	{
		Random rnd = new Random();


		
		if ( rnd.Next( 0, 2 ) == 1)
		{
			Model.Model = FemModel;
			Collider.Model = FemModel;
		}
		else
		{
			Model.Model = MalModel;
			Collider.Model = MalModel;
		}

		if ( rnd.Next( 0, 100 ) > 50 )
		{
			IsRunner = true;
		}
		



		List<ClothStruct> ClothStructs = new List<ClothStruct>();
		ClothStructs.Add( rnd.FromList( Cloths.Jackets ) );
		ClothStructs.Add( rnd.FromList( Cloths.Shirts ) );
		ClothStructs.Add( rnd.FromList( Cloths.Trousers ) );
		ClothStructs.Add( rnd.FromList( Cloths.Shoes ) );

		foreach ( var c in ClothStructs )
		{
			Dresser.Clothing.Add( c.Cloth );
		};

		Dresser.Apply();
		//[Property]
		//public List<ClothingContainer.ClothingEntry> Clothing { get; set; }
		//Log.Info( cloths.Shirts );

	}
	protected override void OnStart()
	{
	
		Model.MaterialOverride = ZombTexture;


		if ( !IsRunner )
		{
			Model.Set( "wish_x", 360 ); 
		}
	}
	protected override void OnFixedUpdate()
	{
		base.OnFixedUpdate();
		//animationHelper.HoldType = CitizenAnimationHelper.HoldTypes.Punch;
		//animationHelper.MoveStyle = CitizenAnimationHelper.MoveStyles.Run;
		animationHelper.WithWishVelocity( agent.WishVelocity );
		animationHelper.WithVelocity( agent.Velocity );
		//var targetRot = Rotation.LookAt( TargetPrimaryObject.WorldPosition.WithZ( Transform.Position.z ) - GameObject.WorldPosition );
		//GameObject.WorldRotation = Rotation.Slerp( GameObject.WorldRotation, targetRot, Time.Delta * 5.0f );
	}

	protected override void OnUpdate()
	{
		if ( TargetPrimaryObject != null )
		{
			
			agent.MoveTo( TargetPrimaryObject.WorldPosition );
		}
	}

	[Broadcast]
	public virtual void TakeDamage( DamageType type, float damage, Vector3 position, Vector3 force, Guid attackerId, string[] hitboxes )
	{
		if ( IsProxy || LifeState == LifeState.Dead )
			return;


		if ( Array.Exists( hitboxes, tag => tag == "head" ) )
		{
			damage *= 2;
			if ( damage > MaxHealth )
			{
				
				Sound.Play( headshotSounds, WorldPosition );
				Model.SetBodyGroup( "head", 1 );
			}

		}

		//base.TakeDamage( type, damage, position, force, attackerId, hitboxes );

	}


	//protected override void BroadcastOnDetect()
	//{
	//	base.BroadcastOnDetect();
	//	GameObject.PlaySound( detectSounds );
	//}

	//protected override void BroadcastOnAttack()
	//{
	//	base.BroadcastOnAttack();
	//	animationHelper.Target.Set( "b_attack", true );
	//	Sound.Play( hitSounds, Transform.Position );
	//	GameObject.PlaySound( rageSounds );

	//	IHealthComponent damageable;
	//	damageable = TargetObject.Components.GetInAncestorsOrSelf<IHealthComponent>();

	//	damageable.TakeDamage( DamageType.Bullet, 10, Transform.Position, Transform.Rotation.Forward * 5, GameObject.Id );
	//}

	//public override void Damaged( GameObject target )
	//{
	//	base.Damaged( target );
	//	GameObject.PlaySound( shotedSounds );
	//}

	//protected override void OnDead( GameObject killer )
	//{
	//	if ( killer.Components.GetInAncestorsOrSelf<PlayerBase>() is PlayerBase ply ) 
	//	{
	//		ply.CurrentGame.OnZombieKilled( ply );
	//	}


	//	GameObject.PlaySound( deathSounds );
	//}
}
