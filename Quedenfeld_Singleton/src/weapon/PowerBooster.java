//Jason Quedenfeld
package weapon;

import lifeform.LifeForm;

/**
 * 
 * Creates an implementation of Attachment that represents a PowerBooster, which\
 * Increases damage based on current and max ammo.
 *
 */
public class PowerBooster extends Attachment
{
	/**
	 * Creates and instance of PowerBooster.
	 * @param weapon weapon to add attachment to.
	 */
	public PowerBooster(Weapon weapon)
	{
		super(weapon);
	}

	/**
	 * Calculate damage of attachment
	 */
	@Override
	public int calculateDamage(int distance) 
	{
		if(weapon == null)
		{
			return 0;
		}
		
		/**
		 * If Weapon instance variable isn't an instance of GenericWeapon, then we're decorating an attachment.
		 * Since we're restricted to two attachment, then the other attachment will be holding the generic weapon.
		 */
		
		GenericWeapon weap = weapon instanceof GenericWeapon ? (GenericWeapon)weapon : (GenericWeapon)((Attachment)weapon).weapon;
		
		return (int)(weapon.calculateDamage(distance) * (1 + ((double)weap.getCurrentAmmo()/(double)weap.getMaxAmmo())));
	}
}
