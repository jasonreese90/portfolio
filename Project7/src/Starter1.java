import java.lang.reflect.InvocationTargetException;

/**
 * @author Merlin
 *
 * 
 */
public class Starter1
{

	/**
	 * The number of iterations each behavior should do
	 */
	public static final int NUMBER_OF_TRIALS = 10000;
	private String[] behaviors =
	{ "Increment", "Increment", "Increment", "Increment" };
	private Buffer buffer;

	/**
	 * spawn off all of the behaviors giving them appropriate input and output
	 * buffers
	 * 
	 * 
	 * @throws ClassNotFoundException
	 *             shouldn't
	 * @throws NoSuchMethodException
	 *             shouldn't
	 * @throws SecurityException
	 *             shouldn't
	 * @throws InstantiationException
	 *             shouldn't
	 * @throws IllegalAccessException
	 *             shouldn't
	 * @throws IllegalArgumentException
	 *             shouldn't
	 * @throws InvocationTargetException
	 *             shouldn't
	 * @throws InterruptedException
	 *             shouldn't
	 */
	public Starter1() throws ClassNotFoundException, NoSuchMethodException,
			SecurityException, InstantiationException, IllegalAccessException,
			IllegalArgumentException, InvocationTargetException,
			InterruptedException
	{
		Modifier threads[] = new Modifier[behaviors.length];
		buffer = new Buffer();
		buffer.write(1);
		for (int i = 0; i < behaviors.length; i++)
		{

			Class<?> behavior = Class.forName(behaviors[i]);

			MathBehavior mb = (MathBehavior)behavior.getConstructor().newInstance();
			threads[i] =  new Modifier(i, buffer,buffer,mb);
			threads[i].start();

		}
		for (int i = 0; i < threads.length; i++)
		{
			threads[i].join();
		}
		ConstantChecker checker = new ConstantChecker(buffer, NUMBER_OF_TRIALS
				* (behaviors.length ) + 1);
		checker.check();

	}

	/**
	 * @param args
	 *            none
	 * @throws InvocationTargetException
	 *             shouldn't
	 * @throws IllegalArgumentException
	 *             shouldn't
	 * @throws IllegalAccessException
	 *             shouldn't
	 * @throws InstantiationException
	 *             shouldn't
	 * @throws SecurityException
	 *             shouldn't
	 * @throws NoSuchMethodException
	 *             shouldn't
	 * @throws ClassNotFoundException
	 *             shouldn't
	 * @throws InterruptedException
	 *             shouldn't
	 */
	public static void main(String[] args) throws ClassNotFoundException,
			NoSuchMethodException, SecurityException, InstantiationException,
			IllegalAccessException, IllegalArgumentException,
			InvocationTargetException, InterruptedException
	{

		new Starter1();

	}

}
