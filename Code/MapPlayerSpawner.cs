using Sandbox;
using System;
using System.Threading.Tasks;
using System.Linq;

public class MapPlayerSpawner : Component
{
	protected override void OnFixedUpdate()
    {
		bool RestartButtonOn = Input.Released("reload");
		if (RestartButtonOn)
		{
			for (int i = 0; i < 10; i++)
            {
				Task.Delay(1000).GetAwaiter().GetResult();
				RespawnPlayers();
			}
				
		}
	}
	protected override void OnEnabled()
	{
		base.OnEnabled();

		if ( Components.TryGet<MapInstance>( out var mapInstance ) )
		{
			mapInstance.OnMapLoaded += RespawnPlayers;

			// already loaded
			if ( mapInstance.IsLoaded )
			{
				RespawnPlayers();
			}
		}
	}

	protected override void OnDisabled()
	{
		if ( Components.TryGet<MapInstance>( out var mapInstance ) )
		{
			mapInstance.OnMapLoaded -= RespawnPlayers;
		}

	}

	public void RespawnPlayers()
	{
		var spawnPoints = Scene.GetAllComponents<SpawnPoint>().ToArray();

		foreach ( var player in Scene.GetAllComponents<PlayerController>().ToArray() )
		{
			if ( player.IsProxy )
				continue;

			var randomSpawnPoint = Random.Shared.FromArray( spawnPoints );
			if ( randomSpawnPoint is null ) continue;

			player.Transform.Position = randomSpawnPoint.Transform.Position;

			if ( player.Components.TryGet<PlayerController>( out var pc ) )
			{
				pc.EyeAngles = randomSpawnPoint.Transform.Rotation.Angles();
			}

		}
	}
}
