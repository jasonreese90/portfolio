import java.util.concurrent.Semaphore;

public class Divide extends Operation
{
    public Divide(Buffer out, Buffer in, Integer value, Semaphore semaphore)
    {
        super(out, in, value, semaphore);
    }

    @Override
    public void run()
    {
        if (value != 0)
        {
            try
            {
                semaphore.acquire();

                outBuffer.write(inBuffer.read() / value);
                System.out.println(inBuffer.read());

                semaphore.release();
            }
            catch (InterruptedException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }

        }
    }
}
