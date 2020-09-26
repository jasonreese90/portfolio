//Ryan Handley

//Modified by Jason Quedenfeld  September 28th 2:40 PM

package weapon;

import gameplay.TimeObserver;
import lifeform.LifeForm;

/**
 * 
 * An implementation of the Weapon interface used to represent a weapon 
 * that can do damage to a lifeform.
 *
 */
public abstract class GenericWeapon implements Weapon, TimeObserver
{
	protected int maxAmmo;
	protected int currentAmmo;
	protected int maxRange;
	protected int baseDamage;
	protected int rateOfFire;
	
	protected int shotsFired;
	
	/**
	 * Creates an instance of generic weapon.
	 * 
	 * @param maxAmmo the maximum ammo that a weapon can possess.
	 * @param maxRange the maximum range a weapon can do damage in.
	 * @param baseDamage the base damage of the weapon.
	 * @param rateOfFire the rate of fire of the weapon.
	 * @param initialAmmo the initial ammo of the weapon.
	 */
	public GenericWeapon(int maxAmmo, int maxRange, int baseDamage, int rateOfFire,int initialAmmo)
	{
		this.maxAmmo = maxAmmo;
		this.maxRange = maxRange;
		this.baseDamage = baseDamage;
		this.rateOfFire = rateOfFire;
		this.currentAmmo = initialAmmo;
	
		this.shotsFired = 0;
	}
	
	/**
	 * 
	 * @return the current ammo the weapon has.
	 */
	public int getCurrentAmmo()
	{
		return currentAmmo;
	}
	
	/**
	 * 
	 * @return the maximum ammo a weapon can possess.
	 */
	public int getMaxAmmo()
	{
		return maxAmmo;
	}
	
	/**
	 * 
	 * @return the maximum range a weapon can operate in.
	 */
	public int getMaxRange()
	{
		return maxRange;
	}
	
	/**
	 * @returns the rate of fire of the weapon.
	 */
	public int getRateOfFire()
	{
		return rateOfFire;
	}
	
	/**
	 * @return base damage of weapon
	 */
	public int getBaseDamage()
	{
		return baseDamage;
	}
	
	/**
	 * lets the lifeForm reload it's weapon to full capacity
	 */
	public void reload()
	{
		currentAmmo = maxAmmo;
	}
	 
	/**
	 * Sets the maximum range of the weapon.
	 * @param range the maximum range of the weapon.
	 */
	public void setMaxRange(int range)
	{
		maxRange = range;
	}
	
	
	
	/**
	 * Calculates the damage of the weapon.
	 */
	@Override
	public abstract int calculateDamage(int distance);
	
	
	/**
	 * fires weapon at a target.	 
	 * 
	 * * @param target target to fire at.
	 * @param distance distance lifeform is from target lifeform
     */
	public static void fire(LifeForm target, Weapon weapon, int distance)
	{
		Weapon weap = weapon;
    	
    	while(weap instanceof Attachment)
    	{
    		weap = ((Attachment)weap).getWeapon();
    	}
    	
    	GenericWeapon genericWeapon = (GenericWeapon)weap;
    	
    	if(genericWeapon.currentAmmo > 0)
    	{
		  if(genericWeapon.shotsFired < genericWeapon.rateOfFire)
		  {
			  if(distance <= genericWeapon.maxRange)
			  {
				  target.takeHit(weapon.calculateDamage(distance));
			  }
		  
			  genericWeapon.shotsFired++;
			  genericWeapon.currentAmmo--;
		  }
	  }
	}
	
	/**
	 * Update notice from timer.
	 */
	public void updateTime(int time)
	{
		shotsFired = 0;
	}
	
	/**
	 * sets current ammo of weapon.
	 * @param ammo amount of ammo
	 */
	public void setCurrentAmmo(int ammo)
	{
		currentAmmo = ammo;
	}
	
	/**
	 * increments counter used to keep track of number of shots in current round.
	 */
	public void incrementShotsFired()
	{
		shotsFired++;
	}
	
	/**
	 * 
	 * @return how many shots have been fired this round.
	 */
	public int getShotsFired()
	{
		return shotsFired;
	}
}
