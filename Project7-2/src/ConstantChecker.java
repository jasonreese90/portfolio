/**
 * @author Merlin
 *
 */
public class ConstantChecker
{
    private Buffer buffer;

    private int value;

    /**
     * @param buffer the buffer
     * @param value the value we expect it to have
     */
    public ConstantChecker(Buffer buffer, Integer value)
    {
        super();
        this.buffer = buffer;
        this.value = value;
    }

    /**
     * 
     */
    public void check()
    {

        int data = buffer.read();
        if (data != value)
        {
            System.out.println("Buffer error: data " + data);
        }
        else
        {
            System.out.println("No error: data " + data);
        }
    }

}
