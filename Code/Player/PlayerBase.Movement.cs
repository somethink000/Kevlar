using Sandbox.Citizen;


namespace GeneralGame;

public partial class PlayerBase
{

	[Property] public float BaseGroundControl { get; set; } = 4.0f;
	[Property] public float AirControl { get; set; } = 0.1f;
	[Property] public float MaxForce { get; set; } = 50f;
	[Property] public float RunSpeed { get; set; } = 290f;
	[Property] public float WalkSpeed { get; set; } = 160f;
	[Property] public float CrouchSpeed { get; set; } = 90f;
	[Property] public float JumpForce { get; set; } = 350f;
	[Property, Group( "Sounds" )] public SoundEvent SlideSound { get; set; }


	[Sync] public Vector3 WishVelocity { get; set; } = Vector3.Zero;
	[Sync] public Angles EyeAngles { get; set; }
	[Sync] public Vector3 EyeOffset { get; set; } = Vector3.Zero;
	[Sync] public bool IsCrouching { get; set; } = false;
	[Sync] public bool IsRunning { get; set; } = false;
	[Sync] public bool IsSlide { get; set; } = false;
	[Sync] public bool IsGrounded { get; set; } = false;


	private float GroundControl { get; set; }
	public bool IsOnGround => CharacterController.IsOnGround;
	public Vector3 Velocity => CharacterController.Velocity;
	public Vector3 EyePos => Head.Transform.Position + EyeOffset;

	public CharController CharacterController { get; set; }
	public CitizenAnimationHelper AnimationHelper { get; set; }
	public CapsuleCollider BodyCollider { get; set; }

	TimeSince timeSinceLastFootstep = 0;
	
	float fallVelocity = 0;	

	void OnMovementAwake()
	{
		GroundControl = BaseGroundControl;

		CharacterController = Components.Get<CharController>();
		AnimationHelper = Components.Get<CitizenAnimationHelper>();
		BodyCollider = Body.Components.Get<CapsuleCollider>();

		if ( BodyRenderer is not null )
			BodyRenderer.OnFootstepEvent += OnAnimEventFootstep;
	}

	void OnMovementUpdate()
	{
		
		if ( !IsProxy )
		{
			IsRunning = Input.Down( InputButtonHelper.Run );

			if ( Input.Pressed( InputButtonHelper.Jump ) )
				Jump();

			UpdateCrouch();
		}

		RotateBody();
		UpdateAnimations();
		
	}

	void OnMovementFixedUpdate()
	{
		if ( IsProxy ) return;
		BuildWishVelocity();
		Move();
	}

	void BuildWishVelocity()
	{

		

			WishVelocity = 0;
			
			var rot = EyeAngles.ToRotation();
			if ( Input.Down( InputButtonHelper.Forward ) ) WishVelocity += rot.Forward;
			if ( Input.Down( InputButtonHelper.Backward ) ) WishVelocity += rot.Backward;
			if ( Input.Down( InputButtonHelper.Left ) ) WishVelocity += rot.Left;
			if ( Input.Down( InputButtonHelper.Right ) ) WishVelocity += rot.Right;


		if ( !IsSlide )
		{
			WishVelocity = WishVelocity.WithZ( 0 );
			if ( !WishVelocity.IsNearZeroLength ) WishVelocity = WishVelocity.Normal;

			if ( IsCrouching ) WishVelocity *= CrouchSpeed;
			else if ( IsRunning ) WishVelocity *= RunSpeed;
			else WishVelocity *= WalkSpeed;
		}
		else
		{
			//Log.Info( SlideVelocity.Length );
			//CharacterController.ApplyFriction(-3f);
			//SlideVelocity = Vector3.Lerp( SlideVelocity, Vector3.Zero, Time.Delta * 0.5f );
			//WishVelocity = SlideVelocity;
		
			if ( Velocity.Length < 200 ) SlideEnd();
			
		}


	}

	private void OnGrounded()
	{
		if ( fallVelocity > 650)
		{
			var damage = new DamageInfo( fallVelocity / 10, GameObject, GameObject );
			
			OnDamage( damage );
					}
		fallVelocity = 0;
	}

	
	void Move()
	{
		var gravity = Scene.PhysicsWorld.Gravity;

		if ( IsOnGround )
		{
			// Friction / Acceleration
			CharacterController.Velocity = CharacterController.Velocity.WithZ( 0 );
			CharacterController.Accelerate( WishVelocity );
			CharacterController.ApplyFriction( GroundControl );
			
			if ( !IsGrounded ) {
				OnGrounded();
				
				IsGrounded = true;
			}
		}
		else
		{
			// Air control / Gravity
			CharacterController.Velocity += gravity * Time.Delta * 0.5f;
			CharacterController.Accelerate( WishVelocity.ClampLength( MaxForce ) );
			CharacterController.ApplyFriction( AirControl );
			IsGrounded = false;
			fallVelocity = CharacterController.Velocity.WithY( 0 ).Length;
		}

		if ( !(CharacterController.Velocity.IsNearZeroLength && WishVelocity.IsNearZeroLength) )
			CharacterController.Move();

		// Second half of gravity after movement (to stay accurate)
		if ( IsOnGround )
		{
			CharacterController.Velocity = CharacterController.Velocity.WithZ( 0 );
		}
		else
		{
			CharacterController.Velocity += gravity * Time.Delta * 0.5f;
		}
	}

	void RotateBody()
	{
		var targetRot = new Angles( 0, EyeAngles.ToRotation().Yaw(), 0 ).ToRotation();
		float rotateDiff = Body.Transform.Rotation.Distance( targetRot );

		if ( rotateDiff > 20f || CharacterController.Velocity.Length > 10f )
		{
			Body.Transform.Rotation = Rotation.Lerp( Body.Transform.Rotation, targetRot, Time.Delta * 2f );
		}
	}

	void Jump()
	{
		if ( !IsOnGround ) return;
		if ( IsSlide ) SlideEnd();

		CharacterController.Punch( Vector3.Up * JumpForce );
		AnimationHelper?.TriggerJump();
	}

	void UpdateAnimations()
	{
		if ( AnimationHelper is null ) return;

		AnimationHelper.WithWishVelocity( WishVelocity );
		AnimationHelper.WithVelocity( CharacterController.Velocity );
		AnimationHelper.AimAngle = EyeAngles.ToRotation();
		AnimationHelper.IsGrounded = IsOnGround;
		AnimationHelper.WithLook( EyeAngles.ToRotation().Forward, 1f, 0.75f, 0.5f );
		AnimationHelper.MoveStyle = CitizenAnimationHelper.MoveStyles.Run;
		AnimationHelper.DuckLevel = IsCrouching ? 1 : 0;
		AnimationHelper.SpecialMove = IsSlide ? CitizenAnimationHelper.SpecialMoveStyle.Slide : CitizenAnimationHelper.SpecialMoveStyle.None;

	}

	private void Slide()
	{
		Sound.Play( SlideSound, WorldPosition );
		GroundControl = 0.5f;
		CharacterController.Height /= 2f;
		BodyCollider.End = BodyCollider.End.WithZ( BodyCollider.End.z / 2f );
		IsSlide = true;
	}
	private void SlideEnd()
	{
		GroundControl = BaseGroundControl;
		IsSlide = false;
		
		var targetHeight = CharacterController.Height * 2f;
		var upTrace = CharacterController.TraceDirection( Vector3.Up * targetHeight );

		if ( !upTrace.Hit )
		{
			IsCrouching = false;
			CharacterController.Height = targetHeight;
			BodyCollider.End = BodyCollider.End.WithZ( BodyCollider.End.z * 2f );
		}else
		{
			IsCrouching = true;
		}
	}

	void UpdateCrouch()
	{
		if ( IsSlide ) return;

		if ( Input.Down( InputButtonHelper.Duck ) && !IsCrouching && IsOnGround )
		{
			
			if ( Velocity.Length <= 200 )
			{
				IsCrouching = true;
				CharacterController.Height /= 2f;
				BodyCollider.End = BodyCollider.End.WithZ( BodyCollider.End.z / 2f );
			} else
			{
				Slide();
			}	
		}

		if ( IsCrouching && (!Input.Down( InputButtonHelper.Duck ) || !IsOnGround) )
		{
			// Check we have space to uncrouch
			var targetHeight = CharacterController.Height * 2f;
			var upTrace = CharacterController.TraceDirection( Vector3.Up * targetHeight );

			if ( !upTrace.Hit )
			{
				IsCrouching = false;
				CharacterController.Height = targetHeight;
				BodyCollider.End = BodyCollider.End.WithZ( BodyCollider.End.z * 2f );
			}
		}
	}

	void OnAnimEventFootstep( SceneModel.FootstepEvent footstepEvent )
	{
		if ( !IsAlive || !IsOnGround ) return;

		// Walk
		var stepDelay = 0.25f;

		// Running
		if ( Velocity.WithZ( 0 ).Length >= 200 )
		{
			stepDelay = 0.2f;
		}
		// Crouching
		else if ( IsCrouching )
		{
			stepDelay = 0.4f;
		}

		if ( timeSinceLastFootstep < stepDelay )
			return;

		var tr = Scene.Trace.Ray( footstepEvent.Transform.Position, footstepEvent.Transform.Position + Vector3.Down * 20 )
			.Radius( 1 )
			.IgnoreGameObject( this.GameObject )
			.Run();

		if ( !tr.Hit ) return;

		var sound = tr.Surface.PlayCollisionSound( footstepEvent.Transform.Position );
		if ( sound is not null ) { 
			if (!IsProxy) { 
				sound.Volume = 0.1f;
			}else
			{
				sound.Volume = footstepEvent.Volume;
			}
		}

		timeSinceLastFootstep = 0;
	}
}
