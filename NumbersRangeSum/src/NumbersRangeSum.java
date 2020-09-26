
public class NumbersRangeSum {

	/*
	 * Method for summing the the numbers between start and end, inclusive,
	 * recursively.
	 */
	public static int getSum(int start, int end) {
		/*
		 * if start is equal to end then we have reach the final iteration of the
		 * recursive loop, there is no need to continue, so we can return the final
		 * value to be summed, which is the end variable.
		 */
		if (start == end)
			return end;

		/*
		 * add the return value of getSum to the value passed into the start parameter
		 * and return the value
		 */
		return start + getSum(start + 1, end);
	}

	public static void main(String[] args) {

		/*
		 * holds the value for the start number to be used when summing numbers
		 */
		int start = Integer.parseInt(args[0]);
		/*
		 * holds the value for the end number to be used when summing numbers
		 */
		int end = Integer.parseInt(args[1]);

		/*
		 * Print out to the user a formatted string that states the start number and the
		 * end number, as well as the sum of all numbers between start and end,
		 * inclusively
		 */
		System.out.printf("The sum of natural numbers in range [%d,%d] is %d.", start, end, getSum(start, end));
	}

}
