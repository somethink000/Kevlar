using Sandbox.Citizen;

namespace GeneralGame;

public partial class Weapon
{
	public enum FiringType
	{
		/// <summary>Single fire</summary>
		semi,
		/// <summary>Automatic fire</summary>
		auto,
		/// <summary>3-Burst fire</summary>
		burst
	}

	public enum InfiniteAmmoType
	{
		/// <summary>No infinite ammo</summary>
		disabled = 0,
		/// <summary>Infinite clip ammo, no need to reload</summary>
		clip = 1,
		/// <summary>Infinite reserve ammo, can always reload</summary>
		reserve = 2
	}


	[Property, Group( "Ammo" ), Sync] public int Ammo { get; set; } = 10;
	[Property, Group( "Ammo" )] public int ClipSize { get; set; } = 10;
	[Property, Group( "Ammo" )] public InfiniteAmmoType InfiniteAmmo { get; set; } = InfiniteAmmoType.disabled;
	[Property, Group( "Bullets" )] public int Bullets { get; set; } = 1;
	[Property, Group( "Bullets" )] public float BulletSize { get; set; } = 0.1f;
	public IBulletBase BulletType { get; set; } = new HitScanBullet();
	[Property, Group( "Bullets" )] public float BulletTracerChance { get; set; } = 0.33f;
	[Property, Group( "Bullets" )] public float Damage { get; set; } = 5;
	[Property, Group( "Bullets" )] public float Force { get; set; } = 0.1f;
	[Property, Group( "Bullets" )] public float HitFlinch { get; set; } = 1.25f;
	[Property, Group( "Bullets" )] public float Spread { get; set; } = 0.1f;
	[Property, Group( "Bullets" )] public float Recoil { get; set; } = 0.1f;
	[Property, Group( "Bullets" )] public int RPM { get; set; } = 200;
	[Property, Group( "Bullets" )] public FiringType FireMod { get; set; } = FiringType.semi;
	[Property, Group( "Sounds" )] public SoundEvent DryShootSound { get; set; }
	[Property, Group( "Sounds" )] public SoundEvent ShootSound { get; set; }
	[Property, Group( "Particles" )] public float VMParticleScale { get; set; } = 1f;
	[Property, Group( "Particles" )] public ParticleSystem BulletEjectParticle { get; set; }
	[Property, Group( "Particles" )] public ParticleSystem MuzzleFlashParticle { get; set; }
	[Property, Group( "Particles" )] public ParticleSystem BarrelSmokeParticle { get; set; }
	[Property, Group( "Particles" )] public ParticleSystem BulletTracerParticle { get; set; }






	[Property, Group( "Models" )] public Model ViewModel { get; set; }
	[Property, Group( "Models" )] public Model ViewModelHands { get; set; }
	[Property, Group( "Models" )] public Model WorldModel { get; set; }

	[Property, Group( "General" )] public CitizenAnimationHelper.HoldTypes HoldType { get; set; } = CitizenAnimationHelper.HoldTypes.Pistol;
	[Property, Group( "General" )] public float AimSensitivity { get; set; } = 0.85f;
	[Property, Group( "General" )] public bool BulletCocking { get; set; } = true;
	[Property, Group( "General" )] public float TuckRange { get; set; } = 30f;
	
	[Property, Group( "FOV" )] public float AimFOV { get; set; } = 0f;
	[Property, Group( "FOV" ), Title( "Aim in FOV speed" )] public float AimInFOVSpeed { get; set; } = 1f;
	[Property, Group( "FOV" ), Title( "Aim out FOV speed" )] public float AimOutFOVSpeed { get; set; } = 1f;

	[Property, Group( "Animations" )] public float AnimSpeed { get; set; } = 1;
	[Property, Group( "Animations" ), Title( "Aim Offset" )] public AngPos AimAnimData { get; set; }
	[Property, Group( "Animations" ), Title( "Run Offset" )] public AngPos RunAnimData { get; set; }
	[Property, Group( "Animations" ), Title( "Customizing Offset" )] public AngPos CustomizeAnimData { get; set; }
	[Property, Group( "Animations" )] public float ReloadTScale { get; set; } = 1f;
	[Property, Group( "Animations" )] public float ReloadEmptyTScale { get; set; } = 1f;
	[Property, Group( "Animations" )] public float DrawTScale { get; set; } = 1f;

	[Property, Group( "Shell Reloading" )] public bool ShellReloading { get; set; } = false;
	[Property, Group( "Shell Reloading" )] public bool ShellReloadingShootCancel { get; set; } = true;
	[Property, Group( "Shell Reloading" )] public float ShellEjectDelay { get; set; } = 0;
	[Property, Group( "Shell Reloading" )] public float ShellReloadStartTime { get; set; } = 0;
	[Property, Group( "Shell Reloading" )] public float ShellReloadInsertTime { get; set; } = 0;

	[Property, Group( "Bolt Action Reloading" )] public bool BoltBack { get; set; } = false;
	[Property, Group( "Bolt Action Reloading" )] public float BoltBackTime { get; set; } = 0f;
	[Property, Group( "Bolt Action Reloading" )] public float BoltBackEjectDelay { get; set; } = 0f;

	[Property, Group( "Scoping" )] public bool Scoping { get; set; } = false;
	[Property, Group( "Scoping" )] public ScopeInfo ScopeInfo { get; set; } = new();

	[Property] public PrefabFile AmmoType { get; set; }

	//Basic Anims
	public string ShootAnim { get; set; } = "shoot";
	public string ReloadAnim { get; set; } = "reload";
	public string BoltBackAnim { get; set; } = "boltback";
	//Features  Anims
	public string DeployAnim { get; set; } = "deploy";
	public string HolsterAnim { get; set; } = "holster";
	public string InspectAnim { get; set; } = "inspect";
	public string ReadyAnim { get; set; } = "ready";
	public string ModeAnim { get; set; } = "mode";
	public string FixAnim { get; set; } = "fix";
	//Anim states
	public string EmptyState { get; set; } = "empty";
	public string AimState { get; set; } = "aiming";

	public bool IsCustomizing { get; set; }
	public bool IsRunning => Owner!=null && Owner.IsRunning && Owner.IsOnGround && Owner.Velocity.Length >= 200;
	public bool IsCrouching => Owner.IsCrouching;
	public bool CanSeeViewModel => !IsProxy && Owner.IsFirstPerson;

	public bool IsEmpty = false;
	public bool IsReady = false;
	public bool ShellReloadReady = false;

	[Sync] public bool IsReloading { get; set; }
	[Sync] public bool IsAiming { get; set; }
	[Sync] public bool IsScoping { get; set; }
	[Sync] public bool InBoltBack { get; set; }
	[Sync] public bool IsDeploying { get; set; }
	[Sync] public bool IsHolstering { get; set; }

	public TimeSince TimeSinceShoot { get; set; }


	// Private
	int burstCount = 0;
	int barrelHeat = 0;
}
