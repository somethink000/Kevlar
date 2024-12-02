

namespace GeneralGame;

public class DefenceObject : Component, IHealthComponent
{
	[Sync, Property] public float MaxHealth { get; set; } = 100f;
	[Sync] public LifeState LifeState { get; private set; } = LifeState.Alive;
	[Sync] public float Health { get; private set; } = 100f;

	public void OnDamage( in DamageInfo damage )
	{
		if ( IsProxy || LifeState == LifeState.Dead )
			return;

		if ( damage.Attacker.Components.GetInAncestorsOrSelf<Zombie>() is Zombie zmb )
		{
			//ply.CurrentGame.OnZombieKilled( ply );
		

			Health -= damage.Damage / 2;


			if ( Health <= 0 )
			{
				LifeState = LifeState.Dead;


			

			}
		}
	}
}
