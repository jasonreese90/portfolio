import java.lang.reflect.InvocationTargetException;
import java.util.concurrent.Semaphore;

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

    private String[] behaviors = { "Multiply", "Add", "Divide", "Subtract" };

    private int[] values = { 3, 6, 3, 0 };

    private Buffer buffer;
    
    private Semaphore semaphore;

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
    public Starter1() throws ClassNotFoundException, NoSuchMethodException, SecurityException, InstantiationException, IllegalAccessException, IllegalArgumentException, InvocationTargetException,
            InterruptedException
    {
        int size = (int) (Math.random() * NUMBER_OF_TRIALS);
        buffer = new Buffer(size, size);
        final int numberOfPermits = 1;

        semaphore = new Semaphore(numberOfPermits, true);
     
        
        for(int i = 0; i < size;i++)
        {
            calculate(buffer,size);
     
        }
        
        ConstantChecker checker = new ConstantChecker(buffer, 2);
        checker.check();
    }
    
    private void calculate(Buffer buffer, int value) throws ClassNotFoundException, InstantiationException, IllegalAccessException, IllegalArgumentException, InvocationTargetException, NoSuchMethodException, SecurityException, InterruptedException
    {
        values[3] = value;
        buffer.write(value);
        
        Thread threads[] = new Thread[behaviors.length];
        
        for (int i = 0; i < behaviors.length; i++)
        {
            Class<?> behavior = Class.forName(behaviors[i]);

            threads[i] = (Thread) behavior.getConstructor(Buffer.class, Buffer.class, Integer.class, Semaphore.class).newInstance(buffer, buffer, values[i], semaphore);
            threads[i].start();

        }

        for (int i = 0; i < threads.length; i++)
        {
            threads[i].join();
        }
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
    public static void main(String[] args) throws ClassNotFoundException, NoSuchMethodException, SecurityException, InstantiationException, IllegalAccessException, IllegalArgumentException,
            InvocationTargetException, InterruptedException
    {

        new Starter1();

    }

}
