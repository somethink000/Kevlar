

namespace GeneralGame;

public class DefenceObject : Component, IHealthComponent
{
	[Sync, Property] public float MaxHealth { get; set; } = 100f;
	[Sync] public LifeState LifeState { get; private set; } = LifeState.Alive;
	[Sync] public float Health { get; private set; } = 100f;


	[Broadcast]
	public virtual void TakeDamage( DamageType type, float damage, Vector3 position, Vector3 force, Guid attackerId, string[] hitboxes )
	{
		if ( IsProxy || LifeState == LifeState.Dead )
			return;

		var attacker = Scene.Directory.FindByGuid( attackerId );

		Health -= damage;


		if ( Health <= 0 )
		{
			LifeState = LifeState.Dead;
		
		}
	}
}
