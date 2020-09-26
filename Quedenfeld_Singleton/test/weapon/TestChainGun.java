package weapon;

import static org.junit.Assert.*;
import lifeform.LifeForm;

import org.junit.Test;

public class TestChainGun
{

	/**
	 * tests to make sure that our chaingun initializes properly
	 */
	@Test
	public void testInitialization()
	{
		ChainGun ch = new ChainGun(40,60,15,4,40);
		assertEquals(40,ch.getMaxAmmo());
		assertEquals(60,ch.getMaxRange());
		assertEquals(4,ch.getRateOfFire());
		assertEquals(15,ch.getBaseDamage());
	}
	
	/**
	 * Tests the damage that our chaingun deals at different ranges
	 */
	@Test
	public void testBaseDamage()
	{
		ChainGun ch = new ChainGun(40,60,15,4,40);
		

		assertEquals(0,ch.calculateDamage(0));
		assertEquals(7,ch.calculateDamage(30));
		assertEquals(15,ch.calculateDamage(60));
		assertEquals(0,ch.calculateDamage(70));


	}

}
