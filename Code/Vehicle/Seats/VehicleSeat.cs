
namespace GeneralGame;

public class VehicleSeat : BaseSeat
{
	[Property] GameObject ExitPoint;
	public override void OnEnter()
	{
		base.OnEnter();
		//	Owner.AnimationHelper.AimBodyWeight = 0.2f;
		//Log.Info( Transform.Rotation.Forward );
		Owner.AnimationHelper.WithLook( Transform.Rotation.Forward, 1f, 0.75f, 0.5f );
		Owner.Distance = 200;
	}


	public override void OnExit()
	{
		base.OnExit();
		Owner.GameObject.Transform.Position = ExitPoint.Transform.Position;
		Owner.Distance = 0;
	}
}
