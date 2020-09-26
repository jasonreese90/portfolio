//Jason Quedenfeld

package weapon;

/**
 * 
 * An implementation of generic weapon to represent a plasma cannon.
 *
 */
public class PlasmaCannon extends GenericWeapon
{

	/**
	 * Creates an instance of plasma cannon.
	 * 
	 * @param maxAmmo the maximum ammo that a weapon can possess.
	 * @param maxRange the maximum range a weapon can do damage in.
	 * @param baseDamage the base damage of the weapon.
	 * @param rateOfFire the rate of fire of the weapon.
	 * @param initialAmmo the initial ammo of the weapon.
	 */
	public PlasmaCannon(int maxAmmo, int maxRange, int baseDamage,int rateOfFire, int initialAmmo)
	{
		super(maxAmmo, maxRange, baseDamage, rateOfFire,initialAmmo);
		
	}
	
	/**
	 *  damage calculated by the weapon.
	 */
	@Override
	public int calculateDamage(int distance)
	{
		if(currentAmmo == 0 || maxAmmo == 0 )// avoid division by 0 if for some reason maxAmmo is 0
			return 0;
		
			 
		return (int)((double)baseDamage * ((double)currentAmmo/(double)maxAmmo));	
	}

}
