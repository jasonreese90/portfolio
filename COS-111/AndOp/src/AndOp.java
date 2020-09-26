
public class AndOp {

	/*Holds the double value that represents the upper limit to our range 
	 * to be used in isDoubleBetweenRange
	 */
	private static double maxVal = 1.0;
	/*Holds the double value that represents the lower limit to our range 
	 * to be used in isDoubleBetweenRange
	 */
	private static double minVal = 0.0;

	public static void main(String[] args) {

		//holds the double value that represents command line argument 1
		double num1  = 0.0;
		//holds the double value that represents command line argument 2
		double num2  = 0.0;

		// check that there is at least two arguments
		if (args.length > 1) {

			// check that valid numbers are entered
			try {
				// parse double from command line argument 1
				num1 = Double.parseDouble(args[0]);
				// parse double from command line argument 2
				num2 = Double.parseDouble(args[1]);
			}
			// catch exception if a valid double is not entered
			catch (NumberFormatException ex) {
				// notify user of invalid input and exit
				System.out.println("Arguments must be doubles.");
				return;
			}
			
			/*Uses function isDoubleBetweenRange to check if num1 and num2 are 
			 * between the range stored in minVal and maxVal 
			 * if values are between print true to user, else print false
			 */
			if(isDoubleBetweenRange(num1,num2)) {
				System.out.println("true");
			}
			else {
				System.out.println("false");
			}
			
		}
		else {
			//Notify user that there are no arguments
			 System.out.println("Must enter two double arguments.");
		}
	}
	
	/* function to check whether or not parameters num1 and num2 are between
	 * static class variables minVal and maxVal.  
	 */
	private static boolean isDoubleBetweenRange(double num1, double num2) {
		//return true if num1 and num2 are greater than value in minVal and less than value in maxVal
		return (num1 > minVal && num1 < maxVal) && (num2 > minVal && num2 < maxVal);
	}
}
