import java.util.Scanner;


public class Lunacy 
{
	public static void run()
	{
		float modifier = 0.167f;
		
		Scanner scanner = new Scanner(System.in);
	
		float input = scanner.nextFloat();
		
		while(input >= 0.0f)
		{
			
			float newWeight = input * modifier;
			
			System.out.println(String.format("%.2f %.2f", input,newWeight));
			
			
			input = scanner.nextFloat();
		}
		
		scanner.close();
	}
}
