
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
	[RequireComponent] private Player ply { get; set; }
	private CameraComponent Camera => ply.Camera;


	protected override void OnAwake()
	{
		base.OnAwake();
	}

	private void UpdateModelVisibility()
	{

		if ( !ModelRenderer.IsValid() )
			return;

		//damn this shit works
		if ( IsProxy ) Camera.Enabled = false;


		ModelRenderer.SetBodyGroup( "head", IsProxy ? 0 : 1 );
	}
	protected override void OnPreRender()
	{
		base.OnPreRender();

		if ( !Scene.IsValid() || !Camera.IsValid() )
			return;

		UpdateModelVisibility();

	}

}

