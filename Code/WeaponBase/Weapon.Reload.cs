namespace GeneralGame;

public partial class Weapon
{
	public virtual void Reload()
	{
		
		if ( IsReloading || InBoltBack || IsShooting() )
			return;

		var maxClipSize = BulletCocking ? ClipSize + 1 : ClipSize;

		if ( Ammo >= maxClipSize || ClipSize == -1 )
			return;

		var isEmptyReload = Ammo == 0;

		
		if ( !Owner.Inventory.HasItems( AmmoType ) && !Owner.CurrentGame.InfiniteAmmo )
			return;
		
		if ( IsScoping )
			OnScopeEnd();

		IsReloading = true;

		ViewModelRenderer?.Set( ReloadAnim, true );
		
		// Player anim
		HandleReloadEffects();

		//Boltback
		//if ( !isEmptyReload && Ammo == 0 && BoltBack )
		//{
		//	TimeSinceReload -= BoltBackTime;
		//	AsyncBoltBack( ReloadTime );
		//}
	}

	public virtual void OnReloadFinish()
	{
		IsReloading = false;
		var maxClipSize = BulletCocking && Ammo > 0 ? ClipSize + 1 : ClipSize;

		if ( Owner.CurrentGame.InfiniteAmmo )
		{
			Ammo = maxClipSize;
			IsEmpty = false;
			return;
		}



		var ammo = Owner.Inventory.TryTake( AmmoType, maxClipSize - Ammo ); //Owner.TakeAmmo( Primary.AmmoType, maxClipSize - Primary.Ammo );

		if ( ammo == 0 )
			return;

		IsEmpty = false;
		Ammo += ammo;
	}

	public virtual void CancelShellReload()
	{
		IsReloading = false;
		ViewModelRenderer.Set( ReloadAnim, false );
	}

	public virtual void OnShellReload()
	{
		//ReloadTime = ShellReloadStartTime + ShellReloadInsertTime;
		//Reload();
	}

	public virtual void OnShellReloadFinish()
	{
		IsReloading = false;

		var hasInfiniteReserve = InfiniteAmmo == InfiniteAmmoType.reserve;
		var ammo = Owner.Inventory.TryTake( AmmoType, 1 );

		Ammo += 1;

		if ( ammo != 0 && Ammo < ClipSize )
		{
			//ReloadTime = ShellReloadInsertTime;
			Reload();
		}
		else
		{
			CancelShellReload();
		}
	}

	

	[Broadcast]
	public virtual void HandleReloadEffects()
	{
		// Player
		Owner.BodyRenderer.Set( "b_reload", true );
	}
}
