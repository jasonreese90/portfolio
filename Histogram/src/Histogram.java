import java.math.BigDecimal;

public class Histogram
{
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
        return new BigDecimal(String.format("%.1f", d)).stripTrailingZeros()
                .toPlainString();
    }

    /*
     * Calculates the interval size given the left and right bounds, evenly
     * divided by n
     */
    private static double calculateIntervalSize(int n, int left, int right)
    {
        /*
         * Subtract the difference between left from right to find the
         * difference between them, and then divide by n to calculate the
         * interval size
         */
        return ((double) right - (double) left) / (double) n;
    }

    /*
     * Calculates which interval a value belongs in
     */
    private static int getIntervalIndex(double val, int n, double interval,
            int left, int right)
    {
        /*
         * Index is used to store the interval index the value is stored in. Set
         * index to -1 just in case for whatever reason the index isn't found,
         * and then the return value will be -1
         */
        int index = -1;

        /*
         * Loop through each interval, which is determined by parameter n
         */
        for (int i = 0; i < n; i++)
        {
            /*
             * Check whether or not the value belongs in a specific interval, by
             * making sure by making sure it is greater than or equal to the
             * minimum value of the interval and less than the maximum value
             */
            if (val >= left + (interval * i)
                    && val < left + (interval * (i + 1)))
            {
                /*
                 * i represents the current interval index that is being check,
                 * so if this condition is true, then the value belongs to the
                 * interval that is i, so assign index i and then we can break
                 * out of the loop because we found the index
                 */
                index = i;
                break;
            }
        }

        /*
         * Return the interval index
         */
        return index;
    }

    /*
     * Method for processing the histogram data into an array of n intervals
     */
    private static double[] processData(Queue<Double> queue, int n, int left,
            int right)
    {
        /*
         * Get the interval size in relation to left, right and and how be
         * intervals are specified
         */
        double interval = calculateIntervalSize(n, left, right);
        /*
         * Create a new array to hold each interval count with the size of n
         * intervals
         */
        double[] counts = new double[n];

        /*
         * Loop while the queue isn't empty
         */
        while (!queue.isEmpty())
        {
            /*
             * Remove the next value from the queue
             */
            double val = queue.dequeue();

            /*
             * Get the index of the interval that the value belongs to
             */
            int index = getIntervalIndex(val, n, interval, left, right);

            /*
             * Check to make sure the index wasn't -1. If it is, then the index
             * wasn't found, so do nothing
             */
            if (index != -1)
                /*
                 * Increments the interval count at the specified index
                 */
                counts[index]++;
        }

        /*
         * Return the array of interval counts
         */
        return counts;
    }

    /*
     * Method for drawing the histogram data
     */
    private static void drawHistogram(double[] counts, int left, int right)
    {
        /*
         * Get the length of the array of interval counts
         */
        int n = counts.length;

        /*
         * Calculate the interval size
         */
        double intervalSize = calculateIntervalSize(n, left, right);

        /*
         * Set the xscale with a minimum of -1 and a max of n to accommodate for
         * variable amount of intervals
         */
        StdDraw.setXscale(-1, n);

        /*
         * Draw the histogram bars
         */
        for (int i = 0; i < n; i++)
        {
            /*
             * Set the pen color to a light blue
             */
            StdDraw.setPenColor(StdDraw.BOOK_LIGHT_BLUE);
            /*
             * Draw the histogram block associated with the interval index
             * specified by i
             */
            StdDraw.filledRectangle(i, counts[i] / 2, 0.50, counts[i] / 2);
            /*
             * Set the pen color to black
             */
            StdDraw.setPenColor(StdDraw.BLACK);
            /*
             * Draw a black border around the histogram block
             */
            StdDraw.rectangle(i, counts[i] / 2, 0.50, counts[i] / 2);
        }

        /*
         * Store the number of labels needed to be drawn, which is equal to n +
         * 1, n being the number of intervals
         */
        int numLabels = n + 1;

        /*
         * Loop until i is equal to numLabels
         */
        for (int i = 0; i < numLabels; i++)
        {
            /*
             * Draw the x axis labels, remove any trailing zeros, since the code
             * allows from fractional intervals, only show the decimal place
             * when there is a fraction
             */
            StdDraw.text(i - 0.5, -0.5,
                    removeTrailingZeros(left + (i * intervalSize)));
        }

        /*
         * Loop until i is equal to n
         */
        for (int i = 0; i < n; i++)
        {
            /*
             * Draw the count of each interval on the histogram bar
             */
            StdDraw.text(0 + i, 0.5, Integer.toString((int) counts[i]));
        }
    }

    public static void main(String[] args)
    {
        /*
         * Queue to store the doubles parsed from standard input
         */
        Queue<Double> queue = new Queue<Double>();

        /*
         * Boolean used to determine whether or not the first line has been read
         * from standard input
         */
        boolean firstLine = true;

        /*
         * Holds the values parsed from the first line of the standard input n
         * being the number of intervals, left being the minimum value of the
         * histogram, and right being the maximum
         */
        int n = 0, left = 0, right = 0;

        /*
         * Loop until Ctrl-Z (Windows) or Ctrl-D (Unix-like) is entered into
         * input
         */
        while (!StdIn.isEmpty())
        {
            /*
             * Split the line read from standard input, using whitespace as a
             * delimiter
             */
            String[] tokens = StdIn.readLine().split(" ");

            /*
             * Check whether or not this is the first line read from standard
             * input, if it is there different actions that need to be taken
             */
            if (firstLine)
            {
                /*
                 * Parse the integer from tokens[0] that represents the number
                 * of intervals
                 */
                n = Integer.parseInt(tokens[0]);
                /*
                 * Parse the integer from tokens[1] that represents the left
                 * side of the histogram
                 */
                left = Integer.parseInt(tokens[1]);
                /*
                 * Parse the integer from tokens[2] that represents the right
                 * side of the histogram
                 */
                right = Integer.parseInt(tokens[2]);

                /*
                 * After the first line has been processed we can set the
                 * boolean variable to false, so that proceeding iterations will
                 * skip this conditional
                 */
                firstLine = false;

                /*
                 * Continue to the next iteration of the loop
                 */
                continue;
            }

            /*
             * Loop through each string in tokens, which is the data that is
             * split using a whitespace delimiter
             */
            for (String s : tokens)
            {
                /*
                 * Parse the double stored in the token, and enqueue it to the
                 * the queue
                 */
                queue.enqueue(Double.parseDouble(s));
            }
        }

        /*
         * Process the queue data, and store the resulting interval counts
         */
        double[] intervalCounts = processData(queue, n, left, right);

        /*
         * Holds the maximum value of the interval counts
         */
        double maxVal = 0;

        /*
         * Loop through each double stored in intervalCounts
         */
        for (double d : intervalCounts)
        {
            /*
             * If d is greater than maxVal store it in maxVal, as it is
             * currently the highest value found in intervalCounts
             */
            if (d > maxVal)
                maxVal = d;
        }

        /*
         * Set the yscale to with a minimum of -1 to account for labels and a
         * maximum of maxVal +1 to account for the largest bar of the histogram
         */
        StdDraw.setYscale(-1, maxVal + 1);

        /*
         * Draw the histogram
         */
        drawHistogram(intervalCounts, left, right);
    }
}