//Jason Quedenfeld
package gameplay;

/**
 * 
 * An abstract interface providing the methods that need
 * to implemented to create a timer.
 * 
 */
public interface Timer
{
	/**
	 * Add an observer to receive updates from the timer.
	 * @param observer observer to be observed by the timer.
	 */
	public void addTimeObserver(TimeObserver observer);
	/**
	 * Removes a observer from receiving update notifications from the timer.
	 * @param observer observer to remove.
	 */
	public void removeTimeObserver(TimeObserver observer);
	/**
	 * called when the timer's time is changed.
	 */
	public void timeChanged();
}
