/*
 * Class the represents an Euclidean point
 */
public class Point
{
    // Field the represents the x value of the point
    private double x;
    // Field the represents the y value of the point
    private double y;
    // Field the represents the z value of the point
    private double z;

    /*
     * Constructor that takes x,y, and z as parameters these parameters are
     * stored in the class fields of x,y, an z
     */
    public Point(double x, double y, double z)
    {
        // assign field x the value of parameter x
        this.x = x;
        // assign field y the value of parameter y
        this.y = y;
        // assign field z the value of parameter z
        this.z = z;
    }

    /*
     * Calculates the distance between the current instance of Point and another
     * Point instance, which is calculated using sqrt( (x1-x2)^2 + (y1-y2)^2) +
     * (z1-z2)^2).
     */
    public double distanceTo(Point q)
    {
        /*
         * Calculate the difference between the current instance's x and
         * parameter q's x, which is used later for squaring.
         */
        double xDiff = this.x - q.x;
        /*
         * Calculate the difference between the current instance's y and
         * parameter q's y, which is used later for squaring.
         */
        double yDiff = this.y - q.y;
        /*
         * Calculate the difference between the current instance's z and
         * parameter q's z, which is used later for squaring.
         */
        double zDiff = this.z - q.z;

        /*
         * As mentiond previously Euclidean distance is calculated using sqrt(
         * (x1-x2)^2 + (y1-y2)^2) + (z1-z2)^2). So the we square xDiff, yDiff,
         * and yDiff, then sum all the squares and take the square root of the
         * sum, which results in the Euclidean distance, then return the
         * distance.
         */
        return Math.sqrt((xDiff * xDiff) + (yDiff * yDiff) + (zDiff * zDiff));
    }

    /*
     * All classes possess a toString method. We can override this to return any
     * string we want when toString is called on the class. In our case we are
     * returning a formatted string that contains the x,y, and z of the point
     */
    @Override
    public String toString()
    {
        return String.format("{%.1f,%.1f,%.1f}", x, y, z);
    }

    public static void main(String[] args)
    {
        /*
         * Parse the doubles representing the x,y, and z of the first point from
         * command line arguments 0 through 2
         */
        double x1 = Double.parseDouble(args[0]);
        double y1 = Double.parseDouble(args[1]);
        double z1 = Double.parseDouble(args[2]);

        /*
         * Parse the doubles representing the x,y, and z of the second point
         * from command line arguments 3 through 5
         */
        double x2 = Double.parseDouble(args[3]);
        double y2 = Double.parseDouble(args[4]);
        double z2 = Double.parseDouble(args[5]);

        /*
         * Create a new point p1 using parsed doubles x1,y1, and z1
         */
        Point p1 = new Point(x1, y1, z1);
        /*
         * Create a new point p2 using parsed doubles x2,y2, and z2
         */
        Point p2 = new Point(x2, y2, z2);

        /*
         * Notify user the x,y,z of the first point, by calling using printf and
         * using p1.toString as the argument
         */
        System.out.printf("The first point is %s\n", p1);
        /*
         * Notify user the x,y,z of the second point, by calling using printf
         * and using p2.toString as the argument
         */
        System.out.printf("The second point is %s\n", p2);
        /*
         * Output to user the Euclidean distance between p1 and p2. We format it
         * to only 2 decimal places, however printf when using .2f rounds up, so
         * we first floor the distance and multiply it by 100 to move the 2
         * decimal places left of the decimal point, then we divide by 100 to
         * convert it back to a to a decimal limited to two places, which makes
         * it so the decimal number is not rounded. An example of this is 2.956
         * printf would round this to 2.96 if using .2f to limit it to 2 decimal
         * places, but by flooring as stated above it first gets converted to
         * 295.0 then divided by 100 produces 2.95, with no rounding taking
         * place.
         */
        System.out.printf("Their Euclidean distance is %.2f\n",
                Math.floor(p1.distanceTo(p2) * 100) / 100.0);
    }
}
