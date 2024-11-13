using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GeneralGame;
using Sandbox;
using Sandbox.Internal;

namespace GeneralGame;

public static class Extensions
{
	public static async void PlayUntilFinished( this SceneParticles particles, TaskSource source )
	{
		try
		{
			while ( !particles.Finished )
			{
				await source.Frame();
				particles.Simulate( Time.Delta );
			}
		}
		catch ( TaskCanceledException )
		{

		}

		particles.Delete();
	} 

}
