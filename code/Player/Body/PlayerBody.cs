
using System;
using System.Collections.Generic;
using System.Linq;
using Sandbox;
using Sandbox.Citizen;
using static Sandbox.PhysicsContact;

namespace GeneralGame;

//Body visability shit 
public class PlayerBody : Component
{
	[Property] public SkinnedModelRenderer ModelRenderer { get; private set; }
	private Player ply { get; set; }
	private CameraComponent Camera { get; set; }
	private PlayerController Controller { get; set; }


	protected override void OnAwake()
	{
		base.OnAwake();
		ply = GameObject.Components.Get<Player>();
		Camera = ply.CameraController.Camera;
		Controller = ply.Controller;
	}

	private void UpdateModelVisibility()
	{

		if ( !ModelRenderer.IsValid() )
			return;

		//damn this shit works
		if ( IsProxy ) Camera.Enabled = false;

		
		//ModelRenderer.SetBodyGroup( "head", 0 );
		//ModelRenderer.SetBodyGroup( "head", IsProxy ? 0 : 1 );
		//ModelRenderer.Enabled = true;
	}
	protected override void OnPreRender()
	{
		base.OnPreRender();

		if ( !Scene.IsValid() || !Camera.IsValid() )
			return;

		UpdateModelVisibility();

	}

}

