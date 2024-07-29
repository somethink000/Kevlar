
namespace GeneralGame
{
	public partial class BaseGame : Component
	{
		
		public virtual int TimerValue { get; set; }
		public virtual int CountValue { get; set; }
		public virtual int SecondCountValue { get; set; }


		public virtual void InitPlayer( PlayerBase player )
		{

		
		}

		public void Notificate(string message)
		{
			UI.GameState.Instance.RockNotificate( message );
		}
		public virtual void OnZombieKilled()
		{

		
		}


		protected override void DrawGizmos()
		{
			const float boxSize = 4f;
			var bounds = new BBox( Vector3.One * -boxSize, Vector3.One * boxSize );

			Gizmo.Hitbox.BBox( bounds );

			Gizmo.Draw.Color = Color.Cyan.WithAlpha( (Gizmo.IsHovered || Gizmo.IsSelected) ? 0.5f : 0.2f );
			Gizmo.Draw.LineBBox( bounds );
			Gizmo.Draw.SolidBox( bounds );

			Gizmo.Draw.Color = Color.Cyan.WithAlpha( (Gizmo.IsHovered || Gizmo.IsSelected) ? 0.8f : 0.6f );
		}
	}
}
