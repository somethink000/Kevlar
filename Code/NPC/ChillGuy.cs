

using Sandbox.Citizen;
using static Sandbox.PhysicsContact;

namespace GeneralGame;


public class ChillGuy : Component
{


	[Property] GroupedCloth Cloths { get; set; }

	[RequireComponent] public CitizenAnimationHelper animationHelper { get; set; }
	[RequireComponent] public Dresser Dresser { get; set; }
	[RequireComponent] public SkinnedModelRenderer Model { get; set; }
	[RequireComponent] public ModelCollider Collider { get; set; }
	




	protected override void OnAwake()
	{
		Random rnd = new Random();



		List<ClothStruct> ClothStructs = new List<ClothStruct>();
		ClothStructs.Add( rnd.FromList( Cloths.Jackets ) );
		ClothStructs.Add( rnd.FromList( Cloths.Shirts ) );
		ClothStructs.Add( rnd.FromList( Cloths.Trousers ) );
		ClothStructs.Add( rnd.FromList( Cloths.Shoes ) );

		foreach ( var c in ClothStructs )
		{
			Dresser.Clothing.Add( c.Cloth );
		};

		Dresser.Apply();
		

	}
	
}
