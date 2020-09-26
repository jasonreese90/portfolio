//Jason Quedenfeld
package lifeform;

import static org.junit.Assert.*;
import environment.Environment;
import gameplay.SimpleTimer;

import org.junit.Test;

import weapon.PlasmaCannon;

/**
 * Tests the functionality provided by the LifeForm class
 * 
 */
public class TestLifeForm
{
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
        
      
        //Test that currentDirection and maxSpeed are correctly set
        
        assertEquals(entity.getMaxSpeed(), 0);
        assertEquals(entity.getCurrentDirection(), LifeForm.DIRECTION_NORTH);
    }
	
    /**
     * tests that direction can be changed.
     */
    @Test
    public void testChangeDirection()
    {
    	LifeForm entity = new MockLifeForm("Bob",40);
    	entity.changeDirection(LifeForm.DIRECTION_EAST);
    	
    	assertEquals(entity.getCurrentDirection(),LifeForm.DIRECTION_EAST);
    }
    
	/**
	 * Start Section for Decorator Pattern Tests
	 */
	
	/**
	 * Test that LifeForm can pick up a weapon.
	 */
	@Test
	public void testCanPickupWeapon()
	{
		MockLifeForm lifeForm = new MockLifeForm("Bob",40,10);
		assertNull(lifeForm.currentWeapon);
		lifeForm.pickUpWeapon(new PlasmaCannon(10,10,10,10,10));
		assertNotNull(lifeForm.currentWeapon);
	}
	
	/**
	 * Test that LifeForm can't pick up a weapon,
	 * if they already have one.
	 */
	@Test
	public void testCannotPickupWeaponIfAlreadyHasWeapon()
	{
		MockLifeForm lifeForm = new MockLifeForm("Bob",40,10);
		PlasmaCannon plasmaCannon = new PlasmaCannon(10,10,10,10,10);
		lifeForm.pickUpWeapon(plasmaCannon);
		assertEquals(lifeForm.currentWeapon, plasmaCannon);
		PlasmaCannon plasmaCannon2 = new PlasmaCannon(10,10,10,10,10);
		lifeForm.pickUpWeapon(plasmaCannon2);
		assertEquals(lifeForm.currentWeapon, plasmaCannon);
	}
	
	/**
	 * Test that LifeForm can drop a weapon.
	 */
	@Test
	public void testDropWeapon()
	{
		MockLifeForm lifeForm = new MockLifeForm("Bob",40,10);
		PlasmaCannon plasmaCannon = new PlasmaCannon(10,10,10,10,10);
		lifeForm.pickUpWeapon(plasmaCannon);
		assertEquals(lifeForm.currentWeapon, plasmaCannon);
		lifeForm.dropWeapon();
		assertNull(lifeForm.currentWeapon);
	}
	
	/**
	 * Test that LifeForm can use a weapon.
	 */
	@Test
	public void testCanUseWeapon()
	{
		MockLifeForm lifeForm = new MockLifeForm("Bob",40,15);
		
		Environment env = Environment.getWorldInstance();
		env.clear();
		env.addLifeForm(0, 0, lifeForm);
		
		PlasmaCannon plasmaCannon = new PlasmaCannon(10,10,10,10,10);
		lifeForm.pickUpWeapon(plasmaCannon);
		
		lifeForm.attackLifeForm(lifeForm);
		assertEquals(lifeForm.currentLifePoints, 30);
	}
	
	/**
	 * Test that LifeForm can't use a weapon without ammo.
	 */
	@Test
	public void testCannotUseWeaponWithoutAmmo()
	{
		MockLifeForm lifeForm = new MockLifeForm("Bob",40,0); 
       
		Environment env = Environment.getWorldInstance();
		env.clear();
		env.addLifeForm(0, 0, lifeForm);
		
		//setting lifeform attack to 0, should ensure no damage is done
		PlasmaCannon plasmaCannon = new PlasmaCannon(10,10,10,10,0);
		lifeForm.pickUpWeapon(plasmaCannon);
		
		lifeForm.attackLifeForm(lifeForm);
		
		assertEquals(lifeForm.currentLifePoints, 40);
	}
	
	/**
	 * Test that LifeForm can attack if weapon has no ammo
	 */
	@Test
	public void testUseAttackIfNoAmmo()
	{
		MockLifeForm lifeForm = new MockLifeForm("Bob",40,15);
		
		Environment env = Environment.getWorldInstance();
		env.clear();
		env.addLifeForm(0, 0, lifeForm);
		 
		PlasmaCannon plasmaCannon = new PlasmaCannon(10,10,10,10,0);
		lifeForm.pickUpWeapon(plasmaCannon);
		
		lifeForm.attackLifeForm(lifeForm);
		
		assertEquals(lifeForm.currentLifePoints, 25);
	}
	
	/**
	 * Test that LifeForm can't fire a weapon out of range.
	 */
	@Test
	public void testTargetOutOfRange()
	{
		MockLifeForm lifeForm = new MockLifeForm("Bob",40,15);
		MockLifeForm lifeForm2 = new MockLifeForm("Bob",40,15);
		
		Environment env = Environment.getWorldInstance();
		env.clear();
		env.addLifeForm(1, 0, lifeForm);
		env.addLifeForm(1,2, lifeForm2);
		
		PlasmaCannon plasmaCannon = new PlasmaCannon(10,10,10,10,0);
		lifeForm.pickUpWeapon(plasmaCannon);
		lifeForm.attackLifeForm(lifeForm2);
		
		assertEquals(lifeForm2.currentLifePoints, 40);
	}
	
	/**
	 * Test that LifeForm can reload a weapon.
	 */
	@Test
	public void testReload()
	{
		MockLifeForm lifeForm = new MockLifeForm("Bob",40,15);
		PlasmaCannon plasmaCannon = new PlasmaCannon(10,10,10,10,0);
		lifeForm.pickUpWeapon(plasmaCannon);
		
		assertEquals(lifeForm.getGenericWeapon().getCurrentAmmo(),0);
		lifeForm.reloadWeapon();
		assertEquals(lifeForm.getGenericWeapon().getCurrentAmmo(),10);
	}
	
	/**
	 * Start Section for Observer Pattern Tests
	 */
	
	
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
		Environment env = Environment.getWorldInstance();
		env.clear();
		env.addLifeForm(0, 0, lifeForm);
		
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

