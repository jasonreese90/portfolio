import java.util.ArrayList;

/**
 * a data store between two threads
 * 
 * @author Merlin
 *
 */
public class Buffer
{
    private int size = 0;

    private int currentPosition = 0;

    private int value = 0;

    public Buffer(int size, int value)
    {
        this.size = size;
        this.values = new ArrayList<CalculationResult>(size);
        this.value = value;
    }

    private ArrayList<CalculationResult> values;

    /**
     * write an int into this buffer
     * 
     * @param x
     *            the int we should store
     */
    public void write(int x)
    {
        values.add(new CalculationResult(value, x));
    }

    /**
     * @return the next int in the buffer
     */
    public int read()
    {
            return values.get(values.size() - 1).getCurrentValue();   
    }

}
