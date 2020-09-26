/**
 * a data store between two threads
 * 
 * @author Merlin
 *
 */
public class Buffer
{

	private int x;

	/**
	 * write an int into this buffer
	 * 
	 * @param x
	 *            the int we should store
	 */
	public void write(int x)
	{

		synchronized(this)
		{
		this.x = x;
		}
	}

	/**
	 * @return the next int in the buffer
	 */
	public int read()
	{
		synchronized(this)
		{
		return x;
		}
	}

}
