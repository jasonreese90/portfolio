import java.util.Arrays;

public class MergeSort
{
    /*
     * Overloaded version of the recursive sort function. It allows us to
     * specify as sub-array inside the array to sort by using startIndex and
     * endInded, as well as removes the need to provide a temp array for sorting
     */
    public static void sort(Comparable[] a, int startIndex, int endIndex)
    {
        Comparable[] aux = new Comparable[a.length];
        sort(a, aux, startIndex, endIndex + 1);
    }

    /*
     * Overloaded version of the recursive sort function. It removes need to
     * specify a lo and a hi index, as well as removes the need to provide a
     * temp array for sorting
     */
    public static void sort(Comparable[] a)
    {
        Comparable[] aux = new Comparable[a.length];
        sort(a, aux, 0, a.length);
    }

    private static void sort(Comparable[] a, Comparable[] aux, int lo, int hi)
    {
        /*
         * if hi minus low is 1 or less this means that the end index(hi) is
         * smaller than the start index(lo) which means we have processed all
         * the indices, so we can return and exit the recursive loop.
         */
        if (hi - lo <= 1)
            return;

        // Find the middle index of the array
        int mid = lo + (hi - lo) / 2;

        // sort left half of the array
        sort(a, aux, lo, mid);
        // sort right half of the array
        sort(a, aux, mid, hi);

        // assign i and j the values of lo and mid respectively
        int i = lo, j = mid;

        /*
         * Merge sorted sub-arrays into aux
         */
        for (int k = lo; k < hi; k++)
        {
            /*
             * If i is equal to middle index, then aux at index k gets assigned
             * the value at index j in array a, and then j is incremented.
             */
            if (i == mid)
                aux[k] = a[j++];
            /*
             * if j is equal to the high index, then aux at index gets assigned
             * the value at index i in array a, then i is incremented.
             */
            else if (j == hi)
                aux[k] = a[i++];
            /*
             * If a[j] is smaller than a[i], then aux[k] is assigned the value
             * at index j in array a, then j is incremented
             */
            else if (a[j].compareTo(a[i]) < 0)
                aux[k] = a[j++];
            /*
             * if none of the above cases are true, then assign aux[k] the value
             * at a[i] and incremented i
             */
            else
                aux[k] = a[i++];
        }

        /*
         * Copy sorted array from aux into a
         */
        for (int k = lo; k < hi; k++)
        {
            a[k] = aux[k];
        }
    }

    public static void main(String[] args)
    {
        /*
         * Copy array starting from index 2 to string array a. This is done to
         * ignore the first 2 arguments, which are not strings, but specify the
         * sub-array indices.
         */
        String[] a = Arrays.copyOfRange(args, 2, args.length);

        // parse start index for sub-array from args[0]
        int start = Integer.parseInt(args[0]);
        // parse end index for sub-array from args[1]
        int end = Integer.parseInt(args[1]);

        /*
         * Call sort with params a, start, end. a is an an array of strings
         * copied from the command line arguments starting at index 2. start is
         * the index at which to start sorting, parsed from args[0], and end is
         * the index at which to stop sorting, parsed from args[1]
         * 
         */
        sort(a, start, end);

        /*
         * Print out the sorted elements of the array
         */
        for (int i = 0; i < a.length; i++)
        {
            StdOut.print(a[i] + " ");
        }

        //end the line
        StdOut.println();
    }
}
