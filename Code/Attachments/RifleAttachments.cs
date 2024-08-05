

namespace GeneralGame;


//chokes
//{

	[Title( "Surfire Silencer" )]
	public class Surfire : SilencerAttachment
	{
		public override string Name => "Surfire Silencer";
		public override string IconPath => "ui/hud/supressor.png";
		public override string BodyGroup { get; set; } = "muzzle";
		public override int BodyGroupChoice { get; set; } = 2;
		public override int BodyGroupDefault { get; set; } = 0;



		// Silencer
		public override ParticleSystem MuzzleFlashParticle { get; set; } = ParticleSystem.Load( "particles/swb/muzzle/flash_silenced.vpcf" );
		[Property, Group( "Silencer" )] public override SoundEvent ShootSound { get; set; }
	}
	[Title( "PSB5 Silencer" )]
	public class PSB5 : SilencerAttachment
	{
		public override string Name => "PSB5 Silencer";
		public override string IconPath => "ui/hud/supressor.png";
		public override string BodyGroup { get; set; } = "muzzle";
		public override int BodyGroupChoice { get; set; } = 1;
		public override int BodyGroupDefault { get; set; } = 0;

		// Silencer
		public override ParticleSystem MuzzleFlashParticle { get; set; } = ParticleSystem.Load( "particles/swb/muzzle/flash_silenced.vpcf" );
		[Property, Group( "Silencer" )] public override SoundEvent ShootSound { get; set; }
	}

//}



//Rails
//{
	[Title( "Rail Zenit" )]
	public class ZenitRail : RailAttachment
	{
		public override string Name => "Rail Zenit";
		public override string IconPath => "";
		public override string BodyGroup { get; set; } = "rail";
		public override int BodyGroupChoice { get; set; } = 1;
		public override int BodyGroupDefault { get; set; } = 0;
	}


//}


//Sights
//{

[Title( "CMore Rail" )]
public class CMoreRail : SightAttachment
{
	public override string Name => "CMore Rail";
	public override string IconPath => "ui/hud/sightmark.png";
	public override string BodyGroup { get; set; } = "sight";
	public override int BodyGroupChoice { get; set; } = 1;
	public override int BodyGroupDefault { get; set; } = 0;

	// Sight
	public override float AimPlayerFOV { get; set; } = 50f;
	public override float AimSensitivity { get; set; } = 0.5f;
}

//}
