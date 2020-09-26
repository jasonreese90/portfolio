//Jason Quedenfeld
package recovery;

/**
 * An Implementation of RecoveryBehavior
 * that has no functionality.
 *
 */
public class RecoveryNone implements RecoveryBehavior
{
	/**
	 * Returns the currentLife.
	 */
	@Override
	public int calculateRecovery(int currentLife, int maxLife) 
	{
		return currentLife;
	}
	
}
