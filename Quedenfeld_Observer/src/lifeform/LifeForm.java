//Jason Quedenfeld
package lifeform;

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
    		lifeForm.takeHit(attackStrength);
    }
    
    /**
     * Should be overridden by sub-classes. Does not provide any base functionality.
     */
    @Override
	public void updateTime(int time) 
	{
		
	}
}
