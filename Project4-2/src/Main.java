
public class Main 
{
	public static void main(String[] args) 
	{
		int[] numbers = new int[50];
		for(int i = 0; i < 50;i++)
		{
			numbers[i] = (int)(Math.random() * 100);
		}
		
		int count = 0;
		while(true)
		{
			System.out.println(numbers[count]);
			count++;
		}
	}
}
