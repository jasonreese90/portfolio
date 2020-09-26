//Ryan Handley
package weapon;

public class Scope extends Attachment
{
	int currentRange;
	int maxRange;
        
    public Scope(Weapon weap)
    {
    	super(weap);
    }

    
    /**
     * calculates the damage when a scope is added on. The scope gives a weapon a multiplier of 
     * 1 + current range/max range
     */
	@Override
	public int calculateDamage(int distance)
	{
		if(weapon == null)
		{
			return 0;
		}
		
		GenericWeapon weap = weapon instanceof GenericWeapon ? (GenericWeapon)weapon : (GenericWeapon)((Attachment)weapon).weapon;

		
		int a = distance;
		
		int b = weap.getMaxRange();
		
		//if the range is greater than the weapons max range, but still less than the
		//max range+10, the following calculations take place. This allows us to still
		//recieve a basedamage from the weapon when the range is further than the maxRange
		if((a>b)&&(a<=(b+10)))
		{
			weap.setMaxRange(b+10);
			int weapDamage = weapon.calculateDamage(distance);
			double scopeDamage = ((double)weapDamage)*(1+((double)a)/(double)b); 
			weap.setMaxRange(weap.getMaxRange()-10);
			return (int)scopeDamage;
		}
		
		
		int weapDamage = weapon.calculateDamage(distance);
		
		if(weapDamage == 0)
		{
			return 0;
		}
		
		double scopeDamage = ((double)weapDamage)*(1+((double)a)/(double)b); 
		
		return (int)scopeDamage;
		
	}
}
