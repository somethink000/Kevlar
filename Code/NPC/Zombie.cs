

using Sandbox;
using Sandbox.Citizen;
using static Sandbox.Diagnostics.PerformanceStats;
using static Sandbox.PhysicsContact;
using static Sandbox.VertexLayout;

namespace GeneralGame;


public class Zombie : Component, Component.IDamageable
{


	
	[RequireComponent] public CitizenAnimationHelper animationHelper { get; set; }
	[RequireComponent] public Dresser Dresser { get; set; }
	[Property] public SkinnedModelRenderer Model { get; set; }
	[RequireComponent] public ModelCollider Collider { get; set; }
	[RequireComponent] NavMeshAgent agent { get; set; }
	[RequireComponent] public ModelPhysics RagdollPhysics { get; set; }


	[Property] GroupedCloth Cloths { get; set; }
	[Property] public Model MalModel { get; set; }
	[Property] public Model FemModel { get; set; }
	[Property] public Material ZombTexture { get; set; }
	[Property] public TagSet EnemyTags { get; set; }
	[Property] public float AttackDelay { get; set; } = 1;
	[Property] public int DeleteTime { get; set; } = 10;
	[Property] public float DetectRange { get; set; } = 256f;
	[Property] public float MaxHealth { get; set; } = 100f;
	[Property] public SoundEvent headshotSounds { get; set; }
	[Property] public SoundEvent hitSounds { get; set; }
	[Property, Group( "AI" )] public bool AlertOthers { get; set; } = true;
	[Property, Group( "AI" )] public float VisionRange { get; set; } = 512f;
	
	//MathF.Max(MathF.Max(GameObject.WorldTransform.Scale.x, GameObject.WorldTransform.Scale.y), GameObject.WorldTransform.Scale.z )
	public float Scale => 1f;
	public float AttackRange { get; set; } = 80f;
	public LifeState LifeState { get; private set; } = LifeState.Alive;
	public float Health { get; private set; } = 100f;
	public GameObject TargetObject { get; private set; } = null;
	public GameObject TargetPrimaryObject { get; set; } = null;
	public bool IsAlive => Health > 0;
	private bool IsRunner { get; set; }
	public bool IsRagdolled => RagdollPhysics.Enabled;

	private TimeSince timeSinceHit = 0;
	private TimeSince timeSinceDead = 0;

	[HostSync] public bool ReachedDestination { get; set; } = true;
	[HostSync] public Vector3 TargetPosition { get; set; }
	[HostSync] public bool FollowingTargetObject { get; set; } = false;
	[HostSync] public int NpcId { get; set; }


	protected override void OnAwake()
	{
		Random rnd = new Random();


		if ( rnd.Next( 0, 2 ) == 1)
		{
			Model.Model = FemModel;
			Collider.Model = FemModel;
			RagdollPhysics.Model = FemModel;
		}
		else
		{
			Model.Model = MalModel;
			Collider.Model = MalModel;
			RagdollPhysics.Model = MalModel;
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

	}
	protected override void OnStart()
	{
	
		Model.MaterialOverride = ZombTexture;

		NpcId = Scene.GetAllComponents<Zombie>().OrderByDescending( x => x.NpcId ).First().NpcId + 1;
	}

	//if (Vector3.DistanceBetween(target, GameObject.Transform.Position) < 80f)
	protected override void OnFixedUpdate()
	{
		if ( IsProxy || LifeState == LifeState.Dead )
			return;

		
		//animationHelper.HoldType = CitizenAnimationHelper.HoldTypes.Punch;
		//animationHelper.MoveStyle = CitizenAnimationHelper.MoveStyles.Run;
		animationHelper.WithWishVelocity( agent.WishVelocity );
		animationHelper.WithVelocity( agent.Velocity );
		Model.GameObject.WorldRotation = Rotation.Lerp( Model.GameObject.WorldRotation, Rotation.LookAt( agent.Velocity.WithZ( 0f ), Vector3.Up ), Time.Delta * (IsRunner ? 10f : 5f) );
		//if ( TargetObject != null ) { 
		//	var targetRot = Rotation.LookAt( TargetObject.WorldPosition.WithZ( WorldPosition.z ) - WorldPosition );
		//	WorldRotation = Rotation.Slerp( WorldRotation, targetRot, Time.Delta * 5.0f );
		//}
		//if ( !IsRunner )
		//{
			
			CheckNewTargetPos();
			Model.Set( "wish_x", 360 );
			DetectAround();
		//}
		



		base.OnFixedUpdate();
	}

	protected override void OnUpdate()
	{
		if ( IsProxy )
			return;

		if ( LifeState == LifeState.Dead )
		{
			if ( timeSinceDead > DeleteTime )
			{
				GameObject.Destroy();
			}
			
			return;
		}
		
		//if ( TargetPrimaryObject != null )
		//{
			
		//	agent.MoveTo( TargetPrimaryObject.WorldPosition );
		//}

	}

	public void OnDamage( in DamageInfo damage )
	{
		
		if ( IsProxy || LifeState == LifeState.Dead )
			return;

		

		Health -= damage.Damage;


		if ( Health <= 0 )
		{
			Ragdoll( damage.Weapon.WorldRotation.Forward * 10 * damage.Damage );
			timeSinceDead = 0;
			LifeState = LifeState.Dead;
		}
			

		//if ( Array.Exists( damage.Hitbox.Tags.TryGetAll().ToArray(), tag => tag == "head" ) )
		//{

		//	damage.Damage *= 2;
		//	if ( damage.Damage > MaxHealth )
		//	{
		//		Log.Info( damage.Damage );
		//		Sound.Play( headshotSounds, WorldPosition );
		//		Model.SetBodyGroup( "head", 1 );
		//	}

		//}

	}


	[Rpc.Broadcast]
	public virtual void Ragdoll( Vector3 force )
	{
		Collider.Enabled = false;
		RagdollPhysics.Enabled = true;

		foreach ( var body in RagdollPhysics.PhysicsGroup.Bodies )
		{

			body.ApplyImpulseAt( WorldPosition, force );
		}
	}

	public void Detected( GameObject target, bool alertOthers = false )
	{

		if ( target == null ) return;
		target = target.Parent == null || target.Parent == Scene ? target : target.Parent;
		if ( target == TargetObject ) return;

		SetTarget( target );
		BroadcastOnDetect();

		if ( alertOthers && AlertOthers )
		{
			var otherNpcs = Scene.GetAllComponents<Zombie>()
				.Where( x => x.WorldPosition.Distance( WorldPosition ) <= x.VisionRange * x.Scale ) // Find all nearby NPCs
				.Where( x => x.IsAlive ) // Dead or undead
				.Where( x => x.TargetObject == null ) // They don't have a target already
				.Where( x => x != this ) // Not us
				.Where( x => x.GameObject != null ) // And that don't have a target already
				.Where( x => !x.EnemyTags.HasAny( Tags ) ); // And we are friends

			foreach ( var npc in otherNpcs )
				npc.Detected( target, false );
		}

	}
	public void Undetected()
	{
		BroadcastOnEscape();

		TargetObject = null;
		TargetPosition = Transform.Position;
		ReachedDestination = true;
	}

	public void DetectAround()
	{
		if ( TargetObject != null )
		{
			if ( IsWithinRange( TargetObject ) )
			{
				//if ( NextAttack )
				//{
				//	BroadcastOnAttack();
				//	NextAttack = AttackCooldown;
				//}
			}
		}

		var currentTick = (int)(Time.Now / Time.Delta);
		if ( currentTick % 20 != NpcId % 20 ) return; // Check every 20 ticks

		var foundAround = Scene.FindInPhysics( new Sphere( Transform.Position, DetectRange * Scale ) ) // Find gameobjects nearby
			.Where( x => x.Enabled )
			.Where( x => EnemyTags != null && x.Tags.HasAny( EnemyTags ) ) // Do they have any of our enemy tags
			.Where( x => x.Components.GetInAncestorsOrSelf<IHealthComponent>()?.LifeState == LifeState.Alive ); // Are they dead or undead

		if ( TargetObject == null || TargetPrimaryObject == TargetObject )
		{
			if ( foundAround.Any() )
			{

				Detected( foundAround.First(), true ); // If we don't have any target yet, pick the first one around us
			}
			else
			{
				Detected( TargetPrimaryObject, false );
			}


		}
		else
		{
			if ( TargetPrimaryObject == TargetObject ) return;
			var targetDead = TargetObject.Components.GetInAncestorsOrSelf<IHealthComponent>()?.LifeState == LifeState.Dead; // Is our target dead or undead
			var targetEscaped = TargetObject.Transform.Position.Distance( Transform.Position ) > VisionRange * Scale; // Did our target get out of vision range

			if ( targetEscaped || targetDead ) // Did our target die or escape
				Undetected();
		}
	}

	public void SetTarget( GameObject target, bool escapeFrom = false )
	{
		if ( target == null )
		{
			TargetObject = null;
			FollowingTargetObject = false;
			ReachedDestination = true;
			TargetPosition = WorldPosition;
		}
		else
		{
			TargetObject = target;
			FollowingTargetObject = !escapeFrom;
			MoveTo( GetPreferredTargetPosition( TargetObject ) );
			ReachedDestination = false;
		}
	}

	
	public bool IsWithinRange( GameObject target )
	{
		if ( !GameObject.IsValid() ) return false;

		return IsWithinRange( target, AttackRange * Scale );
	}

	
	public bool IsWithinRange( GameObject target, float range = 60f )
	{
		if ( !GameObject.IsValid() ) return false;

		return target.WorldPosition.Distance( WorldPosition ) <= range;
	}

	void CheckNewTargetPos()
	{
		if ( TargetObject.IsValid() )
		{
			if ( TargetPosition.Distance( GetPreferredTargetPosition( TargetObject ) ) >= AttackRange / 4f ) // Has our target moved?
			{
				MoveTo( GetPreferredTargetPosition( TargetObject ) );
			}
		}
	}

	public static Vector3 GetRandomPositionAround( Vector3 position, float minRange = 50f, float maxRange = 300f )
	{
		var tries = 0;
		var hitGround = false;
		var hitPosition = position;

		while ( hitGround == false && tries <= 10f )
		{
			var randomDirection = Rotation.FromYaw( Game.Random.Float( 360f ) ).Forward;
			var randomDistance = Game.Random.Float( minRange, maxRange );
			var randomPoint = position + randomDirection * randomDistance;

			var groundTrace = Game.ActiveScene.Trace.Ray( randomPoint + Vector3.Up * 64f, randomPoint + Vector3.Down * 64f )
				.Size( 5f )
				.WithoutTags( "player", "npc", "trigger" )
				.Run();

			if ( groundTrace.Hit && !groundTrace.StartedSolid )
			{
				hitGround = true;
				hitPosition = groundTrace.HitPosition;
			}

			tries++;
		}

		return hitPosition;
	}

	public Vector3 GetPreferredTargetPosition( GameObject target )
	{
		if ( !target.IsValid() )
			return TargetPosition;

		var targetPosition = target.WorldPosition;

		var direction = (WorldPosition - targetPosition).Normal;
		var offset = FollowingTargetObject ? direction * AttackRange * Scale / 2f : direction * VisionRange * Scale;
		var wishPos = targetPosition + offset;

		var groundTrace = Scene.Trace.Ray( wishPos + Vector3.Up * 64f, wishPos + Vector3.Down * 64f )
			.Size( 5f )
			.IgnoreGameObjectHierarchy( GameObject )
			.WithoutTags( "player", "npc", "trigger" )
			.Run();
		//Log.Info( target.Transform.Position.Distance( groundTrace.Hit && !groundTrace.StartedSolid ? groundTrace.HitPosition : (FollowingTargetObject ? targetPosition : targetPosition + offset) ) );
		//Log.Info( FollowingTargetObject );
		return groundTrace.Hit && !groundTrace.StartedSolid ? groundTrace.HitPosition : (FollowingTargetObject ? targetPosition : targetPosition + offset);
	}


	public void MoveTo( Vector3 targetPosition )
	{
		TargetPosition = targetPosition;
		ReachedDestination = false;
		agent.MoveTo( targetPosition );
	}


	[Rpc.Broadcast]
	protected virtual void BroadcastOnDetect()
	{

	}

	[Rpc.Broadcast]
	private void BroadcastOnEscape()
	{

	}
}
