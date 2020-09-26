//Ryan Handley
package weapon;


public class ChainGun extends GenericWeapon
{

	public ChainGun(int maxAmmo, int maxRange, int baseDamage, int rateOfFire,
			int initialAmmo)
	{
		super(maxAmmo, maxRange, baseDamage, rateOfFire, initialAmmo);
		// TODO Auto-generated constructor stub
		/*
		maxAmmo = 40;
		maxRange = 60;
		baseDamage = 15;
		rateOfFire = 4;
		initialAmmo = maxAmmo;*/
	}
	
	/**
	 * calculates the damage for chainGun.
	 */
	@Override
	public int calculateDamage(int distance)
	{
		if(currentAmmo == 0 || distance > maxRange)
		{
			return 0;
		}
		   
		double rangeCalc = (((double)distance)/((double)(maxRange)));
		 double damage = (((double)(baseDamage))*(rangeCalc));

		return (int)damage;
	}
}
