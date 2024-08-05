
using System.Collections.Generic;
using System.Linq;
using static Sandbox.PhysicsContact;

namespace GeneralGame;

public partial class Weapon : Component
{
	public PlayerBase Owner { get; set; }
	public SkinnedModelRenderer WorldModelRenderer { get; private set; }
	public WeaponSettings Settings { get; private set; }
	public List<Attachment> Attachments = new();


	float animSpeed = 1;
	float playerFOVSpeed = 1;
	float targetPlayerFOV = Preferences.FieldOfView;
	float finalPlayerFOV = Preferences.FieldOfView;
	
	protected override void OnAwake()
	{
		//Tags.Add( TagsHelper.Weapon );
		Attachments = Components.GetAll<Attachment>( FindMode.EverythingInSelf ).OrderBy( att => att.Name ).ToList();

		WorldModelRenderer = Components.GetInDescendantsOrSelf<SkinnedModelRenderer>();
		Settings = WeaponSettings.Instance;
		InitialPrimaryStats = StatsModifier.FromShootInfo( Primary );
		InitialSecondaryStats = StatsModifier.FromShootInfo( Primary );
	}


	[Broadcast]
	public void Deploy(PlayerBase player)
	{
		Owner = player;
		
		GameObject.Enabled = true;
		
		SetupModels();

		if ( IsProxy ) return;

		CreateUI();

	}

	[Broadcast]
	public void Holster()
	{
		//if ( !CanCarryStop() ) return;

		GameObject.Enabled = false;

		if ( !IsProxy ) { 

			WorldModelRenderer.RenderType = ModelRenderer.ShadowRenderType.On;

			IsReloading = false;
			IsScoping = false;
			IsAiming = false;
			IsCustomizing = false;
			DestroyUI();
		}
		WorldModelRenderer.BoneMergeTarget = null;
		Owner = null;
	}

	public bool CanCarryStop()
	{
		return TimeSinceDeployed > 0;
	}


	public void OnDeploy()
	{
		
		var delay = 0f;

		
		

		delay = DrawTime;

		TimeSinceDeployed = -delay;

		// Sound
		if ( DeploySound is not null )
			PlaySound( DeploySound.ResourceId );


		// Boltback
		if ( InBoltBack )
			AsyncBoltBack( delay );
	}


	void SetupModels()
	{

		OnDeploy();
		
		foreach (Attachment att in Attachments) { att.RefreshView(); }


		var bodyRenderer = Owner.Body.Components.Get<SkinnedModelRenderer>();
		WorldModelRenderer.BoneMergeTarget = bodyRenderer;
		Network.ClearInterpolation();
	}



	protected override void OnStart()
	{
		if ( IsProxy )
		{
			
			Attachments.ForEach( att =>
			{
				if ( att is not null && att.Equipped )
					att.Equip();
			} );
		}
	}

	protected override void OnUpdate()
	{
		if (Owner == null) return;

		UpdateModels();



		Owner.ApplyFov( targetPlayerFOV - Preferences.FieldOfView );

		targetPlayerFOV = Preferences.FieldOfView;

		if ( IsAiming && !IsReloading )
		{
			var speedMod = 1f;

			animSpeed = 10 * AnimSpeed * speedMod;

			if ( AimPlayerFOV > 0 )
				targetPlayerFOV = AimPlayerFOV;

			if ( AimFOV > 0 )
				targetPlayerFOV = Preferences.FieldOfView - AimFOV;

			playerFOVSpeed = AimInFOVSpeed;

		}
		else
		{
			targetPlayerFOV = Preferences.FieldOfView;

			if ( finalPlayerFOV != AimPlayerFOV )
			{
				playerFOVSpeed = AimOutFOVSpeed;
			}
		}

		if ( !IsProxy )
		{
			if ( IsDeploying ) return;

			// Customization
			if ( !IsScoping && !IsAiming && Input.Pressed( InputButtonHelper.Castomization ) && Attachments.Count > 0 )
			{
				if ( !IsCustomizing )
					OpenCustomizationMenu();
				else
					CloseCustomizationMenu();

				IsCustomizing = !IsCustomizing;
			}

			// Don't cancel reload when customizing
			if ( IsCustomizing && !IsReloading ) return;

			IsAiming = !Owner.IsRunning && Input.Down( InputButtonHelper.SecondaryAttack );

			if ( IsScoping )
				Owner.InputSensitivity = ScopeInfo.AimSensitivity;
			else if ( IsAiming )
				Owner.InputSensitivity = AimSensitivity;

			ResetBurstFireCount( Primary, InputButtonHelper.PrimaryAttack );
			ResetBurstFireCount( Secondary, InputButtonHelper.SecondaryAttack );
			BarrelHeatCheck();

			var shouldTuck = ShouldTuck();

			if ( CanPrimaryShoot() && !shouldTuck )
			{
				if ( IsReloading && ShellReloading && ShellReloadingShootCancel )
					CancelShellReload();

				TimeSincePrimaryShoot = 0;
				Shoot( Primary, true );
			}
			else if ( CanSecondaryShoot() && !shouldTuck )
			{
				TimeSinceSecondaryShoot = 0;
				Shoot( Secondary, false );
			}
			else if ( Input.Down( InputButtonHelper.Reload ) )
			{
				if ( ShellReloading )
					OnShellReload();
				else
					Reload();
			}

			if ( IsReloading && TimeSinceReload >= 0 )
			{
				if ( ShellReloading )
					OnShellReloadFinish();
				else
					OnReloadFinish();
			}
		}
	}

	void UpdateModels()
	{

		if ( !IsProxy && WorldModelRenderer is not null )
		{
			WorldModelRenderer.RenderType = Owner.IsFirstPerson ? ModelRenderer.ShadowRenderType.ShadowsOnly : ModelRenderer.ShadowRenderType.On;
		}
	}

	[Broadcast]
	void PlaySound( int resourceID )
	{
		var sound = ResourceLibrary.Get<SoundEvent>( resourceID );
		if ( sound is null ) return;

		var isScreenSound = CanSeeViewModel;
		sound.UI = isScreenSound;

		if ( isScreenSound )
		{
			Sound.Play( sound );
		}
		else
		{
			Sound.Play( sound, Transform.Position );
		}
	}
}
