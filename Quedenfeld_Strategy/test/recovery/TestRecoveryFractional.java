//Jason Quedenfeld
package recovery;
import static org.junit.Assert.*;

import org.junit.Test;

/**
 * 
 * Tests the functionality provided by the RecoveryFractional class
 *
 */
public class TestRecoveryFractional 
{
	/**
	 * 
	 * Tests that life points are not changed when life points are at max.
	 * 
	 */
	@Test
	public void testNoRecoveryWhenNotHurt()
	{
		RecoveryFractional rf = new RecoveryFractional(10);
		int maxLifePts = 30;
		int result = rf.calculateRecovery(maxLifePts,maxLifePts);
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
		int percentage = 10;
		RecoveryFractional rf = new RecoveryFractional(percentage);
		int maxLifePts = 30;
		int currentLifePts = 13;
		
		int recoveryAmount = (int)(Math.ceil(currentLifePts * (percentage/100.0f)));
		
		int result = rf.calculateRecovery(currentLifePts, maxLifePts);
		
		assertEquals(result, currentLifePts+recoveryAmount);
	}
	
	/**
	 * 
	 * Tests that life points can not exceed max life points.
	 * 
	 */
	@Test
	public void testRecoveryBounds()
	{
		RecoveryFractional rf = new RecoveryFractional(75);
		int maxLifePts = 30;
		int currentLifePts = 20;
		int result = rf.calculateRecovery(currentLifePts, maxLifePts);
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
		RecoveryFractional rf = new RecoveryFractional(75);
		
		int maxLifePts = 30;
		int currentLifePts = 0;
		int result = rf.calculateRecovery(currentLifePts, maxLifePts);
		assertEquals(currentLifePts,result);
	}
	
}
