//Jason Quedenfeld
package gameplay;

/**
 * 
 * An abstract interface used for classes wishing
 * to implement the functionality TimeObserver.
 *
 */
public interface TimeObserver 
{
	/**
	 * Called when receiving time update notifications.
	 * @param time time that is passed by the host upon notification
	 */
	public void updateTime(int time);
}
