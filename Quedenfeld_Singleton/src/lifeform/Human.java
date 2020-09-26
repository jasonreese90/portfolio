//Jason Quedenfeld
package lifeform;

/**
 * A LifeForm representing a Human
 * a Human possesses a certain amount
 * of armor points.
 */
public class Human extends LifeForm
{
	private int armorPoints;
	
	/**
	 * Creates a Human with a name, life points, and armor points.
	 * 
	 * @param name name of the Human.
	 * @param life life points of the Human.
	 * @param armor armor points of the Human.
	 */
	public Human(String name, int life, int armor)
	{
		this(name,life,armor,0);
	}
	
	/**
	 * Creates a Human with a name, life points, and armor points.
	 * 
	 * @param name name of the Human.
	 * @param life life points of the Human.
	 * @param armor armor points of the Human.
	 * @param attack the strength of the attack the Human possesses.
	 */
	public Human(String name, int life, int armor, int attack)
	{
		super(name,life,attack);	
		
		armorPoints = armor;
	}
	
	/**
	 * gets the amount of armor points currently possessed by the Human.
	 * @return returns the amount of armor points.
	 */
	public int getArmorPoints()
	{
		return armorPoints;
	}
	
	/**
	 * Sets the amount of armor points to be possessed by the Human.
	 * @param armor amount of armor points.
	 */
	public void setArmorPoints(int armor)
	{
		armorPoints = armor;
	}
	
    /**
     * Inflicts damage on the life form.
     * @param damage amount of damage to inflict on life form.
     */
	@Override
    public void takeHit(int damage)
    {
		if(armorPoints > 0 )
		{
			currentLifePoints -= (armorPoints < damage) ? (damage % armorPoints) : 0;
			
			if(currentLifePoints < 0)
	    	{
	    		currentLifePoints = 0;
	    	}
		}
		else
		{
			super.takeHit(damage);
		}
    }
}
