

using Sandbox.Citizen;

namespace GeneralGame;

public partial class BaseSeat : Component
{
	public PlayerBase Owner {  get; set; }
	public bool Empty = true;


	protected override void OnUpdate()
	{
		base.OnUpdate();

		if ( !Empty ) { 
			Owner.AnimationHelper.IsSitting = true;
			Owner.AnimationHelper.Sitting = CitizenAnimationHelper.SittingStyle.Chair;
		}
	}

	public virtual void AttachOwner( PlayerBase ply )
	{
		
		ply.Body.Components.Get<CapsuleCollider>( FindMode.InSelf ).Enabled = false;

		ply.GameObject.Parent = this.GameObject;
		
		ply.GameObject.Transform.Position = Transform.Position;
		Owner = ply;
		Empty = false;
		OnEnter();
	}

	public virtual void OnEnter() { }

	public virtual void DetachOwner( )
	{
		Owner.GameObject.Parent = null;
		Owner.Distance = 0;
		Owner.Body.Components.Get<CapsuleCollider>( FindMode.InSelf ).Enabled = true;

		Owner.AnimationHelper.IsSitting = false;
		Owner.AnimationHelper.Sitting = CitizenAnimationHelper.SittingStyle.None;
		Empty = true;
		OnExit();

		Owner = null;
		
		
	}
	public virtual void OnExit() { }
}

