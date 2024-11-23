
using System;
using System.Linq;

namespace GeneralGame;

public class HitScanBullet : IBulletBase
{
	public void Shoot( Weapon weapon, Vector3 spreadOffset )
	{
		var player = weapon.Owner;
		var forward = player.EyeAngles.Forward + spreadOffset;
		forward = forward.Normal;
		var endPos = player.EyePos + forward * 999999;
		var bulletTr = weapon.TraceBullet( player.EyePos, endPos );
		var hitObj = bulletTr.GameObject;

		if ( SurfaceUtil.IsSkybox( bulletTr.Surface ) || bulletTr.HitPosition == Vector3.Zero ) return;
		
		// Impact
		weapon.CreateBulletImpact( bulletTr );

		// Tracer
		if ( weapon.BulletTracerParticle is not null )
		{
			var random = new Random();
			var randVal = random.NextDouble();

			if ( randVal < weapon.BulletTracerChance )
				TracerEffects( weapon, bulletTr.HitPosition );
		}

		// Damage
		if ( !weapon.IsProxy && hitObj is not null  )
		{
			IHealthComponent damageable;
			damageable = hitObj.Components.GetInAncestorsOrSelf<IHealthComponent>();

			var hitTags = Array.Empty<string>();
			
			if ( bulletTr.Hitbox is not null )
				hitTags = bulletTr.Hitbox.Tags.TryGetAll().ToArray();

			//var dmgInfo = TakeDamage( DamageType.Bullet, weapon.ClassName, shootInfo.Damage, bulletTr.HitPosition, forward * 100 * shootInfo.Force, hitTags );
			damageable?.TakeDamage( DamageType.Bullet, weapon.Damage, bulletTr.HitPosition, forward * 100 * weapon.Force, weapon.Owner.GameObject.Id, hitTags );
		}
	}

	public Vector3 GetRandomSpread( float spread )
	{
		return (Vector3.Random + Vector3.Random + Vector3.Random + Vector3.Random) * spread * 0.25f;
	}

	void TracerEffects( Weapon weapon, Vector3 endPos )
	{
		//var scale = weapon.CanSeeViewModel ? shootInfo.VMParticleScale : shootInfo.WMParticleScale;
		var muzzleTransform = weapon.GetMuzzleTransform();

		if ( !muzzleTransform.HasValue ) return;

		SceneParticles particles = new( weapon.Scene.SceneWorld, weapon.BulletTracerParticle );
		particles?.SetControlPoint( 1, muzzleTransform.Value );
		particles?.SetControlPoint( 2, endPos );
		//particles?.SetNamedValue( "scale", scale );
		particles?.PlayUntilFinished( TaskSource.Create() );
	}
}
