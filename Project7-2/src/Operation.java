import java.util.concurrent.Semaphore;

public abstract class Operation extends Thread
{
    protected Buffer outBuffer;

    protected Buffer inBuffer;

    protected int value;

    protected Semaphore semaphore;

    public Operation(Buffer out, Buffer in, Integer value, Semaphore semaphore)
    {
        this.outBuffer = out;
        this.inBuffer = in;
        this.value = value;
        this.semaphore = semaphore;
        
    }
}
