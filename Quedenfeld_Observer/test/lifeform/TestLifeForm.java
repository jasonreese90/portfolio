//Jason Quedenfeld
package lifeform;

import static org.junit.Assert.*;
import gameplay.SimpleTimer;

import org.junit.Test;

/**
 * Tests the functionality provided by the LifeForm class
 * 
 */
public class TestLifeForm
{
	/**
	 * Test that LifeForm can keep track of time.
	 */
	@Test
	public void testKeepTrackOfTime()
	{
		MockLifeForm lifeForm = new MockLifeForm("Bob",40,5);
		SimpleTimer timer = new SimpleTimer();
		timer.addTimeObserver(lifeForm);
		timer.timeChanged();
		assertEquals(lifeForm.myTime,1);
		timer.timeChanged();
		assertEquals(lifeForm.myTime,2);
		timer.timeChanged();
		assertEquals(lifeForm.myTime,3);
	}
		
	/**
	 * Verify that a dead lifeform cannot attack.
	 */
	@Test
	public void testThatDeadLifeFormCannotAttack()
	{
		LifeForm l1 = new MockLifeForm("Bob",40,5);
		LifeForm l2 = new MockLifeForm("Bob",0,40);
		
		assertEquals(l1.getCurrentLifePoints(),40);
		l2.attackLifeForm(l1);
		assertEquals(l1.getCurrentLifePoints(),40);
	}
	
	/**
	 * Testing that life form can attack another life form.
	 */
	@Test
	public void testAttackLifeForm()
	{
		LifeForm lifeForm = new MockLifeForm("Bob",40,5);
		lifeForm.attackLifeForm(lifeForm);
		assertEquals(lifeForm.getCurrentLifePoints(),35);
	}
	
	/**
	 * Testing that setAttackStrength sets attack strength correctly.
	 */
	@Test
	public void testSetAttackStrength()
	{
		LifeForm lifeForm = new MockLifeForm("Bob",40,5);
		assertEquals(lifeForm.getAttackStrength(),5);
		lifeForm.setAttackStrength(10);
		assertEquals(lifeForm.getAttackStrength(),10);
	}
	
	/**
	 * Testing that getAttackStrength returns the correct value.
	 */
	@Test
	public void testGetAttackStrength()
	{
		LifeForm lifeForm = new MockLifeForm("Bob",40,5);
		
		assertEquals(lifeForm.getAttackStrength(),5);
	}
	
/**
 * Start Section for Strategy Pattern Tests
 */
	
    /**
     * When a LifeForm is created, it should know its name and how
     * many life points it has.
     */
    @Test
    public void testInitialization()
    {
        LifeForm entity;
        entity = new MockLifeForm("Bob",40);
        assertEquals("Bob",entity.getName());
        assertEquals(40,entity.getCurrentLifePoints());
        
        //Life points shouldn't fall below 0
        
        entity = new MockLifeForm("Bob",-40);
        
        assertTrue(entity.getCurrentLifePoints() >= 0);
    }
    
    /**
     *  Tests that life points cannot fall below 0.
     */
    @Test
    public void testTakeHit()
    {
    	LifeForm entity = new MockLifeForm("Bob",40);
    	
    	assertTrue(entity.getCurrentLifePoints() >= 0);
    	entity.takeHit(50);
      	assertTrue(entity.getCurrentLifePoints() >= 0); 
    }
}
