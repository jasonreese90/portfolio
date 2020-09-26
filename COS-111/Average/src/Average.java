import java.util.Scanner;

public class Average {

	/* 
	 * Person is a class used to store information about a person, entered by the user
	 * instead of using multiple arrays to store individual values for each person
	 * it is more efficient to create a single array of objects representing
	 * the same information
	 */
	private static class Person {
		//Holds the value of the persons name
		private String name;
		//Holds the value of num1, which is used to calculate average
		private int num1;
		//Holds the value of num2, which is used to calculate average
		private int num2;
		//Holds the value of num3, which is used to calculate average
		private int num3;

		/*
		 * Class constructor for the person class, which takes the persons name and the
		 * three values that that are calculated in their average as parameters
		 */
		public Person(String name, int num1, int num2, int num3) {
			// Assign the parameter "name" to the class variable "name"
			this.name = name;
			// Assign the parameter "num1" to the class variable "num1"
			this.num1 = num1;
			// Assign the parameter "num2" to the class variable "num2"
			this.num2 = num2;
			// Assign the parameter "num3" to the class variable "num3"
			this.num3 = num3;
		}

		/*
		 * Accessor for accessing the private class field "name"
		 */
		public String getName() {
			return this.name;
		}

		/*
		 * Accessor for accessing the private class field "num1"
		 */
		public int getNum1() {
			return this.num1;
		}

		/*
		 * Accessor for accessing the private class field "num2"
		 */
		public int getNum2() {
			return this.num2;
		}

		/*
		 * Accessor for accessing the private class field "num3"
		 */
		public int getNum3() {
			return this.num3;
		}

		/*
		 * Function for calculating the persons average using the fields num1, num2, and
		 * num3
		 */
		public double getAverage() {
			return (double) (this.num1 + this.num2 + this.num3) / 3.0;
		}

	}

	public static void main(String[] args) {

		/*
		 * Create an instance of the scanner class to read input from the console, using
		 * System.in as the InputStream
		 */
		Scanner scanner = new Scanner(System.in);

		/*
		 * numPeople holds the number of people to parse from console input, specified
		 * by the user in command line argument 0
		 */
		int numPeople = Integer.parseInt(args[0]);

		/*
		 * holds the current iteration for our while loop
		 */
		int currIter = 0;

		/*
		 * Creates array of the Person class initialized to the size held in numPeople
		 */
		Person[] people = new Person[numPeople];

		/*
		 * loop while the scanner has valid input and does not contain the value of EOF
		 * (end of file)
		 */
		while (scanner.hasNext()) {

			/*
			 * retrieves the next string in the input stream and stores it in name
			 */
			String name = scanner.next();

			/*
			 * The while loop allows input indefinitely until Ctrl-D (Ctrl-Z on windows) is
			 * pressed however it is important to not assign the anything to the array after
			 * the size specified by the user because it will result in an out of bounds
			 * index.
			 */
			if (currIter < numPeople) {

				// Retrieve the next value from the input stream and store it in num1
				int num1 = scanner.nextInt();
				// Retrieve the next value from the input stream and store it in num2
				int num2 = scanner.nextInt();
				// Retrieve the next value from the input stream and store it in num3
				int num3 = scanner.nextInt();

				/*
				 * Assign a new instance of person at the specified index based on the current
				 * iteration of the loop
				 */
				people[currIter] = new Person(name, num1, num2, num3);
			}

			// Increment currIter before proceeding to the next iteration of the loop
			currIter++;
		}

		/*
		 * The scanner class must be closed before it goes out of scope simply allowing
		 * it go out of scope will result in resources that are not freed and will cause
		 * a leak
		 */
		scanner.close();

		/*
		 * Signify that the EOF key combination has been pressed
		 */
		System.out.println("<Ctrl-D>\n");

		/*
		 * Loop through each person stored in the array using a for each loop
		 */
		for (Person person : people) {

			/*
			 * Prints a formatted string to the user
			 */
			System.out.printf("%s %d %d %d %.2f\n", person.getName(), person.getNum1(), person.getNum2(),
					person.getNum3(), person.getAverage());
		}
	}
}
