

namespace GeneralGame;

public class MedicSuplie : Component
{
	[Property] public ModelRenderer Model { get; set; }
	[Property] public SoundEvent TakeSound { get; set; }
	private int CurPockets { get; set; } = 0;

	public void OnUse( PlayerBase ply )
	{
		if ( ply.Health >= 100 ) return;

		if ( CurPockets <= 3 )
		{
			ply.Health = ply.MaxHealth;
			GameObject.PlaySound( TakeSound );
			CurPockets += 1;
			Model.SetBodyGroup( "pockets", CurPockets );
			ply.AnimationHelper.Target.Set( "b_pickup", true );
		}
	}


	protected override void OnStart()
	{
		var interactions = Components.GetOrCreate<Interactions>();
		interactions.AddInteraction( new Interaction()
		{
			Action = ( PlayerBase interactor, GameObject obj ) => OnUse( interactor ),
			Keybind = "use",
			Description = "Heal",
			Disabled = () => CurPockets > 3,
			ShowWhenDisabled = () => true,
			Accessibility = AccessibleFrom.World,
		} );
	}




}
