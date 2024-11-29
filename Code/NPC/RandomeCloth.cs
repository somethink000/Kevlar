




//public sealed class RandomeCloth : Component, Component.INetworkSpawn
//{
//	[Property] public SkinnedModelRenderer BodyRenderer { get; set; }

//	public void OnNetworkSpawn( Connection owner )
//	{
//		var clothing = new ClothingContainer();
//		clothing.Deserialize( owner.GetUserData( "avatar" ) );
//		//clothing.ApplyWithComponent( BodyRenderer );

//	}
//}
using Sandbox;
using static Sandbox.SerializedProperty;
using System.Collections.Generic;

namespace GeneralGame;

public class RandomeCloth : Component
{
	[Property] public List<Model> Cloths { get; set; }
	[Sync] public string clothingJSON { get; set; }
	ClothingContainer clothingContainer;
	List<SkinnedModelRenderer> clothingRenderers = new();

	//void ApplyClothes( Connection connection )
	//{
	//	clothingJSON = connection.GetUserData( "avatar" );
	//	clothingContainer = ClothingContainer.CreateFromJson( clothingJSON );
	//	clothingContainer.Apply( BodyRenderer );

	//	BodyRenderer.GameObject.Children.ForEach( c =>
	//	{
	//		if ( c.Name.StartsWith( "Clothing" ) )
	//		{
	//			var renderer = c.Components.Get<SkinnedModelRenderer>();
	//			clothingRenderers.Add( renderer );
	//		}
	//	} );
	//}

	//void UpdateClothes()
	//{
	//	// Can take a while to spawn on clients so we check here until they are spawned in
	//	if ( clothingRenderers.Count == 0 )
	//	{
	//		BodyRenderer.GameObject.Children.ForEach( c =>
	//		{
	//			if ( c.Name.StartsWith( "Clothing" ) )
	//			{
	//				var renderer = c.Components.Get<SkinnedModelRenderer>();
	//				clothingRenderers.Add( renderer );
	//			}
	//		} );
	//	}

	//	if ( !IsProxy && IsAlive && IsFirstPerson )
	//	{
	//		BodyRenderer.RenderType = ModelRenderer.ShadowRenderType.ShadowsOnly;
	//	}
	//	else
	//	{
	//		BodyRenderer.RenderType = ModelRenderer.ShadowRenderType.On;
	//	}

	//	clothingRenderers.ForEach( c =>
	//	{
	//		c.RenderType = BodyRenderer.RenderType;
	//	} );
	//}
}
