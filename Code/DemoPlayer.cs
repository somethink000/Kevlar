
using System.Linq;

namespace GeneralGame;


public class DemoPlayer : PlayerBase
{
	/*void GiveWeapon( string className, bool setActive = false )
	{
		var weaponGO = WeaponRegistry.Instance.Get( className );
		var weapon = weaponGO.Components.Get<Weapon>( true );
		Inventory.AddClone( weaponGO, setActive );
		SetAmmo( weapon.Primary.AmmoType, 360 );
	}

	Weapon GetWeapon( string className )
	{
		var weaponGO = Inventory.Items.First( x => x.Name == className );
		if ( weaponGO is not null )
			return weaponGO.Components.Get<Weapon>();

		return null;
	}*/


	public override void OnDeath( Vector3 force, Vector3 origin )
	{
		base.OnDeath( force, origin );
		
	}

	/*public override void TakeDamage(DamageInfo info)
	{
		base.TakeDamage(info);
	}*/
}
