//Jason Quedenfeld
package weapon;

import static org.junit.Assert.*;

import org.junit.Test;

/**
 * 
 * Tests the functionality provided by the PlasmaCannon class
 *
 */
public class TestPlasmaCannon 
{
	/**
	 * make sure values are initialized correctly.
	 */
	@Test
	public void testInitialization()
	{
		PlasmaCannon weap = new PlasmaCannon(4,50,40,1,2);
		assertEquals(4,  weap.getMaxAmmo());
		assertEquals(50, weap.getMaxRange());
		assertEquals(40, weap.getBaseDamage());
		assertEquals(1,weap.getRateOfFire());
		assertEquals(2, weap.getCurrentAmmo());
	}
	
	/**
	 * make sure the plasma cannon calculates damage correctly.
	 */
	@Test
	public void testCalculateDamage()
	{
		PlasmaCannon weap = new PlasmaCannon(4,50,40,1,2);
		assertEquals(20,weap.calculateDamage(weap.maxRange-1));	
	}
	
	/**
	 * make sure that no damage can be done while out of ammo.
	 */
	@Test
	public void testCalculateDamageWithNoAmmo()
	{
		PlasmaCannon weap = new PlasmaCannon(4,50,40,1,0);
		assertEquals(0,weap.calculateDamage(weap.maxRange));	
	}
}
