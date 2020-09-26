//Jason Quedenfeld
package recovery;

import static org.junit.Assert.*;
import lifeform.Alien;
import lifeform.LifeForm;

import org.junit.Test;

/**
 * 
 * Tests the functionality provided by the RecoveryNone class
 *
 */
public class TestRecoveryNone 
{
	/**
	 * Tests that no life points are recovered ever.
	 */
	@Test
	public void testRecovery()
	{
		RecoveryNone rn = new RecoveryNone();
		
		int lifePoints = 40;
		int maxLifePoints =40;
		
		int result = rn.calculateRecovery(lifePoints, maxLifePoints);
		assertEquals(result ,maxLifePoints);
		
		
		//Tests that no life points are recovered despite having half life points.
		lifePoints = 20;
		result = rn.calculateRecovery(lifePoints, maxLifePoints);
		
		assertEquals(lifePoints,20);
	}
}
