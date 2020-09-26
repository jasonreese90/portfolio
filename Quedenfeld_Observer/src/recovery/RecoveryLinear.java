//Jason Quedenfeld
package recovery;

/**
 * An implementation of RecoveryBehavior
 * that recovers a linear amount of
 * life points every recovery.
 * 
 */
public class RecoveryLinear implements RecoveryBehavior
{
	private int recoveryStep;
	
	/**
	 * Creates a new instance of RecoveryLinear.
	 * @param step the amount of life points to restore every recovery.
	 */
	public RecoveryLinear(int step)
	{
		recoveryStep = step;
	}
	
	/**
	 * Adjusts life points based on step.
	 */
	@Override
	public int calculateRecovery(int currentLife, int maxLife) 
	{
		if(currentLife == 0)
		{
			return 0;
		}
		
		currentLife += recoveryStep;
	
		if(currentLife > maxLife)
		{
			return maxLife;
		}
		
		return currentLife;
	}
}
	