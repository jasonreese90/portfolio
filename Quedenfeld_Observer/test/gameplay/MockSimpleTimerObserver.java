//Jason Quedenfeld
package gameplay;

/**
 * 
 * A mock class used to test the functionality of
 * SimpleTimerObserver.
 *
 */
public class MockSimpleTimerObserver implements TimeObserver
{
	public int myTime = 0;
	
	public void updateTime(int time)
	{
		myTime=time;
	}
}
