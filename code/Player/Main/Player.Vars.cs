using System;
using System.Collections.Generic;
using System.Linq;
using Sandbox;
using Sandbox.Citizen;

namespace GeneralGame;

//Player game logic,
//To use Camera, Speed, CharachterController variables take them from PlayerBody, PlayerCamera, PlayerController. like (player.CameraController.Camera)
public partial class Player
{
	[RequireComponent] public PlayerController Controller { get; set; }
	[RequireComponent] public PlayerBody Body { get; set; }
	[RequireComponent] public PlayerCamera CameraController { get; set; }
	[RequireComponent] public RagdollController Ragdoll { get; set; }
	[RequireComponent] public PlayerFeatures Features { get; set; }
	
	[RequireComponent] public AmmoContainer Ammo { get; set; }
	[RequireComponent] public WeaponContainer Weapons { get; set; }

	[Property] public CameraComponent Camera { get; set; }
	[Property] public GameObject Eye { get; set; }
	[Property] public SoundEvent HurtSound { get; set; }
	[Property] public float HealthRegenPerSecond { get; set; } = 10f;

	[Sync, Property] public float MaxHealth { get; private set; } = 100f;
	[Sync] public LifeState LifeState { get; private set; } = LifeState.Alive;
	[Sync] public float Health { get; private set; } = 100f;

	private RealTimeSince TimeSinceDamaged { get; set; }

}
