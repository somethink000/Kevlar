namespace GeneralGame;

public interface IBulletBase
{
	public void Shoot( Weapon weapon, Vector3 spreadOffset );

	public Vector3 GetRandomSpread( float spread );
}
