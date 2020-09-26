//Jason Quedenfeld
package lifeform;

import environment.Environment;
import weapon.Attachment;
import weapon.GenericWeapon;
import weapon.Weapon;
import gameplay.TimeObserver;

/**
 * Keeps track of the information associated with a simple life form.
 * Also provides the functionality related to the life form.
 */
public abstract class LifeForm implements TimeObserver 
{
    private String myName;
    private int attackStrength;
    protected int currentLifePoints;
    protected Weapon currentWeapon;
    
    /**
     * Create an instance.
     * 
     * @param name the name of the life form
     * @param points the current starting life points of the life form
     */
    public LifeForm(String name,int points)
    {
    	this(name,points,0);
    }
    
    /**
     * Create an instance.
     * 
     * @param name the name of the life form
     * @param points the current starting life points of the life form
     * @param attack the attack strength the life form possesses
     */
    public LifeForm(String name, int points, int attack)
    {
    	myName = name;
        attackStrength = attack;
        
        if(points < 0)
        {
            currentLifePoints = 0;
        }
        else
        {
            currentLifePoints = points;
        }
    }
    /**
     * @return the name of the life form.
     */
    public String getName()
    {
        return myName;
    }
    
    /**
     * @return the amount of current life points the life form has.
     */
    public int getCurrentLifePoints()
    {
        return currentLifePoints;
    }
    
    /**
     * @return the strength of the attack the life form possesses.
     */
    public int getAttackStrength()
    {
    	return attackStrength;
    }
    
    /**
     * Sets the attack strength.
     * @param attack the attack strength.
     */
    public void setAttackStrength(int attack)
    {
    	attackStrength = attack;
    }
    
    /**
     * 
     * @param damage amount of damage to inflict on life form.
     */
    public void takeHit(int damage)
    {
    	currentLifePoints -= damage;
    	
    	if(currentLifePoints < 0)
    	{
    		currentLifePoints = 0;
    	}
    }
    
    /**
     * 
     * @param lifeForm life form to attack.
     */
    public void attackLifeForm(LifeForm lifeForm)
    {
    	if(currentLifePoints > 0)
    	{
    		int distance = Environment.getWorldInstance().getDistance(this, lifeForm);
    		
    		if(currentWeapon != null && getGenericWeapon().getCurrentAmmo() > 0)
    		{
    			GenericWeapon.fire(lifeForm,currentWeapon,distance);
    		}
    		else
    		{
    			if(distance <= 10)
        		{
    		        if(currentWeapon != null)
    		        {
    		        	GenericWeapon weapon = getGenericWeapon();
    		        	if(weapon.getShotsFired() < weapon.getRateOfFire())
    		        	{
    		        		lifeForm.takeHit(attackStrength);
    		        		weapon.incrementShotsFired();
    		        	}
    		        }
    		        else
    		        {
    		        	lifeForm.takeHit(attackStrength);
    		        }      			
        		}
    		}
    	}
    }
    
    /**
     * 
     * @return returns a generic weapon if the instance weapon is a attachment.
     */
    public GenericWeapon getGenericWeapon()
    {
    	Weapon weapon = currentWeapon;
    	
    	while(weapon instanceof Attachment)
    	{
    		weapon = ((Attachment)weapon).getWeapon();
    	}
    	
    	return (GenericWeapon)weapon;
    }
    
    /**
     * picks up a weapon, if one is not possessed.
     * @param weapon weapon to pickup.
     */
    public void pickUpWeapon(Weapon weapon)
    {
    	if(currentWeapon == null)
    	{
    		currentWeapon = weapon;
    	}
    }
    
    /**
     * drops the current weapon.
     */
    public void dropWeapon()
    {
    	currentWeapon = null;
    }
    
    /**
     *  reloads the current weapon, if one is possessed.
     */
    public void reloadWeapon()
    {
    	if(currentWeapon != null)
    	{
    		getGenericWeapon().reload();
    	}
    }
    
    /**
     * Should be overridden by sub-classes. Does not provide any base functionality.
     */
    @Override
	public void updateTime(int time) 
	{
		
	}
}
