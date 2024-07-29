

using System.Diagnostics;
using static Sandbox.CursorSettings;

namespace GeneralGame;


public partial class PlayerBase
{
	[Property] public float Distance { get; set; } = 0f;

	public float CurFOV { get; set; }
	public float TargetFov { get; set; } = 0;


	public Rotation ZeroRotation { get; set; }
	public Angles RotationMultyplier { get; set; }
	public Rotation TargetRotation { get; set; }


	public float InputSensitivity { get; set; } = 1f;
	public Angles EyeAnglesOffset { get; set; }

	public bool IsFirstPerson => Distance == 0f;
	private float fovSpeed = 5f;

	public void OnCameraAwake() 
	{
		CurFOV = Preferences.FieldOfView;
	}

	public void ApplyFov( float multiplyer )
	{
		TargetFov += multiplyer;
	}


	private void HandleCameraRotation()
	{
	
		Camera.Transform.Rotation = ZeroRotation;
	}

	private void HandleCameraFov()
	{
		CurFOV = MathX.LerpTo( CurFOV, TargetFov, fovSpeed * RealTime.Delta );
		
		TargetFov = Preferences.FieldOfView;


		Camera.FieldOfView = CurFOV;
	}


	public void OnCameraUpdate()
	{
		if ( IsProxy ) return;


		ApplyFov( Velocity.WithZ( 0 ).Length / 40 );


		// Rotate the head based on mouse movement
		var eyeAngles = EyeAngles;

		Input.AnalogLook *= InputSensitivity;
		eyeAngles.pitch += Input.AnalogLook.pitch;
		eyeAngles.yaw += Input.AnalogLook.yaw;
		eyeAngles += EyeAnglesOffset;
		EyeAnglesOffset = Angles.Zero;
		InputSensitivity = 1;

		eyeAngles.roll = 0;
		eyeAngles.pitch = eyeAngles.pitch.Clamp( -89.9f, 89.9f );

		EyeAngles = eyeAngles;

		// Set the current camera offset
		var targetOffset = Vector3.Zero;
		if ( IsCrouching ) targetOffset += Vector3.Down * 32f;
		EyeOffset = Vector3.Lerp( EyeOffset, targetOffset, Time.Delta * 10f );

		// Set position of the camera
		if ( Scene.Camera is not null )
		{
			var camPos = EyePos;
			if ( !IsFirstPerson )
			{
				// Perform a trace backwards to see where we can safely place the camera
				var camForward = eyeAngles.ToRotation().Forward;
				var camTrace = Scene.Trace.Ray( camPos, camPos - (camForward * Distance) )
					.WithoutTags( TagsHelper.Player, TagsHelper.Trigger, TagsHelper.ViewModel, TagsHelper.Weapon )
					.Run();

				if ( camTrace.Hit )
				{
					// Add normal to prevent clipping
					camPos = camTrace.HitPosition + camTrace.Normal;
				}
				else
				{
					camPos = camTrace.EndPosition;
				}
			}

			// Set the position of the camera to our calculated position


			ZeroRotation = eyeAngles.ToRotation();

			HandleCameraRotation();
			HandleCameraFov();


			
			Camera.Transform.Position = camPos;

		}
	
	}
}
