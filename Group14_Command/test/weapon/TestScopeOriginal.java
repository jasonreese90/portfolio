package weapon;

import static org.junit.Assert.*;

import org.junit.Test;

public class CopyOfTestScope
{
	@Test
	public void testScopeDamage()
	{
		ChainGun ch = new ChainGun(40,60,15,4,40);
		Scope sc = new Scope(ch);
		
		//with a range of 0, the chaingun has a base damage of 0, regardless
		//of any multiplier, the damage will still be 0
		assertEquals(0,sc.calculateDamage(0));
		
		//with the current range, the base damage of the chaingun would be 7
		//and the damage multiplier will be 1.5, so the total is 10.5 truncated
		//to 10
		assertEquals(10,sc.calculateDamage(30));
		
		//with the current range, the base damage of the chaingun would be 15
		//and the multiplier will be 2, so the total damage should be 30
		assertEquals(30,sc.calculateDamage(60));
		
		//The scope allows a weapon to shoot 10 units further than its max range.
		//The chainGuns base damage at range 70 is the max base damage,which is 15. The multiplier
		//that the scope adds should be somewhere around 2.1 which equates to 32.5 which
		//then truncates to 32
		assertEquals(32,sc.calculateDamage(70));
		
		//The range is further away than what the scope bonus allows
		assertEquals(0,sc.calculateDamage(80));
	}

}
