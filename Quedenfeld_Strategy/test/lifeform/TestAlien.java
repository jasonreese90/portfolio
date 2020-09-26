//Jason Quedenfeld
package lifeform;

import static org.junit.Assert.*;

import org.junit.Test;

import recovery.RecoveryLinear;

/**
 * Tests the functionality provided by the Alien class
 * 
 */
public class TestAlien
{

	/**
	 * Tests that the name and life points of the alien are correctly set.
	 * 
	 */
	@Test
	public void testInitialization() 
	{
		Alien alien = new Alien("Bob",40);
		
		assertEquals(alien.getCurrentLifePoints(),40);
		assertEquals(alien.getName(),"Bob");
	}
	
	/**
	 * Tests that the Alien can recover life points
	 * 
	 */
	@Test
	public void testRecovery()
	{
		Alien alien = new Alien("Bob",40, new RecoveryLinear(3));
		assertEquals(alien.getCurrentLifePoints(),40);
		alien.takeHit(30);
		alien.recover();
		
		assertEquals(alien.getCurrentLifePoints(),13);
	}
	
	/**
	 * Tests that life points cannot exceed max life points.
	 * 
	 */
	@Test
	public void testSetCurrentLifePoints()
	{
		Alien alien = new Alien("Bob",40, new RecoveryLinear(3));
		
		//make sure we can't set the current life points higher than the max, which is 40
		alien.setCurrentLifePoints(50);
		assertEquals(alien.getCurrentLifePoints(),alien.getMaxLifePoints());
	}

}
