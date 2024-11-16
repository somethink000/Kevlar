

namespace GeneralGame;

public sealed class Vehicle : Component
{
	[RequireComponent] public Rigidbody Rigidbody { get; set; }
	[Property] public VehicleCamera CameraController { get; set; }

	[Property] public float Torque { get; set; } = 20000f;

	private List<Wheel> _wheels;

	[Property] public List<GameObject> frontWheels { get; set; }
	[Property] public List<GameObject> PasangerSeats { get; set; }
	[Property] public BaseSeat DriverSeat { get; set; }
	[Property] public float MaxSteeringAngle { get; set; } = 20f;
	[Property] public float SteeringSmoothness { get; set; } = 10f;
	public PlayerBase Driver { get; set; }

	private float _currentTorque = 0;

	protected override void OnEnabled()
	{
		_wheels = Components.GetAll<Wheel>( FindMode.EverythingInSelfAndDescendants ).ToList();
	}


	/*protected override void OnFixedUpdate()
	{
		
	}
*/
	protected override void OnStart()
	{
		var interactions = Components.GetOrCreate<Interactions>();
		interactions.AddInteraction( new Interaction()
		{
			Action = ( PlayerBase interactor, GameObject obj ) => PlayerEnter( interactor ),
			Keybind = "use",
			Description = "Enter",
			Disabled = () => Driver != null,
			ShowWhenDisabled = () => true,
			Accessibility = AccessibleFrom.World,
			Cooldown = true,

		} );
	}


	public void SteerCarUpdate()
	{
		


		float verticalInput = Input.AnalogMove.x;
		float targetTorque = verticalInput * Torque;

		bool isBraking = (targetTorque < 0f);
		float lerpRate = isBraking ? 5.0f : 1.0f; // Brake applies quicker

		_currentTorque = _currentTorque.LerpTo( targetTorque, lerpRate * Time.Delta );
		_currentTorque = _currentTorque.Clamp( -50000, float.MaxValue );

		
		foreach ( Wheel wheel in _wheels )
		{
			wheel.ApplyMotorTorque( _currentTorque );
		}


		foreach ( var wheel in frontWheels )
		{
			var targetRotation = Rotation.FromYaw( MaxSteeringAngle * Input.AnalogMove.y );
			wheel.Transform.LocalRotation = Rotation.Lerp( wheel.Transform.LocalRotation, targetRotation, Time.Delta * SteeringSmoothness );
		}

		if ( Input.Pressed( InputButtonHelper.Use ) )
		{
			PlayerExit( Driver );
		}
	}

	public void PlayerEnter( PlayerBase ply )
	{
		DriverSeat.AttachOwner(ply);

		ply.Vehicle = this;
		Driver = ply;
	}

	public void PlayerExit( PlayerBase ply )
	{
		
		
		DriverSeat.DetachOwner( );

		ply.Vehicle = null;
		Driver = null;
	}
}
