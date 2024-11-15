namespace GeneralGame;

public partial class Weapon
{
	public virtual void Reload()
	{
		
		if ( IsReloading || InBoltBack || IsShooting() )
			return;

		var maxClipSize = BulletCocking ? Primary.ClipSize + 1 : Primary.ClipSize;

		if ( Primary.Ammo >= maxClipSize || Primary.ClipSize == -1 )
			return;

		var isEmptyReload = ReloadEmptyTime > 0 && Primary.Ammo == 0;

		if ( BulletsReload )
		{
			TimeSinceReload = -ReloadTimes[Primary.Ammo];
		}
		else
		{
			TimeSinceReload = -(isEmptyReload ? ReloadEmptyTime : ReloadTime);
		}

		

		
		if ( !Owner.Inventory.HasItems( AmmoType ) && !Owner.CurrentGame.InfiniteAmmo )
			return;
		
		
		IsReloading = true;

		// Anim
		var reloadAnim = ReloadAnim;
		if ( isEmptyReload && !string.IsNullOrEmpty( ReloadEmptyAnim ) && !BulletsReload )
		{
			reloadAnim = ReloadEmptyAnim;
		}


		// Player anim
		HandleReloadEffects();

		//Boltback
		if ( !isEmptyReload && Primary.Ammo == 0 && BoltBack )
		{
			TimeSinceReload -= BoltBackTime;
			AsyncBoltBack( ReloadTime );
		}
	}

	public virtual void OnReloadFinish()
	{
		IsReloading = false;
		var maxClipSize = BulletCocking && Primary.Ammo > 0 ? Primary.ClipSize + 1 : Primary.ClipSize;

		if ( Owner.CurrentGame.InfiniteAmmo )
		{
			Primary.Ammo = maxClipSize;
			IsEmpty = false;
			return;
		}



		var ammo = Owner.Inventory.TryTake( AmmoType, maxClipSize - Primary.Ammo ); //Owner.TakeAmmo( Primary.AmmoType, maxClipSize - Primary.Ammo );

		if ( ammo == 0 )
			return;

		IsEmpty = false;
		Primary.Ammo += ammo;
	}

	public virtual void CancelShellReload()
	{
		IsReloading = false;
	}

	public virtual void OnShellReload()
	{
		ReloadTime = ShellReloadStartTime + ShellReloadInsertTime;
		Reload();
	}

	public virtual void OnShellReloadFinish()
	{
		IsReloading = false;

		var hasInfiniteReserve = Primary.InfiniteAmmo == InfiniteAmmoType.reserve;
		var ammo = Owner.Inventory.TryTake( AmmoType, 1 );

		Primary.Ammo += 1;

		if ( ammo != 0 && Primary.Ammo < Primary.ClipSize )
		{
			ReloadTime = ShellReloadInsertTime;
			Reload();
		}
		else
		{
			CancelShellReload();
		}
	}

	async void AsyncBoltBack( float boltBackDelay )
	{
		InBoltBack = true;

		// Start boltback
		await GameTask.DelaySeconds( boltBackDelay );
		if ( !IsValid ) return;


		// Eject shell
		await GameTask.DelaySeconds( BoltBackEjectDelay );
		if ( !IsValid ) return;
		var scale = Primary.ParticleScale;
		CreateParticle( Primary.BulletEjectParticle, "ejection_point", scale );

		// Finished
		await GameTask.DelaySeconds( BoltBackTime - BoltBackEjectDelay );
		if ( !IsValid ) return;
		InBoltBack = false;
	}

	[Broadcast]
	public virtual void HandleReloadEffects()
	{
		// Player
		Owner.BodyRenderer.Set( "b_reload", true );
	}
}
