

namespace GeneralGame;


[Title( "Rail" )]
public class VssModernRail : MagazinAttachment
{
	public override string Name => "Rail Modern";
	public override string IconPath => "";
	public override string BodyGroup { get; set; } = "rail";
	public override int BodyGroupChoice { get; set; } = 1;
	public override int BodyGroupDefault { get; set; } = 0;
}

[Title( "Magazin 30rnd" )]
public class VssMag10 : MagazinAttachment
{
	public override string Name => "Magazin 30rnd";
	public override string IconPath => "ui/hud/supressor.png";
	public override string BodyGroup { get; set; } = "magazin";
	public override int BodyGroupChoice { get; set; } = 1;
	public override int BodyGroupDefault { get; set; } = 0;
}

[Title( "Magazin 10rnd" )]
public class VssMag30 : MagazinAttachment
{
	public override string Name => "Magazin 10rnd";
	public override string IconPath => "ui/hud/supressor.png";
	public override string BodyGroup { get; set; } = "magazin";
	public override int BodyGroupChoice { get; set; } = 2;
	public override int BodyGroupDefault { get; set; } = 0;
}


////chokes
////{

//[Title( "Surfire Silencer" )]
//public class Surfire : SilencerAttachment
//{
//	public override string Name => "Surfire Silencer";
//	public override string IconPath => "ui/hud/supressor.png";
//	public override string BodyGroup { get; set; } = "muzzle";
//	public override int BodyGroupChoice { get; set; } = 2;
//	public override int BodyGroupDefault { get; set; } = 0;



//	// Silencer
//	public override ParticleSystem MuzzleFlashParticle { get; set; } = ParticleSystem.Load( "particles/swb/muzzle/flash_silenced.vpcf" );
//	[Property, Group( "Silencer" )] public override SoundEvent ShootSound { get; set; }
//}
//[Title( "PSB5 Silencer" )]
//public class PSB5 : SilencerAttachment
//{
//	public override string Name => "PSB5 Silencer";
//	public override string IconPath => "ui/hud/supressor.png";
//	public override string BodyGroup { get; set; } = "muzzle";
//	public override int BodyGroupChoice { get; set; } = 1;
//	public override int BodyGroupDefault { get; set; } = 0;

//	// Silencer
//	public override ParticleSystem MuzzleFlashParticle { get; set; } = ParticleSystem.Load( "particles/swb/muzzle/flash_silenced.vpcf" );
//	[Property, Group( "Silencer" )] public override SoundEvent ShootSound { get; set; }
//}

////}




