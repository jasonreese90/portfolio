//Jason Quedenfeld
package lifeform;

import static org.junit.Assert.*;

import org.junit.Test;

import recovery.RecoveryLinear;

/**
 * 
 * Tests the functionality provided by the Human class
 *
 */
public class TestHuman
{
	
	/**
	 * Tests that the functionality of attackLifeForm works correctly.
	 * Human has armor.
	 */
	@Test
	public void testAttackWithArmor() 
	{
		Human human = new Human("Bob",40, 10,15);
		assertEquals(human.getCurrentLifePoints(),40);
		//Testing attack strength
		assertEquals(human.getAttackStrength(),15);
		
		human.attackLifeForm(human);

		assertEquals(human.getCurrentLifePoints(),35);
		
		//Testing armor when greater than attack strength
		human = new Human("Bob",40, 10,7);
		human.attackLifeForm(human);	
		assertEquals(human.getCurrentLifePoints(),40);
		
		//Testing armor when equal to attack strength
		human = new Human("Bob",40, 10,10);
		human.attackLifeForm(human);	
		assertEquals(human.getCurrentLifePoints(),40);
	}
	
	/**
	 * Tests that the functionality of attackLifeForm works correctly.
	 * Human does not have any armor.
	 */
	@Test
	public void testAttack() 
	{
		Human human = new Human("Bob",40, 0,5);
		assertEquals(human.getCurrentLifePoints(),40);
		//Testing attack strength
		assertEquals(human.getAttackStrength(),5);
		
		human.attackLifeForm(human);

		assertEquals(human.getCurrentLifePoints(),35);
	}
	
	/**
	 * Tests that attack strength is correctly initialized.
	 */
	@Test
	public void testAttackStrength()
	{
		Human human = new Human("Bob",40, 0,5);
		assertEquals(human.getCurrentLifePoints(),40);
		//Testing attack strength
		assertEquals(human.getAttackStrength(),5);
	}
	
/**
 * Start Section for Strategy Pattern Tests
 */
	
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
