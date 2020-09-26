
public class LC {

	public static void main(String[] args) {
	
		/*Loops while i, with an initial value of 1, is less than equal to 
		 * 100 increments variable i by 1 every loop
		 */
		for(int i = 1; i <= 100;i++)
		{
			//print the number held in variable i and add trailing whitespace
			System.out.print(i + " ");
			
			/* check if the current value of i is evenly divided by 10
			 * signified by no remainder when using the mod operator
			 */
			if(i % 10 == 0) {
				/*if variable i has no remainder, then it's time to start a 
				 * new line by printing a newline escape sequence \n
				 */
				System.out.print("\n");
			}
		}
	}
}
