

using Sandbox.Citizen;

namespace GeneralGame;

public class Zombie : NPC
{
	[Property] public CitizenAnimationHelper animationHelper { get; set; }
	[Property] public SoundEvent hitSounds { get; set; }
	[Property] public SoundEvent rageSounds { get; set; }
	[Property] public SoundEvent deathSounds { get; set; }
	[Property] public SoundEvent shotedSounds { get; set; }
	[Property] public SoundEvent detectSounds { get; set; }
	[Property] public SoundEvent headshotSounds { get; set; }

	
	protected override void OnFixedUpdate()
	{
		base.OnFixedUpdate();
		animationHelper.HoldType = CitizenAnimationHelper.HoldTypes.Swing;
		animationHelper.MoveStyle = CitizenAnimationHelper.MoveStyles.Run;
		animationHelper.WithWishVelocity( MoveHelper.WishVelocity );
		animationHelper.WithVelocity( MoveHelper.Velocity );
	}

	[Broadcast]
	public override void TakeDamage( DamageType type, float damage, Vector3 position, Vector3 force, Guid attackerId, string[] hitboxes )
	{
		if ( IsProxy || LifeState == LifeState.Dead )
			return;

		
		if ( Array.Exists( hitboxes, tag => tag == "head" ) )
		{
			damage *= 2;
			if ( damage > MaxHealth )
			{
				Log.Info("effe");
				Sound.Play( headshotSounds, Transform.Position );
				Model.SetBodyGroup( "head", 1 );
			}
			
		}

		base.TakeDamage( type, damage, position, force, attackerId, hitboxes );
	
	}


	protected override void BroadcastOnDetect()
	{
		base.BroadcastOnDetect();
		GameObject.PlaySound( detectSounds );
	}

	protected override void BroadcastOnAttack()
	{
		base.BroadcastOnAttack();
		animationHelper.Target.Set( "b_attack", true );
		Sound.Play( hitSounds, Transform.Position );
		GameObject.PlaySound( rageSounds );

		IHealthComponent damageable;
		damageable = TargetObject.Components.GetInAncestorsOrSelf<IHealthComponent>();

		damageable.TakeDamage( DamageType.Bullet, 10, Transform.Position, Transform.Rotation.Forward * 5, GameObject.Id );
	}

	public override void Damaged( GameObject target )
	{
		base.Damaged( target );
		GameObject.PlaySound( shotedSounds );
	}

	protected override void OnDead( GameObject killer )
	{
		if ( killer.Components.GetInAncestorsOrSelf<PlayerBase>() is PlayerBase ply ) 
		{
			ply.CurrentGame.OnZombieKilled( ply );
		}

		
		GameObject.PlaySound( deathSounds );
	}
}
