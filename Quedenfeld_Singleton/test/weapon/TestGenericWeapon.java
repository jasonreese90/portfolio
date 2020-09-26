//Jason Quedenfeld
package weapon;

import static org.junit.Assert.*;
import lifeform.MockLifeForm;
import gameplay.SimpleTimer;

import org.junit.Test;

/**
 * 
 * Tests the functionality provided by the GenericWeapon class
 *
 */
public class TestGenericWeapon
{

	/**
	 * Tests that the weapon cannot fire until round changes.
	 */
	@Test
	public void testRateOfFire()
	{
		SimpleTimer timer = new SimpleTimer();
	    MockGenericWeapon weapon = new MockGenericWeapon(40,20,20,3,40);
	    MockLifeForm lifeForm = new MockLifeForm("Bob",40);
	    
	    timer.addTimeObserver(weapon);
	    assertEquals(weapon.currentAmmo,40);
	    GenericWeapon.fire(lifeForm,weapon, weapon.maxRange-1);
	    assertEquals(weapon.currentAmmo,39);
	    GenericWeapon.fire(lifeForm,weapon, weapon.maxRange-1);
	    assertEquals(weapon.currentAmmo,38);
	    GenericWeapon.fire(lifeForm,weapon, weapon.maxRange-1);
	    assertEquals(weapon.currentAmmo,37);
	    GenericWeapon.fire(lifeForm,weapon, weapon.maxRange-1);
	    assertEquals(weapon.currentAmmo,37);
	    
	    timer.timeChanged();
	    GenericWeapon.fire(lifeForm,weapon, weapon.maxRange-1);
	    assertEquals(weapon.currentAmmo,36);
	}
	
	/**
	 * tests our generic weapon parent class to make sure that it functions properly
	 */
	@Test
	public void testInitalization()
	{
		MockGenericWeapon weap = new MockGenericWeapon(100,50,20, 10,100);
		assertEquals(20,weap.calculateDamage());	    
		assertEquals(100,  weap.getMaxAmmo());
		assertEquals(50, weap.getMaxRange());
		assertEquals(20, weap.getBaseDamage());
		assertEquals(10,weap.getRateOfFire());
		assertEquals(100, weap.getCurrentAmmo());
		
	}
	
	/**
	 * Tests reloading.
	 */
	@Test
	public void testReload()
	{
		MockGenericWeapon weap = new MockGenericWeapon(100,50,20, 10, 50);
		assertEquals(50, weap.getCurrentAmmo());
		weap.reload();
		assertEquals(100, weap.getCurrentAmmo());
	}
	
	/**
	 * Tests ammo usage
	 */
	@Test
	public void testAmmoUsage()
	{
		MockLifeForm lifeForm = new MockLifeForm("Bob",40);
		MockGenericWeapon weap = new MockGenericWeapon(100,50,20, 10, 50);
		assertEquals(50, weap.getCurrentAmmo());
		GenericWeapon.fire(lifeForm, weap,weap.maxRange-1);
		assertEquals(49, weap.getCurrentAmmo());
	}
	
	
	/**
	 * Tests that ammo is used, but no damage is done when out of range.
	 */
	@Test
	public void testOutOfRange()
	{
		MockLifeForm lifeForm = new MockLifeForm("Bob",40);
		MockGenericWeapon weap = new MockGenericWeapon(100,50,20, 10, 50);
		assertEquals(50, weap.getCurrentAmmo());
		GenericWeapon.fire(lifeForm,weap, 51);
		assertEquals(49, weap.getCurrentAmmo());
		assertEquals(lifeForm.getCurrentLifePoints(),40);
	}
	
	/**
	 * make sure that no damage can be done while out of ammo.
	 */
	@Test
	public void testCalculateDamageWithNoAmmo()
	{
		MockGenericWeapon weap = new MockGenericWeapon(100,50,20, 10, 0);
		assertEquals(0,weap.calculateDamage(10));	
	}
	
	

}

/**
 * 
 * Mock class used for testing generic weapon
 *
 */
class MockGenericWeapon extends GenericWeapon
{
	/**
	 * 
	 * Creates an instance of generic weapon.
	 *
	 */
	public MockGenericWeapon(int maxAmmo, int maxRange, int baseDamage, int rateOfFire, int initialAmmo) 
	{
		super(maxAmmo, maxRange, baseDamage, rateOfFire, initialAmmo);
	}
	
	public int calculateDamage()
	{
		return calculateDamage(maxRange-1);
	}

	@Override
	public int calculateDamage(int distance) 
	{
		return currentAmmo == 0 ? 0 : baseDamage;
	}
}
