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
	//Direction constants
	public static final String DIRECTION_NORTH = "North", 
			DIRECTION_SOUTH = "South", 
			DIRECTION_EAST = "East",
			DIRECTION_WEST = "West";
	
    private String myName;
    private int attackStrength;
    
    protected int currentLifePoints;
    protected Weapon currentWeapon;

	protected int maxSpeed;
	protected int currentSpeed;
	
	protected String currentDirection;
    
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
        
        maxSpeed = 0;
        currentSpeed = 0;
        currentDirection = DIRECTION_NORTH;
    }
    
    public int getMaxSpeed()
    {
    	return maxSpeed;
    }
    
    public String getCurrentDirection()
    {
    	return currentDirection;
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
     * Returns an instance of the currentWeapon.
     * @return
     */
    public Weapon getCurrentWeapon()
    {
    	return currentWeapon;
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
    	currentSpeed = 0;
	}

    /**
     * Changes the direction the lifeform is currently facing.
     * @param direction the new direction to face.
     */
	public void changeDirection(String direction) 
	{
		this.currentDirection = direction;
	}
	
	/**
	 * 
	 * @return the current speed of the lifeform.
	 */
	public int getCurrentSpeed()
	{
		return currentSpeed;
	}
	
	/**
	 * sets the current speed of the lifeform.
	 * @param speed speed to change the current speed to.
	 */
	public void setCurrentSpeed(int speed)
	{
		currentSpeed = Math.min(maxSpeed, speed);
	}
}
