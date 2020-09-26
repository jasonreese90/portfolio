//Jason Quedenfeld
package lifeform;

import static org.junit.Assert.*;

import org.junit.Test;

/**
 * 
 * Tests the functionality provided by the Human class
 *
 */
public class TestHuman
{
	/**
	 *  Tests that the class instance variables are properly set.
	 *  
	 */
	@Test
	public void testInitailizion() 
	{
		Human human = new Human("Bob",40,1);
		
		assertEquals(human.getCurrentLifePoints(),40);
		assertEquals(human.getName(),"Bob");
		
		assertEquals(human.getArmorPoints(),1);
	}
	
	/**
	 * Tests the functionality of setArmorPoints.
	 * 
	 */
	@Test
	public void testSetArmorPoints()
	{
		Human human = new Human("Bob",40,1);
		
		human.setArmorPoints(25);
		assertEquals(human.getArmorPoints(),25);
	}
}
