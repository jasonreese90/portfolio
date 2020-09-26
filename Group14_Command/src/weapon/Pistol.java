package weapon;



/**
 * Daniel Breitigan
 * Dr. Girard
 * 
 * Creates a Pistol that is a weapon.
 *  
 */
public class Pistol extends GenericWeapon
{
    
    //Constructor for our pistol
    public Pistol(int maxAmmo, int maxRange, int baseDamage,int rateOfFire, int initialAmmo)
    {
        super(maxAmmo, maxRange, baseDamage, rateOfFire, initialAmmo);
    }
    
    
    //Calculates the damage the pistol does
    @Override
    public int calculateDamage(int distance)
    {   
        if(currentAmmo == 0)
            return 0;
        
       return (int)((double)baseDamage * (((double)maxRange - (double)distance + 10)/(double)maxRange));
    }
}
