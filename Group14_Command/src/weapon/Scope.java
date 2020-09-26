package weapon;

public class Scope extends Attachment
{
	public Scope(Weapon weap) 
	{
		super(weap);
	}

	/**
	 * calculates the damage when a scope is added on. The scope gives a weapon
	 * a multiplier of 1 + current range/max range
	 */
	@Override
	public int calculateDamage(int distance) 
	{
		if (weapon == null)
		{
			return 0;
		}
		
		/**
		 * If Weapon instance variable isn't an instance of GenericWeapon, then we're decorating an attachment.
		 * Since we're restricted to two attachment, then the other attachment will be holding the generic weapon.
		 */
		GenericWeapon weap = weapon instanceof GenericWeapon ? (GenericWeapon) weapon
				: (GenericWeapon) ((Attachment) weapon).weapon;

		/**
		 * Holds the original value of maxRange.
		 */
		int maxRange = weap.getMaxRange();

		// if the range is greater than the weapons max range, but still less
		// than the
		// max range+10, the following calculations take place. This allows us
		// to still
		// receive a base damage from the weapon when the range is further than
		// the maxRange
		if ((distance > maxRange) && (distance <= (maxRange + 10)))
		{
			weap.setMaxRange(maxRange + 10);
			int weapDamage = weapon.calculateDamage(distance);
			double scopeDamage = ((double) weapDamage)
					* (1 + ((double) distance) / (double) maxRange);
			weap.setMaxRange(weap.getMaxRange() - 10);
			return (int) scopeDamage;
		}

		int weapDamage = weapon.calculateDamage(distance);

		double scopeDamage = ((double) weapDamage)
				* (1 + ((double) distance) / (double) maxRange);

		return (int) scopeDamage;
	}
}
