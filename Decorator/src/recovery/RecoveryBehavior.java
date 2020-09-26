//Jason Quedenfeld
package recovery;

/** 
 * Abstract interface for the basis of all
 * RecoveryBehaviors.
 */
public interface RecoveryBehavior
{
	/**
	 * Adjusts life points after calculation.
	 * 
	 * @param currentLife current life points possessed.
	 * @param maxLife upper limit of life points.
	 * @return returns the new calculated health after recovery.
	 */
	public int calculateRecovery(int currentLife, int maxLife);
}
