using System;
using System.Linq;
using Sandbox;
using static Sandbox.PhysicsContact;
namespace GeneralGame;

[GameResource( "ItemSpawns", "spawn", "Grooup of items to spawn." )]
public partial class ItemSpawnGroup : GameResource
{
	[Property] public List<PrefabFile> SpawnableItems { get; set; }
}


public sealed class ItemSpawn : Component
{
	[Property] public ItemSpawnGroup SpawnableGroup { get; set; }

	protected override void OnAwake()
	{
		base.OnAwake();

	
		PrefabFile prefab = SpawnableGroup.SpawnableItems.Shuffle()[0];
		var zombie = SceneUtility.GetPrefabScene( prefab ).Clone( this.Transform.World );
		zombie.NetworkSpawn();
		GameObject.Destroy();
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
