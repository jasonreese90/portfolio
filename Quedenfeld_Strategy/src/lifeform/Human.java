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
		super(name,life);	
		
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
}
