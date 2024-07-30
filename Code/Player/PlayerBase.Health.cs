
using System;
using static Sandbox.Component;

namespace GeneralGame;

public partial class PlayerBase
{
	[Sync, Property] public float MaxHealth { get; set; } = 100f;
	[Sync] public LifeState LifeState { get; private set; } = LifeState.Alive;
	[Sync] public float Health { get; private set; } = 100f;


	[Sync] public int Kills { get; set; }
	[Sync] public int Deaths { get; set; }
	[Sync] public bool GodMode { get; set; }
	[Property] public ColorAdjustments Adjustments { get; set; }
	[Property] public Vignette Vignette { get; set; }

	public bool IsAlive => Health > 0;



	public void FixedHealthEffectUpdate()
	{
		var health = (1f / MaxHealth) * Health;

		Adjustments.Saturation = 1f - (1f - health) * 0.3f;
		Vignette.Intensity = 0.5f * (1f - health);
	}



	[Broadcast]
	public virtual void TakeDamage( DamageType type, float damage, Vector3 position, Vector3 force, Guid attackerId, string[] hitboxes )
	{
		if ( IsProxy || !IsAlive || GodMode )
			return;

		Health -= damage;


		if ( Health <= 0 )
			OnDeath( force, position, attackerId );
	}
}
