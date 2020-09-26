/**
 * An individual phlosopher who just eats and thinks
 * 
 * @author Merlin
 * 
 * Created: Sep 26, 2006
 */
public class Philosopher extends Thread
{
	private int id;
	private int left;
	private int right;

	private volatile static boolean[] forks = new boolean[5];

	/**
	 * Create a philosopher and tell him which forks to use
	 * 
	 * @param id
	 * @param left
	 * @param right
	 */
	public Philosopher(int id, int left, int right)
	{
		this.id = id;
		this.left = left;
		this.right = right;
	}

	/**
	 * @see java.lang.Thread#run()
	 */
	@Override
	public void run()
	{
		for (int i = 0; i < 10000; i++)
		{
			int l =  id != 0 ? left : right;
			int r = id != 0 ? right : left;
			
			pickUp(l);
			pickUp(r);
			eat();
			putDown(l);
			putDown(r);
			think();
		}
		System.out.println("Philosopher " + id + " is finished.");
	}

	private void putDown(int fork)
	{
		forks[fork] = false;
		System.out.println("Philosopher " + id + " put down fork #" + fork);

	}

	private void pickUp(int fork)
	{
		while (forks[fork])
		{
		}
		forks[fork] = true;
		System.out.println("Philosopher " + id + " picked up fork #" + fork);

	}

	private void eat()
	{
		for (int i = 0; i < 10000; i++)
		{
		}
	}

	private void think()
	{
		for (int i = 0; i < 10000; i++)
		{
		}
	}
}
