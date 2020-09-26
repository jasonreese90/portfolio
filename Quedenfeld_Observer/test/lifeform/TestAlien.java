//Jason Quedenfeld
package lifeform;

import static org.junit.Assert.*;
import gameplay.SimpleTimer;

import org.junit.Test;

import recovery.RecoveryLinear;

/**
 * Tests the functionality provided by the Alien class
 * 
 */
public class TestAlien
{
	
	/**
	 * Tests that the Alien can recover.
	 */
	@Test
	public void testCombatRecovery()
	{
		// first test, should recover by 3
		Alien alien = new Alien("Bob",40,new RecoveryLinear(3),10,2);
		alien.takeHit(10);
		assertEquals(alien.getCurrentLifePoints(),30);
		SimpleTimer timer = new SimpleTimer();
		timer.addTimeObserver(alien);
		timer.timeChanged();
		assertEquals(alien.getCurrentLifePoints(),30);
		timer.timeChanged();
		assertEquals(alien.getCurrentLifePoints(),33);
		
		//Second test with different recovery rate, should recover by 12
		alien = new Alien("Bob",40,new RecoveryLinear(12),10,2);
		alien.takeHit(20);
		assertEquals(alien.getCurrentLifePoints(),20);
		timer.addTimeObserver(alien);
		timer.timeChanged();
		assertEquals(alien.getCurrentLifePoints(),20);
		timer.timeChanged();
		assertEquals(alien.getCurrentLifePoints(),32);
		
		//Test with recovery rate of 0, shouldn't recover.
		alien = new Alien("Bob",40,new RecoveryLinear(0),10,2);
		alien.takeHit(10);
		assertEquals(alien.getCurrentLifePoints(),30);
		timer.addTimeObserver(alien);
		timer.timeChanged();
		assertEquals(alien.getCurrentLifePoints(),30);
		timer.timeChanged();
		assertEquals(alien.getCurrentLifePoints(),30);
		
		//Test recovery after removing observer, shouldn't recover.
		alien = new Alien("Bob",40,new RecoveryLinear(3),10,2);
		alien.takeHit(10);
		assertEquals(alien.getCurrentLifePoints(),30);
		timer.addTimeObserver(alien);
		timer.timeChanged();
		assertEquals(alien.getCurrentLifePoints(),30);
		timer.timeChanged();
		assertEquals(alien.getCurrentLifePoints(),33);
		timer.removeTimeObserver(alien);
		timer.timeChanged();
		assertEquals(alien.getCurrentLifePoints(),33);
		timer.timeChanged();
		assertEquals(alien.getCurrentLifePoints(),33);
	}
	
	/**
	 * Tests that getRecoveryRate returns the correct value.
	 */
	@Test
	public void testGetRecoveryRate()
	{
		Alien alien = new Alien("Bob",40, new RecoveryLinear(3),10,2);
		assertEquals(alien.getRecoveryRate(),2);
	}
	
	/**
	 * Tests that the functionality of attackLifeForm works correctly.
	 */
	@Test
	public void testAttack() 
	{
		Alien alien = new Alien("Bob",40, new RecoveryLinear(3),10);
		assertEquals(alien.getCurrentLifePoints(),40);
		//Testing attack strength
		assertEquals(alien.getAttackStrength(),10);
		
		alien.attackLifeForm(alien);

		assertEquals(alien.getCurrentLifePoints(),30);
	}
	
	/**
	 * Tests that attack strength is correctly initialized.
	 */
	@Test
	public void testAttackStrength()
	{
		Alien alien = new Alien("Bob",40, new RecoveryLinear(3),10);
		assertEquals(alien.getCurrentLifePoints(),40);
		//Testing attack strength
		assertEquals(alien.getAttackStrength(),10);
	}
	
	
/**
 * Start Section for Strategy Pattern Tests
 */
	
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
