
public class TriangularTest {

	/*
	 * Function that determines if 3 provided lenths are triangular
	 */
	public static boolean IsTriangular(int a, int b, int c) {
		/*
		 * By using the triangular inequality we know that each side of a triangle must
		 * be less or equal to the the sum of the other 2 sides to be triangle. We check
		 * for this condition and return true if all sides are less than the sum of the
		 * other sides, otherwise we return false
		 */
		return c <= (a + b) && b <= (a + c) && a <= (c + b);
	}

	public static void main(String[] args) {

		// holds the value of side a of a triangle
		int a = Integer.parseInt(args[0]);
		// holds the value of side b of a triangle
		int b = Integer.parseInt(args[1]);
		// holds the value of side c of a triangle
		int c = Integer.parseInt(args[2]);

		// convert the result of IsTriangular function to a string
		String result = Boolean.toString(IsTriangular(a, b, c));

		/*
		 * Print the result to the user, since Boolean.toString returns a string that is
		 * lowercase, and we want a string that is capitalized we take the substring of
		 * the result to get the first letter and make it uppercase and then append the
		 * remaining characters to the end of the substring
		 */
		System.out.println(result.substring(0, 1).toUpperCase() + result.substring(1));
	}

}
