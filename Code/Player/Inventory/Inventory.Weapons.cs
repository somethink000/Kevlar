

namespace GeneralGame;

public partial class Inventory
{
	[Property] public GameObject WeaponBone { get; set; }

	public Weapon Deployed;
	public EquipSlot CurrentWeaponSlot { get; set; } = EquipSlot.FirstWeapon;

	public void DeployCurrent()
	{
		
		var item = _equippedItems[(int)CurrentWeaponSlot];

		if (item == null) return;

		if (item.GameObject.Components.GetInDescendantsOrSelf<Weapon>(true) != null)
		{
			Weapon nextWeapon = item.GameObject.Components.GetInDescendantsOrSelf<Weapon>(true);
			
			
			Deployed = nextWeapon;

			nextWeapon.Deploy( Player );

		}

	}

	public void UpdateWeaponSlot()
	{
		if ( IsProxy ) return;

		if ( Input.Pressed( InputButtonHelper.Slot1 ) ) Next();
		else if ( Input.Pressed( InputButtonHelper.Slot2 ) ) Next();
		else if ( Input.MouseWheel.y > 0 ) Next();
		else if ( Input.MouseWheel.y < 0 ) Next();
	}

	public void RemoveEquipUpdate( EquipSlot slot, bool drop = false)
	{
		if ( CurrentWeaponSlot == slot ) {
			Deployed.EndHolster();
			Deployed = null;
		}
		
	}
	public void AddEquipUpdate( EquipSlot slot )
	{
		if ( CurrentWeaponSlot == slot ) DeployCurrent();
	}
	 
	
	public void Next()
	{
		

		
		if ( Deployed != null )
		{
			
			if ( !Deployed.CanHolster() ) return;
			Deployed.Holster();

		}
		else
		{
			ChangeSlot();
		}
		
	}

	public void ChangeSlot()
	{
		Deployed = null;


		if ( CurrentWeaponSlot == EquipSlot.FirstWeapon )
		{
			CurrentWeaponSlot = EquipSlot.SeccondWeapon;
		}
		else
		{
			CurrentWeaponSlot = EquipSlot.FirstWeapon;
		}

		DeployCurrent();
	}

}
