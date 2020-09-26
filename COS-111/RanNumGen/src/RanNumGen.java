import java.util.Random;

public class RanNumGen {

	// max value to use when generating numbers
	private static int numMax = 100;
	// min value to use when generating numbers
	private static int numMin = 1;

	public static void main(String[] args) {

		/*
		 * holds value of highest generated number, since numMin is the lowest value
		 * possible we will assign numHigh an initial value of numMin
		 */
		int numHigh = numMin;
		/*
		 * holds value of lowest generated number, since numMax is the highest value
		 * possible we will assign numLow an initial value of numMax
		 */
		int numLow = numMax;

		// random number class instance to be used for generating numbers
		Random rand = new Random();

		// check that there is at least one argument
		if (args.length > 0) {

			// holds value of how many numbers to generate
			int numToGen = 0;

			// check if valid number is entered
			try {
				// parse int from command line argument
				numToGen = Integer.parseInt(args[0]);
			}
			// catch exception if a valid number is not entered
			catch (NumberFormatException ex) {
				// notify user of invalid input and exit
				System.out.println("Argument must be an integer.");
				return;
			}

			// loop the number of times specified in command arg to generate numbers
			for (int i = 0; i < numToGen; i++) {
				// generate number between numMin and numMax inclusive
				int randNum = rand.nextInt(numMax - numMin + 1) + numMin;

				/*
				 * check if generated number is higher than our current high number if so store
				 * it in numHigh
				 */
				if (randNum > numHigh) {
					numHigh = randNum;
				}

				/*
				 * check if generated number is lower than our current low number if so store it
				 * in numLow
				 */
				if (randNum < numLow) {
					numLow = randNum;
				}

				/*
				 * print to console the generated number if not last number, add whitespace
				 * after number
				 */
				System.out.print(randNum + (i != numToGen - 1 ? " " : ""));
			}

			// end previous line
			System.out.print("\n");
			// notify user the lowest value generated
			System.out.println("The minimum value is " + numLow + ".");
			// notify user the highest value generated
			System.out.println("The maxmimum value is " + numHigh + ".");

		} else {
			// Notify user that there are no arguments
			System.out.println("Must enter one integer argument.");
		}

	}
}
