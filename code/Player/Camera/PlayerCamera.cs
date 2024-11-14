using System;
using System.Collections.Generic;
using System.Linq;
using Sandbox;
using Sandbox.Citizen;

namespace GeneralGame;

//Camera moves 
public class PlayerCamera : Component
{
	[RequireComponent] private Player ply { get; set; }

	[Property] public bool SicknessMode { get; set; }

	[Sync] public Angles EyeAngles { get; set; }

	private Vector3 SieatOffset => new Vector3( 0f, 0f, -40f );

	
	public void ResetViewAngles()
	{
		var rotation = Rotation.Identity;
		EyeAngles = rotation.Angles().WithRoll( 0f );
	}

	protected override void OnAwake()
	{
		base.OnAwake();

		if ( IsProxy )
			return;

		ResetViewAngles();
	}
	
	protected override void OnPreRender()
	{
		base.OnPreRender();

		if ( !Scene.IsValid() || !ply.Camera.IsValid() )
			return;

		if ( IsProxy )
			return;

		if ( !ply.Camera.IsValid() )
			return;

		if ( ply.Ragdoll.IsRagdolled )
		{
			ply.Camera.Transform.Position = ply.Camera.Transform.Position.LerpTo( ply.Camera.Transform.Position, Time.Delta * 32f );
			ply.Camera.Transform.Rotation = Rotation.Lerp( ply.Camera.Transform.Rotation, ply.Camera.Transform.Rotation, Time.Delta * 16f );
			return;
		}


		var idealEyePos = ply.Camera.Transform.Position;
		var headPosition = Transform.Position + Vector3.Up * ply.Controller.CC.Height;
		var headTrace = Scene.Trace.Ray( Transform.Position, headPosition )
			.UsePhysicsWorld()
			.IgnoreGameObjectHierarchy( GameObject )
			.WithAnyTags( "solid" )
			.Run();

		headPosition = headTrace.EndPosition - headTrace.Direction * 2f;

		var trace = Scene.Trace.Ray( headPosition, idealEyePos )
			.UsePhysicsWorld()
			.IgnoreGameObjectHierarchy( GameObject )
			.WithAnyTags( "solid" )
			.Radius( 2f )
			.Run();

		var deployedWeapon = ply.Weapons.Deployed;
		
		ply.Camera.Transform.Position = trace.Hit ? trace.EndPosition : idealEyePos;

		if ( SicknessMode )
			ply.Camera.Transform.Rotation = Rotation.LookAt( ply.Camera.Transform.Rotation.Left ) * Rotation.FromPitch( -10f );
		else
			ply.Camera.Transform.Rotation = EyeAngles.ToRotation() * Rotation.FromPitch( -10f );


		//if ( ply.Controller.IsCrouching && hasViewModel )
		//{
		//	Camera.Transform.Position = Camera.Transform.Position + SieatOffset;
		//}
	}

	
	protected override void OnUpdate()
	{
		if ( ply.Ragdoll.IsRagdolled || ply.LifeState == LifeState.Dead )
			return;

		if ( !IsProxy )
		{
			var angles = EyeAngles.Normal;
			angles += Input.AnalogLook * 0.5f;
			angles.pitch = angles.pitch.Clamp( -60f, 80f );

			EyeAngles = angles.WithRoll( 0f );
		}
	}
}

