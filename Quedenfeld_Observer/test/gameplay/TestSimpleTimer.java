package gameplay;

import static org.junit.Assert.*;

import org.junit.Test;

/**
 * Tests the functionality of the SimpleTimer class.
 * 
 */
public class TestSimpleTimer
{
	/**
	 * At initialization, SimpleTimer should have a round value of 0, and no observers, and be
	 * an instance of Timer.
	 */
	@Test
	public void testInitialization()
	{
		SimpleTimer timer = new SimpleTimer();
		assertEquals(timer.round, 0);
		assertEquals(timer.getObserverCount(), 0);
		assertTrue(timer instanceof Timer);
	}
	
	/**
	 * Tests the ability to add Observers to the timer.
	 */
	@Test
	public void testAddObserver()
	{
		SimpleTimer timer = new SimpleTimer();
		MockSimpleTimerObserver m = new MockSimpleTimerObserver();
		timer.addTimeObserver(m);
		assertEquals(timer.getObserverCount(), 1);
	}
	
	/**
	 * Tests the ability to remove observers from the timer.
	 */
	@Test
	public void testRemoveObserver()
	{
		SimpleTimer timer = new SimpleTimer();
		MockSimpleTimerObserver m = new MockSimpleTimerObserver();
		timer.addTimeObserver(m);
		assertEquals(timer.getObserverCount(), 1);
		timer.removeTimeObserver(m);
		assertEquals(timer.getObserverCount(), 0);
	}
	
	/**
	 * Tests whether or not the time changed while timer possessed at least one observer.
	 */
	@Test
	public void testTimeChangedWithObserver()
	{
		SimpleTimer timer = new SimpleTimer();
		MockSimpleTimerObserver m = new MockSimpleTimerObserver();
		timer.addTimeObserver(m);
		timer.timeChanged();
		
		assertTrue(m.myTime > 0);
	}
	
	/**
	 * Tests whether or not the time changed while timer has no observers.
	 */
	@Test
	public void testTimeChangedWithoutObserver()
	{
		SimpleTimer timer = new SimpleTimer();
		timer.timeChanged();
		
		assertTrue(timer.round> 0);
	}
	
	/**
	 * This tests that SimpleTimer will update time once
	 * every second.
	 * @throws InterruptedException
	 */
	@Test
	public void testSimpleTimerAsThread() throws InterruptedException
	{
		SimpleTimer st = new SimpleTimer(1000);
		st.start();
		Thread.sleep(250);
		for(int x = 0; x<5;x++)
		{
			assertEquals(x,st.round);
			Thread.sleep(1000);
		}
	}
	
	/**
	 * Tests to ensure that the thread can be stopped and stopped safely.
	 * @throws InterruptedException
	 */
	@Test
	public void testStopThread() throws InterruptedException
	{
		SimpleTimer st = new SimpleTimer(1000);
		st.start();
		assertTrue(st.getIsTimerRunning());
		st.stopTimer();
		Thread.sleep(250);
		assertFalse(st.getIsTimerRunning());
		assertEquals(st.getState(),Thread.State.TERMINATED);
	}
}
