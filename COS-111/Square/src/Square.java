import java.math.BigDecimal;

public class Square
{
    /*
     * Holds the x coordinate of the upper-left corner of the square
     */
    private double x;
    /*
     * Holds the y coordinate of the upper-left corner of the square
     */
    private double y;

    /*
     * Holds the length of the sides of the square
     */
    private double length;

    /*
     * Constructor that takes x and y coordinates of the upper-left corner of
     * the square and the lengths of the sides
     */
    public Square(double x, double y, double length)
    {
        /*
         * Assign parameter x to class field x
         */
        this.x = x;
        /*
         * Assign parameter y to class field y
         */
        this.y = y;
        /*
         * Assign parameter length to class field length
         */
        this.length = length;
    }

    /*
     * Calculates the area of the square
     */
    public double area()
    {
        /*
         * The area of a square is calculated by squaring the side length, so we
         * return length multiplied by length
         */
        return length * length;
    }

    /*
     * Calculate the perimeter of a square
     */
    public double perimeter()
    {
        /*
         * Perimeter is calculated by adding all sides, since a square has 4
         * sides that are all the same length, we simple return the side length
         * multiplied by 4
         */
        return length * 4.0;
    }

    /*
     * Determines if another square intersects with this instance of square
     */
    public boolean intersects(Square b)
    {
        /*
         * Calculate the the x coordinate for the lower-right corner of the
         * square for this instance of square
         */
        double x2 = this.x + this.length;
        /*
         * Calculate the the x coordinate for the lower-right corner of the
         * square for instance of square passed in the parameter
         */
        double bx2 = b.x + b.length;
        /*
         * Calculate the the y coordinate for the lower-right corner of the
         * square for this instance of square
         */
        double y2 = this.y + this.length;
        /*
         * Calculate the the y coordinate for the lower-right corner of the
         * square for instance of square passed in the parameter
         */
        double by2 = b.y + b.length;

        /*
         * Determine if the parameter square intersects with this instance of
         * square. For it to intersect the x coordinate of this instance must be
         * less than the x2 of the parameter instance and the x2 coordinate of
         * this instance must be greater than the x coordinate of the parameter
         * instance and the y coordinate of this instance must be less than the
         * y2 coordinate of the parameter instance and finally the y2 coordinate
         * of this instance must be greater than the y coordinate of the
         * instance
         */
        return (this.x < bx2 && x2 > b.x && this.y < by2 && y2 > b.y);
    }

    public boolean contains(Square b)
    {
        /*
         * Calculate the the x coordinate for the lower-right corner of the
         * square for this instance of square
         */
        double x2 = this.x + this.length;
        /*
         * Calculate the the x coordinate for the lower-right corner of the
         * square for instance of square passed in the parameter
         */
        double bx2 = b.x + b.length;
        /*
         * Calculate the the y coordinate for the lower-right corner of the
         * square for this instance of square
         */
        double y2 = this.y + this.length;
        /*
         * Calculate the the y coordinate for the lower-right corner of the
         * square for instance of square passed in the parameter
         */
        double by2 = b.y + b.length;

        /*
         * Determine if the parameter square is contained in this instance of
         * square. For it to be completely contained the x coordinate of the
         * current instance must be less than the parameter x coordinate, and
         * the y coordinate of this instance must be less than the y coordinate
         * of the parameter and the x2 coordinate of this instance must be
         * greater than the x2 coordinate of parameter instance and finally the
         * y2 coordinate of this instance must be greater than the y2 coordinate
         * of the parameter instance
         */
        return (this.x < b.x && this.y < b.y && x2 > bx2 && y2 > by2);
    }

    /*
     * Draw the square
     */
    public void draw()
    {
        /*
         * Set the pen color to black
         */
        StdDraw.setPenColor(StdDraw.BLACK);
        /*
         * Draw the square, since StdDraw.draw takes the x and y coordinates
         * from the center of the square and we store the left-upper corner in
         * the class, we need to drive the length by 2 and add it to x and y to
         * find the center position of the square, finally the length parameter
         * of the StdDraw.draw method takes a half length, so pass length
         * divided by 2
         */
        StdDraw.square(x + length / 2, y + length / 2, length / 2);
    }

    /*
     * Method for removing trailing zeros on a double using the BigDecimal class
     */
    private static String removeTrailingZeros(double d)
    {

        /*
         * Creates a new instance of BigDecimal, passes it parameter d as a
         * string, the calls the stripTrailingZeros method of BigDecimal to
         * remove trailing zeros, and then calls the toString method to return
         * it as a string
         */
        return new BigDecimal(Double.toString(d)).stripTrailingZeros()
                .toPlainString();
    }

    public static void main(String[] args)
    {
        /*
         * holds the x and y coordinates of the upper-left corner of the square
         * and the length of its sides, parsed from the first 3 command line
         * arguments, respectively
         */
        double x, y, len;
        /*
         * Parse the double that represents the x coordinate of the upper-left
         * corner of the square, and store it in x
         */
        x = Double.parseDouble(args[0]);
        /*
         * Parse the double that represents the y coordinate of the upper-left
         * corner of the square, and store it in y
         */
        y = Double.parseDouble(args[1]);
        /*
         * Parse the double that represents the length of the sides of the
         * square and store it in len
         */
        len = Double.parseDouble(args[2]);

        /*
         * Create a new instance of square and pass it x,y, and len as the
         * parameters
         */
        Square sq = new Square(x, y, len);

        /*
         * Print out the area of the newly created square to the user, using
         * printf and passing it the format that takes a string, the string used
         * is returned from the removeTrailingZeros method
         */
        StdOut.printf("The area is %s\n", removeTrailingZeros(sq.area()));
        /*
         * Print out the permit of the newly created square to the user, using
         * printf and passing it the format that takes a string, the string used
         * is returned from the removeTrailingZeros method
         */
        StdOut.printf("The perimeter is %s\n",
                removeTrailingZeros(sq.perimeter()));

        /*
         * Prompt the user to input the coordinates and length for a new square
         */
        StdOut.print(
                "Enter the upper-left coordinates and the length of a square: ");

        /*
         * Read the coordinates input by the user, which should be separated by
         * spaces
         */
        String line = StdIn.readLine();

        /*
         * Split the string input by the user, using a space as the delimiter
         */
        String[] tokens = line.split(" ");

        /*
         * Since x,y, and len created earlier are no longer in use we can just
         * reassign them and parse the values into them for a new square. First
         * parse the double in tokens[0] and store it in x
         */
        x = Double.parseDouble(tokens[0]);
        /*
         * Parse the double in tokens[1] and store it in y
         */
        y = Double.parseDouble(tokens[1]);
        /*
         * Parse the double in tokens[2] and store it in len
         */
        len = Double.parseDouble(tokens[2]);

        /*
         * Create a new instance of square and pass it x,y, and len as the
         * parameters
         */
        Square sq2 = new Square(x, y, len);

        /*
         * Check if the new instance of the square intersects with the first
         * instance of square, if it does notify the user that it does, and if
         * it doesn't, then notify the user it doesn't
         */
        if (sq2.intersects(sq))
            StdOut.println("It intersects the first square.");
        else
            StdOut.println("It does not intersect the first square.");

        /*
         * Check if the new instance of the square contains the first instance
         * of square, if it does notify the user that it does, and if it
         * doesn't, then notify the user it doesn't
         */
        if (sq2.contains(sq))
            StdOut.println("It containss the first square.");
        else
            StdOut.println("It does not contain the first square.");

        /*
         * Set the xScale for StdDraw. I chose to take the larger of the the 2
         * lower-right corner x coordinates of the squares and add 0.25 for
         * padding to be used for the maximum value of the xscale to ensure that
         * the larger of the 2 squares fit in the window
         */
        StdDraw.setXscale(0,
                Math.max(sq.x + sq.length, sq2.x + sq2.length) + 0.25);
        /*
         * Set the yScale for StdDraw. I chose to take the larger of the the 2
         * lower-right corner y coordinates of the squares and add 0.25 for
         * padding to be used for the maximum value of the yscale to ensure that
         * the larger of the 2 squares fit in the window
         */
        StdDraw.setYscale(0,
                Math.max(sq.y + sq.length, sq2.y + sq2.length) + 0.25);

        /*
         * Draw the first square
         */
        sq.draw();
        /*
         * Draw the second square
         */
        sq2.draw();
    }
}
