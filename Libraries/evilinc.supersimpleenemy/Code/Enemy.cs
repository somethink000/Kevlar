using Sandbox;

public sealed class Enemy : Component
{

	[RequireComponent] NavMeshAgent agent { get; set; }

	[Property] GameObject target { get; set; }


	//REMEMBER TO TURN ON NAVMESH ON SCENE
	protected override void OnUpdate()
	{
		if ( target != null )
		{
			agent.MoveTo( target.Transform.Position );
		}
	}
}
