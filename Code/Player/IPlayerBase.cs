using Sandbox.Citizen;
using System;

namespace GeneralGame;

public interface IPlayerBase : IValid
{
	public CameraComponent Camera { get; set; }
	public GameObject Body { get; set; }
	public SkinnedModelRenderer BodyRenderer { get; set; }
	public CharacterController CharacterController { get; set; }
	public CitizenAnimationHelper AnimationHelper { get; set; }
	public GameObject GameObject { get; }
	public Inventory Inventory { get; set; }
	public bool IsFirstPerson { get; }
	public Vector3 Velocity { get; }
	public bool IsCrouching { get; set; }
	public bool IsRunning { get; set; }
	public bool IsOnGround { get; }
	public bool IsAlive { get; }
	public int Kills { get; set; }
	public int Deaths { get; set; }
	public Guid Id { get; }

	/// <summary>Input sensitivity modifier</summary>
	public float InputSensitivity { get; set; }

	/// <summary>EyeAngles offset (should reset after being applied)</summary>
	public Angles EyeAnglesOffset { get; set; }

	/// <summary>View angles</summary>
	public Angles EyeAngles { get; set; }

	/// <summary>View position</summary>
	public Vector3 EyePos { get; }
}
