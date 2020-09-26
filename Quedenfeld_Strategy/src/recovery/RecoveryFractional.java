//Jason Quedenfeld
package recovery;

/**
 * An implementation of RecoveryBehavior
 * that recovers a percentage of life points
 * every recovery.
 * 
 */
public class RecoveryFractional implements RecoveryBehavior
{
	private double recoveryPercentage;
	
	/**
	 * Creates a new RecoveryBehavior.
	 * @param percentage percentage to recover.
	 */
	public RecoveryFractional(double percentage)
	{
		recoveryPercentage = percentage;
	}
	
	/**
	 * Adjusts life points based on percentage.
	 */
	@Override
	public int calculateRecovery(int currentLife, int maxLife) 
	{
		if(currentLife == 0)
		{
			return 0;
		}
	
		currentLife += (int)(Math.ceil(currentLife * (recoveryPercentage/100.0f)));
		
		if(currentLife >= maxLife)
			return maxLife;
		
		return currentLife;
	}
}
