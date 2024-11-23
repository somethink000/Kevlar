

namespace GeneralGame;

public partial class Weapon
{
	public virtual SkinnedModelRenderer GetEffectRenderer()
	{
		SkinnedModelRenderer effectModel = WorldModelRenderer;

		if ( CanSeeViewModel )
			effectModel = ViewModelRenderer;

		return effectModel;
	}

	/// <summary>
	/// Gets the info on where to show the muzzle effect
	/// </summary>
	public virtual Transform? GetMuzzleTransform()
	{
		var activeAttachment = GetActiveAttachmentForCategory( AttachmentCategory.Muzzle );
		var effectRenderer = GetEffectRenderer();
		var effectAttachment = "muzzle";

		if ( activeAttachment is not null )
		{
			effectAttachment = activeAttachment.EffectAttachmentOrBone;
			Transform? effectBoneTransform = null;

			// Custom models will not use attachments but bones instead to position effects
			if ( CanSeeViewModel && activeAttachment.ViewModelRenderer is not null )
			{
				effectBoneTransform = activeAttachment.ViewModelRenderer.SceneModel.GetBoneWorldTransform( effectAttachment );
			}
			else if ( !CanSeeViewModel && activeAttachment.WorldModelRenderer is not null )
			{
				effectBoneTransform = activeAttachment.WorldModelRenderer.SceneModel.GetBoneWorldTransform( effectAttachment );
			}

			if ( effectBoneTransform.HasValue )
				return effectBoneTransform.Value;
		}

		return effectRenderer?.GetAttachment( effectAttachment );
	}

	/// <summary>
	/// If there is usable ammo left
	/// </summary>
	public bool HasAmmo()
	{
		

		if ( InfiniteAmmo == InfiniteAmmoType.clip )
			return true;

		if ( ClipSize == -1 )
		{
			return Owner.Inventory.HasItems(AmmoType);
		}

		if ( Ammo == 0 )
			return false;

		return true;
	}

	public bool IsShooting()
	{
		
		return GetRealRPM( RPM ) > TimeSinceShoot;

	}


	public static float GetRealRPM( int rpm )
	{
		return 60f / rpm;
	}

	public virtual float GetRealSpread( float baseSpread = -1 )
	{
		if ( !Owner.IsValid() ) return 0;

		float spread = baseSpread != -1 ? baseSpread : Spread;
		float floatMod = 1f;

		// Ducking
		if ( IsCrouching && !IsAiming )
			floatMod -= 0.25f;

		// Aiming
		if ( IsAiming && Bullets == 1 )
			floatMod /= 4;

		if ( !Owner.IsOnGround )
		{
			// Jumping
			floatMod += 0.75f;
		}
		else if ( Owner.Velocity.Length > 100 )
		{
			// Moving 
			floatMod += 0.25f;
		}

		return spread * floatMod;
	}

	public virtual Angles GetRecoilAngles( )
	{
		var recoilX = IsAiming ? -Recoil * 0.4f : -Recoil;
		var recoilY = Game.Random.NextFloat( -0.2f, 0.2f ) * recoilX;
		var recoilAngles = new Angles( recoilX, recoilY, 0 );
		return recoilAngles;
	}
}
