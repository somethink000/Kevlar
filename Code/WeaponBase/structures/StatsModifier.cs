namespace GeneralGame;

public class StatsModifier
{
	public float Damage { get; set; }
	public float Recoil { get; set; }
	public float Spread { get; set; }
	public float RPM { get; set; }
	public float Force { get; set; }

	// After phys bullets have been recreated
	//public float BulletVelocity { get; set; } = 0;

	public static readonly StatsModifier Zero = new();

	private bool applied;

	public static StatsModifier FromShootInfo( Weapon wpn )
	{
		return new()
		{
			Damage = wpn.Damage,
			Recoil = wpn.Recoil,
			Spread = wpn.Spread,
			RPM = wpn.RPM,
			Force = wpn.Force,
		};
	}

	public void Apply( Weapon weapon, bool onPrimary = true )
	{
		if ( applied ) return;

		
			Apply( weapon.InitialPrimaryStats );
	

		applied = true;
	}

	private void Apply( StatsModifier initialStats )
	{
		if (  initialStats is null ) return;

		Damage += initialStats.Damage * Damage;
		Recoil += initialStats.Recoil * Recoil;
		Spread += initialStats.Spread * Spread;
		RPM += (int)(initialStats.RPM * RPM);

		//weapon.BulletVelocityMod += BulletVelocity;
	}

	public void Remove( Weapon weapon )
	{
		if ( !applied ) return;

		
			Remove( weapon );
		

		//weapon.BulletVelocityMod -= BulletVelocity;
		applied = false;
	}

	private void Remove( StatsModifier initialStats )
	{
		if ( initialStats is null ) return;

		Damage -= initialStats.Damage * Damage;
		Recoil -= initialStats.Recoil * Recoil;
		Spread -= initialStats.Spread * Spread;
		RPM -= (int)(initialStats.RPM * RPM);
	}
}
