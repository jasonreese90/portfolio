
public class Distribution100 {

	public static void main(String[] args) {

		// holds count for number of inputs above 50
		int numAbove = 0;
		// holds count for number of inputs less than or equal to 50
		int numBelow = 0;

		// holds the count value retrieved from command line arg 1
		int count = 0;

		// parse count from command line argument 1
		count = Integer.parseInt(args[0]);

		for (int i = 0; i < count; i++) {
			// holds value for next int to be parsed from args
			int num = 0;

			//parse int from command line argument at index i + 1
			num = Integer.parseInt(args[i + 1]);

			// if num is greater than 50 increment numAbove
			if (num > 50) {
				numAbove++;
			}
			// if num is less than or equal to 50 increment numBelow
			else {
				numBelow++;
			}

		}
		// output to user how many numbers were less than or equal to 50
		System.out.printf("%d numbers entered are less than or equal to 50.\n", numBelow);
		// output to user how many numbers were greater than 50
		System.out.printf("%d numbers entered are greater than 50.", numAbove);

	}
}
