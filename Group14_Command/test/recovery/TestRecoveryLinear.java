//Jason Quedenfeld
package recovery;

import static org.junit.Assert.*;

import org.junit.Test;

/**
 * 
 * Tests the functionality provided by the RecoveryLinear class
 *
 */
public class TestRecoveryLinear 
{
	/**
	 * 
	 * Tests that life points are not changed when life points are at max.
	 * 
	 */
	@Test
	public void testNoRecoveryWhenNotHurt()
	{
		RecoveryLinear rl = new RecoveryLinear(3);
		int maxLifePts = 30;
		int result = rl.calculateRecovery(maxLifePts,maxLifePts);
		assertEquals(maxLifePts,result);
	}
	
	/**
	 * 
	 * Tests that the correct amount of life points are recovered.
	 * 
	 */
	@Test
	public void testRecovery()
	{
		int step = 3;
		RecoveryLinear r1 = new RecoveryLinear(step);
		int maxLifePts = 30;
		int currentLifePts = 10;
		int result = r1.calculateRecovery(currentLifePts, maxLifePts);
		
		assertEquals(result, currentLifePts+step);
	}
	
	/**
	 * 
	 * Tests that life points can not exceed max life points.
	 * 
	 */
	@Test
	public void testRecoveryBounds()
	{
		RecoveryLinear r1 = new RecoveryLinear(3);
		
		int maxLifePts = 30;
		int currentLifePts = 29;
		int result = r1.calculateRecovery(currentLifePts, maxLifePts);
		assertEquals(maxLifePts,result);
		
		
	}
	
	/**
	 * 
	 * Tests that life points remain at 0 when dead.
	 * 
	 */
	@Test
	public void testNoRecoveryWhenDead()
	{
		RecoveryLinear r1 = new RecoveryLinear(3);
		
		int maxLifePts = 30;
		int currentLifePts = 0;
		int result = r1.calculateRecovery(currentLifePts, maxLifePts);
		assertEquals(currentLifePts,result);
	}
}
