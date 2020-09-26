import java.util.Scanner;


public class TextRoll 
{
	public static void run()
	{
		Scanner scanner = new Scanner(System.in);
		
		int input = scanner.nextInt();
		scanner.nextLine();
		while(input != 0)
		{
		
			int column = 0;
			
			for(int i = 0; i < input;i++)
			{
				String text = scanner.nextLine();
				
				if(text.length() >= column)
				{
				text = text.substring(column);
				
				column += text.indexOf(" ");
				}
			}
			
			System.out.println(column+1);
			
			input = scanner.nextInt();
			scanner.nextLine();
		}
		
		scanner.close();
	}
}
