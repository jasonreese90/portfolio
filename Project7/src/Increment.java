
public class Increment implements MathBehavior
{
	public void calculate(Buffer inBuffer, Buffer outBuffer)
	{
	
			outBuffer.write(inBuffer.read()+ 1);
		
	}
}
