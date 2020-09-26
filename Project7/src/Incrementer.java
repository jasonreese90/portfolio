/**
 * Reads from an input buffer, increments and writes to an output buffer unless
 * it is number 0. In that case, it just writes increasing integers to the
 * output buffer
 * 
 * @author Merlin
 *
 */
public class Incrementer extends Thread
{
	private Integer myNum;
	private Buffer inBuffer;
	private Buffer outBuffer;

	/**
	 * Create an incrementer
	 * 
	 * @param myNum
	 *            ignored unless it is zero
	 * @param inBuffer
	 *            the buffer to read from
	 * @param outBuffer
	 *            the buffer to write to
	 */
	public Incrementer(Integer myNum, Buffer inBuffer, Buffer outBuffer)
	{
		System.out.println("Initialized Incrementor with " + myNum);
		this.myNum = myNum;
		this.inBuffer = inBuffer;
		this.outBuffer = outBuffer;
	}

	/**
	 * @see java.lang.Thread#run()
	 */
	@Override
	public void run()
	{
		System.out.println("Running Incrementor with " + myNum);

		for (int i = 0; i < Starter1.NUMBER_OF_TRIALS; i++)
		{
			synchronized(this)
			{
			outBuffer.write(inBuffer.read()+ 1);
			}
		}

	}

}
