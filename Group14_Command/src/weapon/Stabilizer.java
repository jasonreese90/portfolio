package weapon;

/**
 * 
 * Daniel Breitigan
 * Dr. Girard
 * 
 * Add stabilizer attachment 
 *
 */
public class Stabilizer extends Attachment
{
    //Constructor for our stabilizer, adds it onto weapon
    public Stabilizer(Weapon weapon)
    {
    	super(weapon);
    }
    
    //Calculate the increased damage with the stabilizer
    @Override
    public int calculateDamage(int distance)
    {
		if(weapon == null)
		{
			return 0;
		}
    	
    	 GenericWeapon weap = weapon instanceof GenericWeapon ? (GenericWeapon)weapon : (GenericWeapon)((Attachment)weapon).weapon;
         if(weap.getCurrentAmmo() == 0)
         {
             weap.reload();
         }
        
        return (int)(weapon.calculateDamage(distance) * 1.25);
    }
}
