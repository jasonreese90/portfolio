//Ryan Handley

package weapon;

import lifeform.LifeForm;

/**
 * 
 * Interface the possesses a method to calculate damage.
 *
 */
public interface Weapon
{
	
	//calculates how much damage the weapon will do
	public int calculateDamage(int distance); 	
}
