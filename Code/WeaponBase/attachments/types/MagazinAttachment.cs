namespace GeneralGame;

public abstract class MagazinAttachment : Attachment
{
	public override string Name => "Magazin";
	public override AttachmentCategory Category => AttachmentCategory.Magazine;
	public override string Description => "";
	public override string[] Positives => new string[]
	{

	};

	public override string[] Negatives => new string[]
	{
	};


	[Property] public virtual int ClipSize { get; set; } = 10;
	int oldClipSize;

	public override void OnEquip()
	{
		Weapon.Ammo = 0;
		oldClipSize = Weapon.ClipSize;

		Weapon.ClipSize = ClipSize;
	}

	public override void OnUnequip()
	{
		Weapon.ClipSize = oldClipSize;
		Weapon.Ammo = 0;
	}
}
