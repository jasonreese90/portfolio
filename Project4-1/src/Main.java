
public class Main 
{
	public static void main(String[] args) 
	{
		int previousNumber = 0;
		int currentNumber = 1;
		
		for(int i =0; i < 50;i++)
		{
			int temp = previousNumber;
			previousNumber = currentNumber;
			currentNumber += temp;
			System.out.println(currentNumber);
		}
	}
}
