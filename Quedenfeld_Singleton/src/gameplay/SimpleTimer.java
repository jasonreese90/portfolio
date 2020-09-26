//Jason Quedenfeld
package gameplay;

import java.util.Vector;

/**
 * 
 * A Timer class used to keep track of time.
 *
 */
public class SimpleTimer extends Thread implements Timer 
{
	protected int round;
	private Vector<TimeObserver> theObservers;
	private int updateTime;
	private boolean run = true;
	
	/**
	 * Create a new instance of simple timer.
	 */
	public SimpleTimer()
	{
		this(0);
	}
	
	/**
	 * Create new instance of simple timer.
	 * @param updateTime the interval to update at.
	 */
	public SimpleTimer(int updateTime)
	{
		theObservers = new Vector<TimeObserver>();
		this.updateTime = updateTime;
	}
	
	
	/**
	 * Returns the amount of observers the timer contains.
	 * @return how many observers are subscribed to the timer.
	 */
	public int getObserverCount()
	{
		return theObservers.size();
	}
 
	
	@Override
	public void addTimeObserver(TimeObserver observer)
	{
		theObservers.add(observer);
	}
	
	
	@Override
	public void removeTimeObserver(TimeObserver observer)
	{
		theObservers.remove(observer);
	}
	
	/**
	 * notifies observers that time has changed.
	 */
	@Override
	public void timeChanged() 
	{
		round++;
		
		for(TimeObserver t : theObservers)
		{
			t.updateTime(round);
		}
	}
	
	/**
	 * stops the timer
	 */
	public void stopTimer()
	{
		run = false;
	}
	
	/**
	 * @return returns whether the timer is running or not.
	 */
	public boolean getIsTimerRunning()
	{
		return run;
	}
	
	/**
	 * Run the thread.
	 */
	public void run()
	{
		while(run)
		{
			try 
			{
				Thread.sleep(updateTime);
			} 
			catch (InterruptedException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
			timeChanged();
		}
	}
}
