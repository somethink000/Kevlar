
using System;
using System.Collections.Generic;

namespace GeneralGame;

public partial class Weapon
{
	/// <summary>
	/// Checks if the weapon can do the provided attack
	/// </summary>
	/// <param name="shootInfo">Attack information</param>
	/// <param name="lastAttackTime">Time since this attack</param>
	/// <param name="inputButton">The input button for this attack</param>
	/// <returns></returns>
	public virtual bool CanShoot( )
	{
		
		if ( IsShooting() || (IsReloading && !ShellReloading) || InBoltBack || IsHolstering ) return false;
		if ( !Owner.IsValid() || IsRunning || !Owner.IsAlive ) return false;
		
		if ( !HasAmmo() )
		{
			//if ( shootInfo.DryShootSound is not null )
			//	PlaySound( shootInfo.DryShootSound.ResourceId );

			if ( ShellReloading )
				StartShellReload();
			else
				Reload();

			return false;
		}
	
		if ( FireMod == FiringType.semi && !Input.Pressed( InputButtonHelper.PrimaryAttack ) ) return false;
		if ( FireMod == FiringType.burst )
		{
			if ( burstCount > 2 ) return false;

			if ( TimeSinceShoot > GetRealRPM( RPM ) )
			{
				burstCount++;
				return true;
			}

			return false;
		};
		
		if ( RPM <= 0 ) return true;
		
		return TimeSinceShoot > GetRealRPM( RPM );
	}

	public virtual void Shoot(  )
	{
		if ( !CanShoot() ) return;
		
		TimeSinceShoot = 0;

		// Ammo
		Ammo -= 1;

		if ( Ammo <= 0 ) IsEmpty = true;


		ViewModelRenderer.Set( ShootAnim, true );

		// Sound
		if ( ShootSound is not null )
			PlaySound( ShootSound.ResourceId );

		// Particles
		HandleShootEffects( );

		// Barrel smoke
		barrelHeat += 1;

		// Recoil
		Owner.EyeAnglesOffset += GetRecoilAngles( );

		// UI
		BroadcastUIEvent( "shoot", 100 );


		// Bullet
		for ( int i = 0; i < Bullets; i++ )
		{
			var realSpread = IsScoping ? 0 : GetRealSpread( Spread );
			var spreadOffset = BulletType.GetRandomSpread( realSpread );
			ShootBullet( spreadOffset );
		}

		Owner.ApplyFov( 10 );

	}

	[Broadcast]
	public virtual void ShootBullet( Vector3 spreadOffset )
	{
		
		BulletType.Shoot( this, spreadOffset );
	}

	/// <summary> A single bullet trace from start to end with a certain radius.</summary>
	public virtual SceneTraceResult TraceBullet( Vector3 start, Vector3 end, float radius = 2.0f )
	{
		var startsInWater = SurfaceUtil.IsPointWater( start );
		List<string> withoutTags = new() { TagsHelper.Trigger, TagsHelper.PlayerClip, TagsHelper.PassBullets, TagsHelper.ViewModel };

		if ( startsInWater )
			withoutTags.Add( TagsHelper.Water );

		var tr = Scene.Trace.Ray( start, end )
				.UseHitboxes()
				.WithoutTags( withoutTags.ToArray() )
				.Size( radius )
				.IgnoreGameObjectHierarchy( Owner.GameObject )
				.Run();

		// Log.Info( tr.GameObject );

		return tr;
	}

	[Broadcast]
	public virtual void HandleShootEffects(  )
	{
		// Player
		Owner.BodyRenderer.Set( "b_attack", true );

		// Weapon
		var scale = VMParticleScale;
		var muzzleTransform = GetMuzzleTransform();

		if ( BoltBack && Ammo > 0 )
		{
			AsyncBoltBack( GetRealRPM( RPM ) );
		}

		if ( !muzzleTransform.HasValue ) return;

		// Muzzle flash
		if ( MuzzleFlashParticle is not null )
			CreateParticle( MuzzleFlashParticle, muzzleTransform.Value, scale, ( particles ) => ParticleToMuzzlePos( particles ) );

		// Barrel smoke
		if ( !IsProxy && BarrelSmokeParticle is not null && barrelHeat >= ClipSize * 0.75 )
			CreateParticle( BarrelSmokeParticle, muzzleTransform.Value, VMParticleScale, ( particles ) => ParticleToMuzzlePos( particles ) );
	}

	void ParticleToMuzzlePos( SceneParticles particles )
	{
		var transform = GetMuzzleTransform();

		if ( transform.HasValue )
		{
			// Apply velocity to prevent muzzle shift when moving fast
			particles?.SetControlPoint( 0, transform.Value.Position + Owner.Velocity * 0.03f );
			particles?.SetControlPoint( 0, transform.Value.Rotation );
		}
		else
		{
			particles?.Delete();
		}
	}

	/// <summary>Create a bullet impact effect</summary>
	public virtual void CreateBulletImpact( SceneTraceResult tr )
	{
		// Sound
		tr.Surface.PlayCollisionSound( tr.HitPosition );

		// Particles
		if ( tr.Surface.ImpactEffects.Bullet is not null )
		{
			var effectPath = Game.Random.FromList( tr.Surface.ImpactEffects.Bullet, "particles/impact.generic.smokepuff.vpcf" );

			if ( effectPath is not null )
			{
				// Surface def for flesh has wrong blood particle linked
				if ( effectPath.Contains( "impact.flesh" ) )
				{
					effectPath = "particles/impact.flesh.bloodpuff.vpcf";
				}
				else if ( effectPath.Contains( "impact.wood" ) )
				{
					effectPath = "particles/impact.generic.smokepuff.vpcf";
				}

				var p = new SceneParticles( Scene.SceneWorld, effectPath );
				p.SetControlPoint( 0, tr.HitPosition );
				p.SetControlPoint( 0, Rotation.LookAt( tr.Normal ) );
				p.PlayUntilFinished( TaskSource.Create() );
			}
		}

		// Decal
		if ( tr.Surface.ImpactEffects.BulletDecal is not null )
		{
			var decalPath = Game.Random.FromList( tr.Surface.ImpactEffects.BulletDecal, "decals/bullethole.decal" );

			if ( ResourceLibrary.TryGet<DecalDefinition>( decalPath, out var decalDef ) )
			{
				var decalEntry = Game.Random.FromList( decalDef.Decals );

				var gameObject = Scene.CreateObject();
				//gameObject.SetParent( tr.GameObject, false );
				gameObject.Transform.Position = tr.HitPosition;
				gameObject.Transform.Rotation = Rotation.LookAt( -tr.Normal );

				var decalRenderer = gameObject.Components.Create<DecalRenderer>();
				decalRenderer.Material = decalEntry.Material;
				decalRenderer.Size = new( decalEntry.Height.GetValue(), decalEntry.Height.GetValue(), decalEntry.Depth.GetValue() );
				gameObject.DestroyAsync( 30f );
			}
		}
	}

	/// <summary>Create a weapon particle</summary>
	public virtual void CreateParticle( ParticleSystem particle, string attachment, float scale, Action<SceneParticles> OnFrame = null )
	{
		var effectRenderer = GetEffectRenderer();

		if ( effectRenderer is null || effectRenderer.SceneModel is null ) return;

		var transform = effectRenderer.SceneModel.GetAttachment( attachment );

		if ( !transform.HasValue ) return;

		CreateParticle( particle, transform.Value, scale, OnFrame );
	}

	public virtual void CreateParticle( ParticleSystem particle, Transform transform, float scale, Action<SceneParticles> OnFrame = null )
	{
		SceneParticles particles = new( Scene.SceneWorld, particle );
		particles?.SetControlPoint( 0, transform.Position );
		particles?.SetControlPoint( 0, transform.Rotation );
		particles?.SetNamedValue( "scale", scale );

		if ( CanSeeViewModel )
			particles.Tags.Add( TagsHelper.ViewModel );

		particles?.PlayUntilFinished( Task, OnFrame );
	}
}
