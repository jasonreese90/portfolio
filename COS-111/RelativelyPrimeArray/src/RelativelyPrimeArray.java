import java.util.ArrayList;

public class RelativelyPrimeArray {

	public static void main(String[] args) {
		// holds value n from command line arg 1
		int n = 0;

		// parse int from command line argument
		n = Integer.parseInt(args[0]);

		/*
		 * create multi-dimensional array to hold boolean values that dictate whether
		 * the indices the represent each cell are coprime (relatively prime) true if
		 * coprime false if not.
		 */
		boolean[][] rpa = new boolean[n + 1][n + 1];

		/*
		 * outer loop the represents the rows in our multi-dimensional array x will
		 * start at 1 because the 0 index has no factors, therefore cannot be prime
		 */
		for (int x = 1; x <= n; x++) {

			/*
			 * inner loop the represents the columns in our multi-dimensional array y will
			 * start at 1 because the 0 index has no factors, therefore cannot be prime
			 */
			for (int y = 1; y <= n; y++) {

				/*
				 * if index x and index y are the same, then we know they are not relatively
				 * prime because they are the same number, so we can automatically set rpa at
				 * row x and column y to false.
				 */
				if (x == y) {
					rpa[x][y] = false;
					continue;
				}

				/*
				 * Determine if index x and index y are relatively prime in relation to each
				 * other, by using numbersAreRelativelyPrime method and store it in rpa located
				 * at row x and column y
				 */
				rpa[x][y] = numbersAreRelativelyPrime(x, y);
			}
		}

		/*
		 * prints the results to the user, in the specified format, regarding which
		 * indices are relatively prime in regards to each other using the printResults
		 * method, which takes our multi-dimensional array rpa as a parameters, as well
		 * as the number of indices n as a parameter.
		 */
		printResults(rpa, n);

	}

	/*
	 * prints the results to the user in the specified format using boolean
	 * multi-dimensional array rpa, which represents a table of relatively prime
	 * indices, and n the total number of rows and columns
	 */
	private static void printResults(boolean[][] rpa, int n) {

		/*
		 * loop that creates the heading for each column creates a column heading for
		 * each index, while x is less than or equal to n
		 */
		for (int x = 0; x <= n; x++) {
			/*
			 * if x is 0 add two blank spaces, and continue to next iteration of loop, we
			 * are not representing column 0 in the table.
			 */
			if (x == 0) {
				System.out.print("  ");
				continue;
			}

			// print the column heading, which is x
			System.out.print(Integer.toString(x) + " ");
		}

		/*
		 * after all the column headings are printed a new line can be printed, so that
		 * the first row can be printed on the following line.
		 */
		System.out.print("\n");

		/*
		 * outer loop that loops through the rows of rpa while x is less than or equal
		 * to n
		 */
		for (int x = 1; x <= n; x++) {

			/*
			 * print the row number before any true or false values are printed.
			 */
			System.out.print(Integer.toString(x) + " ");

			/*
			 * outer loop that loops through the columns of rpa while y is less than or
			 * equal to n
			 */
			for (int y = 1; y <= n; y++) {

				/*
				 * if index x and index y are the same, then we know they are not relatively
				 * prime because they are the same number, so we print two spaces to signify
				 * that index x and y are the same, and continue to the next iteration.
				 */
				if (x == y) {
					System.out.print("  ");
					continue;
				}

				/*
				 * if the value stored at index x and index y in rpa is true then print a T with
				 * a trailing white space.
				 */
				if (rpa[x][y]) {
					System.out.print("T ");
				}
				/*
				 * if the value stored at index x and index y in rpa is false then print a F
				 * with a trailing white space.
				 */
				else {
					System.out.print("F ");
				}
			}

			/*
			 * Starts a new line all the values in this row have been printed
			 */
			System.out.print("\n");
		}
	}

	/*
	 * Method for calcuating if two numbers are relatively prime in relation to each
	 * other. num1 represents the first number, while num2 represents the second.
	 */
	private static boolean numbersAreRelativelyPrime(int num1, int num2) {

		/*
		 * Integer array that holds all the factors of num1 to be used for comparing at
		 * a later time
		 */
		Integer[] num1Factors = getNumberFactors(num1);
		/*
		 * Integer array that holds all the factors of num2 to be used for comparing at
		 * a later time
		 */
		Integer[] num2Factors = getNumberFactors(num2);

		/*
		 * loop through each element in array num1Factors so each element can be
		 * compared to each element of array num2Factors, ignoring index 0 because index
		 * 0 will always be a 1, and relatively prime considers every number except 1
		 */
		for (int x = 1; x < num1Factors.length; x++) {

			/*
			 * loop through each element in array num2Factors so each element can be
			 * compared to each element , ignoring index 0 because index 0 will always be a
			 * 1, and relatively prime considers every number except 1
			 */
			for (int y = 1; y < num2Factors.length; y++) {
				/*
				 * if the values at index x and y in num1Factors and num2Factors respectively
				 * are equal, then they have a common factor other than 1 and are not relatively
				 * prime.
				 */
				if (num1Factors[x] == num2Factors[y]) {
					return false;
				}
			}
		}

		/*
		 * Return true because we have exited the loop without returing false, so we can
		 * assume no factors were similar excluding 1, so the numbers are relatively
		 * prime
		 */
		return true;
	}

	/*
	 * method for calculating the factors of the number passed in parameter num
	 * returns the factors as an array of Integers
	 */
	private static Integer[] getNumberFactors(int num) {

		/*
		 * ArrayList of Integers to hold the factors calculated, we will use an
		 * ArrayList instead of just an array because ArrayList can be dynamically sized
		 * easier than an array.
		 */
		ArrayList<Integer> factors = new ArrayList<Integer>();

		/*
		 * Loop through every number upto parameter num, starting at index 1, ignoring 0
		 * because division by 0 is impossible
		 */
		for (int i = 1; i <= num; i++) {
			/*
			 * using the mod operator to determine the remainder of num divided by i if
			 * there is no remainder then we know that i is a factor of num.
			 */
			if (num % i == 0) {
				// if i is a factor of num add it to our ArrayList
				factors.add(i);
			}
		}

		/*
		 * After all factors have been calculated we return our ArrayList as a regular
		 * array using the toArray method in the ArrayList class
		 */
		return factors.toArray(new Integer[factors.size()]);
	}
}
