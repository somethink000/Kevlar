namespace GeneralGame;

public abstract class SilencerAttachment : Attachment
{
	public override string Name => "Silencer";
	public override AttachmentCategory Category => AttachmentCategory.Muzzle;
	public override string Description => "Reduces the acoustic intensity of the muzzle report and the recoil when a gun is discharged by modulating the speed and pressure of the propellant gas from the muzzle.";
	public override string[] Positives => new string[]
	{
		"Reduce sound",
		"Reduce muzzle flash",
		"Increases accuracy by 5%"
	};

	public override string[] Negatives => new string[]
	{
	};

	/// <summary>New muzzle flash effect point</summary>
	[Property, Group( "Silencer" )] public override string EffectAttachmentOrBone { get; set; } = "muzzle_silenced";

	/// <summary>New particle used for the muzzle flash</summary>
	[Property, Group( "Silencer" )] public virtual ParticleSystem MuzzleFlashParticle { get; set; }
	ParticleSystem oldMuzzleFlashParticle;

	/// <summary>New sound used for firing</summary>
	[Property, Group( "Silencer" )] public virtual SoundEvent ShootSound { get; set; }
	SoundEvent oldShootSound;

	public override void OnEquip()
	{
		oldMuzzleFlashParticle = Weapon.MuzzleFlashParticle;
		oldShootSound = Weapon.ShootSound;

		if ( MuzzleFlashParticle is not null )
			Weapon.MuzzleFlashParticle = MuzzleFlashParticle;

		if ( ShootSound is not null )
			Weapon.ShootSound = ShootSound;
	}

	public override void OnUnequip()
	{
		Weapon.MuzzleFlashParticle = oldMuzzleFlashParticle;
		Weapon.ShootSound = oldShootSound;
	}
}
