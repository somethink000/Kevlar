
namespace GeneralGame
{
	public partial class BaseGame : Component
	{
		[Property] public bool InfiniteAmmo { get; set; } = false;
		//[Property] public bool InfiniteAmmo => false;

		public virtual void InitPlayer( PlayerBase player )
		{

		
		}

		[Rpc.Broadcast]
		public virtual void ChangeGame( )
		{
			
		}

		public virtual void OnPlayerDeath( PlayerBase player, PlayerBase killer = null )
		{


		}

		//public void Notificate(string message)
		//{
		//	UI.GameState.Instance.RockNotificate( message );
		//}
		public virtual void OnZombieKilled( PlayerBase ply )
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
