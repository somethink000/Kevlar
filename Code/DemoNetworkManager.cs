using Sandbox.Network;

namespace GeneralGame;


public class DemoNetworkManager : Component, Component.INetworkListener
{
	[Property] public PrefabScene PlayerPrefab { get; set; }

	protected override void OnStart()
	{
		if ( !GameNetworkSystem.IsActive )
		{
			GameNetworkSystem.CreateLobby();
		}

		base.OnStart();
	}

	// Called on host
	void INetworkListener.OnActive( Connection connection )
	{
		
		var obj = PlayerPrefab.Clone();
		var player = obj.Components.Get<PlayerBase>( FindMode.EverythingInSelfAndDescendants );
		obj.NetworkMode = NetworkMode.Object;
		obj.BreakFromPrefab();
		obj.NetworkSpawn( connection );
		player.SetupConnection( connection );
	}
}
