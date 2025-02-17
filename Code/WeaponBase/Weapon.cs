﻿
using GeneralGame.UI;
using Sandbox;
using System.Collections.Generic;
using System.Linq;
using static GeneralGame.UI.FullScreenManager;

namespace GeneralGame;

public partial class Weapon : Component
{
	public PlayerBase Owner { get; set; }
	public ViewModelHandler ViewModelHandler { get; private set; }
	public SkinnedModelRenderer ViewModelRenderer { get; private set; }
	public SkinnedModelRenderer ViewModelHandsRenderer { get; private set; }
	public SkinnedModelRenderer WorldModelRenderer { get; private set; }
	public WeaponSettings Settings { get; private set; }
	public List<Attachment> Attachments = new();


	protected override void OnAwake()
	{
		Attachments = Components.GetAll<Attachment>( FindMode.EverythingInSelf ).OrderBy( att => att.Name ).ToList();

		WorldModelRenderer = Components.GetInDescendantsOrSelf<SkinnedModelRenderer>();
		Settings = WeaponSettings.Instance;
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
		if ( Owner == null ) return;

		UpdateModels();
		Owner.AnimationHelper.HoldType = HoldType;

		ViewModelRenderer?.Set( EmptyState, IsEmpty );

		if ( !IsReloading && !InBoltBack )
		{
			ViewModelRenderer?.Set( AimState, IsAiming );
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

			if ( !IsScoping && !IsAiming && Input.Pressed( InputButtonHelper.Inspect ) )
			{
				ViewModelRenderer?.Set( InspectAnim, true );
			}

			if ( !IsScoping && !IsAiming && Input.Pressed( InputButtonHelper.Mode ) )
			{
				ViewModelRenderer?.Set( ModeAnim, true );
			}

			// Don't cancel reload when customizing
			if ( IsCustomizing && !IsReloading ) return;

			IsAiming = !Owner.IsRunning && AimAnimData != AngPos.Zero && Input.Down( InputButtonHelper.SecondaryAttack );

			if ( IsScoping )
				Owner.InputSensitivity = ScopeInfo.AimSensitivity;
			else if ( IsAiming )
				Owner.InputSensitivity = AimSensitivity;

			if ( Scoping )
			{
				if ( IsAiming && !IsScoping )
					OnScopeStart();
				else if ( !IsAiming && IsScoping )
					OnScopeEnd();
			}

			ResetBurstFireCount( InputButtonHelper.PrimaryAttack );


			var shouldTuck = ShouldTuck();

			if ( Input.Down( InputButtonHelper.Reload ) )
			{
				if ( ShellReloading )
					StartShellReload();
				else
					Reload();
			}


			if ( Input.Down( InputButtonHelper.PrimaryAttack ) )
			{
				
				Shoot();
			}

		}
	}

	[Rpc.Broadcast]
	public void Deploy(PlayerBase player)
	{
		Owner = player;
		IsDeploying = true;
		GameObject.Enabled = true;

		SetupModels();

		if ( IsProxy ) return;

		CreateUI();

		SetupAnimEvents();


		ViewModelRenderer?.Set( IsReady ? DeployAnim : ReadyAnim, true );
		
	}

	private void SetupAnimEvents()
	{
		
		ViewModelRenderer.OnGenericEvent = ( a ) =>
		{
			string t = a.Type;

			switch( t )
			{
			case "reload_end":

				if ( !ShellReloading )
				{
					OnReloadFinish();
				}
				else
				{
					IsReloading = false;
				}

				break;

			case "pump_end":

				InBoltBack = false;

				break;

			case "eject_shell":

				CreateParticle( BulletEjectParticle, "ejection_point", VMParticleScale );

				break;

			case "shell_insert":

				ShellReload();

				break;

			case "deployed":

				if ( !IsReady ) IsReady = true;
				IsDeploying = false;

				break;

			case "holstered":

				EndHolster();

				break;

			}

		};
	}
	public bool CanHolster()
	{

		if ( IsShooting() || InBoltBack || IsHolstering || IsDeploying || IsReloading ) return false;
		return true;
	}
	public void Holster()
	{
		IsHolstering = true;
		ViewModelRenderer?.Set( HolsterAnim, true );
	}

	[Rpc.Broadcast]
	public void EndHolster()
	{
		IsHolstering = false;
		GameObject.Enabled = false;

		if ( !IsProxy ) { 

			ViewModelHandler.OnHolster();

			WorldModelRenderer.RenderType = ModelRenderer.ShadowRenderType.On;
			ViewModelRenderer.GameObject.Destroy();
			ViewModelHandler = null;
			ViewModelRenderer = null;
			ViewModelHandsRenderer = null;

			IsReloading = false;
			IsScoping = false;
			IsAiming = false;
			IsCustomizing = false;
			DestroyUI();
		} 

		Owner.Inventory.ChangeSlot();
		Owner = null;

	}


	void SetupModels()
	{

		if ( !IsProxy && ViewModel is not null && ViewModelRenderer is null )
		{

			var viewModelGO = new GameObject( true, "Viewmodel" );
			viewModelGO.SetParent( Owner.GameObject, false );
			viewModelGO.Tags.Add( TagsHelper.ViewModel );
			viewModelGO.Flags |= GameObjectFlags.NotNetworked;

			ViewModelRenderer = viewModelGO.Components.Create<SkinnedModelRenderer>();
			ViewModelRenderer.Model = ViewModel;
			ViewModelRenderer.AnimationGraph = ViewModel.AnimGraph;
			ViewModelRenderer.CreateBoneObjects = true;
			ViewModelRenderer.Enabled = false;
			ViewModelRenderer.OnComponentEnabled += () =>
			{
				// Prevent flickering when enabling the component, this is controlled by the ViewModelHandler
				
				ViewModelRenderer.RenderType = ModelRenderer.ShadowRenderType.ShadowsOnly;
				// Start drawing
				ViewModelHandler.ShouldDraw = true;
			};

			ViewModelHandler = viewModelGO.Components.Create<ViewModelHandler>();
			ViewModelHandler.Weapon = this;
			ViewModelHandler.ViewModelRenderer = ViewModelRenderer;
			ViewModelHandler.Camera = Owner.Camera;

			if ( ViewModelHands is not null )
			{
				ViewModelHandsRenderer = viewModelGO.Components.Create<SkinnedModelRenderer>();
				ViewModelHandsRenderer.Model = ViewModelHands;
				ViewModelHandsRenderer.BoneMergeTarget = ViewModelRenderer;
				ViewModelHandsRenderer.OnComponentEnabled += () =>
				{
					// Prevent flickering when enabling the component, this is controlled by the ViewModelHandler
					ViewModelHandsRenderer.RenderType = ModelRenderer.ShadowRenderType.ShadowsOnly;
				};
			}

			ViewModelHandler.ViewModelHandsRenderer = ViewModelHandsRenderer;
			
			foreach (Attachment att in Attachments) { att.RefreshView(); }
		}



		var bodyRenderer = Owner.Body.Components.Get<SkinnedModelRenderer>();
		ModelUtil.ParentToBone( GameObject, bodyRenderer, "hold_R" );
		Network.ClearInterpolation();
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
		if ( !IsValid ) return;

		var sound = ResourceLibrary.Get<SoundEvent>( resourceID );
		if ( sound is null ) return;

		var isScreenSound = CanSeeViewModel;
		sound.UI = isScreenSound;

		if ( isScreenSound )
		{
			sound.Volume = 0.7f;
			Sound.Play( sound );
		}
		else
		{
			Sound.Play( sound, Transform.Position );
		}
	}
}
