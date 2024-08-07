

namespace GeneralGame;

public partial class Inventory
{
	[Property] public GameObject WeaponBone { get; set; }

	[Sync] public Weapon Deployed { get; private set; }

	private bool toolgunActive = false;
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

	[Broadcast]
	public void UpdateWeaponSlot()
	{
		
		if ( Deployed != null )
		{
			Player.AnimationHelper.MoveStyle = Deployed.IsRunning ? HumanAnimationsHelper.MoveStyles.WeaponSprint : HumanAnimationsHelper.MoveStyles.Citizen;
			Player.AnimationHelper.WeaponHold = Deployed.IsRunning ? HumanAnimationsHelper.WeaponHoldes.Relaxed : HumanAnimationsHelper.WeaponHoldes.Normal;
			Player.AnimationHelper.HoldType = Deployed.HoldType;
		} else
		{

			Player.AnimationHelper.HoldType = HumanAnimationsHelper.HoldTypes.None;
		}

		if ( IsProxy ) return;

		//if ( activeItem is null || !activeItem.CanCarryStop() ) return;
		if ( Input.Pressed( InputButtonHelper.Slot1 ) ) Next();
		else if ( Input.Pressed( InputButtonHelper.Slot2 ) ) Next();
		else if ( Input.MouseWheel.y > 0 ) Next();
		else if ( Input.MouseWheel.y < 0 ) Next();


	}

	public void RemoveEquipUpdate( EquipSlot slot, bool drop = false)
	{
		if ( IsProxy ) return;
		if ( CurrentWeaponSlot == slot ) { 
			Deployed.Holster();
			Deployed = null;
		}
		
	}
	public void AddEquipUpdate( EquipSlot slot )
	{
		if ( IsProxy ) return;
		if ( CurrentWeaponSlot == slot ) DeployCurrent();
	}

	
	public void Next()
	{
		if ( IsProxy ) return;

		Deployed?.Holster();
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
