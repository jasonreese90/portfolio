public class BinarySearch
{
    /*
     * Overloaded version of the recursive search function. It removes need to
     * specify a lo and a hi index
     */
    public static int search(int key, int[] a)
    {
        /*
         * call search with 0 as the low and the length of the array as hi
         */
        return search(key, a, 0, a.length);
    }

    public static int search(int key, int[] a, int lo, int hi)
    {
        // find the middle index of the array
        int mid = lo + (hi - lo) / 2;

        /*
         * compare the two integers a[mid] and key. A return value of 0 means
         * they are equal, less than 0 means a[mid] is smaller than key, and
         * greater than 0 means a[mid] is bigger than key
         * 
         */
        int cmp = Integer.compare(a[mid], key);

        /*
         * hi is less than or equal to low that means that the two indices have
         * converged and the key has not been found. Multiply -1 by mid -1 to
         * signify the last index the key was smaller than.
         * 
         */
        if (hi <= lo)
            return -1 * (mid - 1);

        /*
         * if cmp is greater than 0, then we need to search the left half of the
         * array, so pass lo and mid as the start and end indices.
         */
        if (cmp > 0)
            return search(key, a, lo, mid);
        /*
         * if cmp is less than 0, then we need to search the right half of the
         * array, so pass mid+1 and hi as the start and end indices.
         */
        else if (cmp < 0)
            return search(key, a, mid + 1, hi);
        /*
         * If both other conditons aren't met, then cmp is equal to zero and mid
         * is equal to the key, so we can return key
         */
        else
            return mid;
    }

    /*
     * Method for finding the last index of a given key in a sorted array
     */
    public static int findLastIndex(int[] a, int key, int startIndex)
    {
        /*
         * Loop through the array at the given start index up to the end index
         */
        for (int i = startIndex; i < a.length; i++)
        {
            /*
             * If a[i] is equal to the key, then continue to check the next
             * index
             */
            if (a[i] == key)
                continue;
            /*
             * When the a[i] is not equal to key then we have found the last
             * instance of the index of that key, which lies at i minus 1;
             */
            else
                return i - 1;
        }

        /*
         * return -1 if no instances of the key were found in the array
         */
        return -1;
    }

    public static void main(String[] args)
    {
        /*
         * Instance of in class that takes a filename and allows us to read from
         * the file
         */
        In in = new In(args[0]);
        /*
         * Read all the ints in the specified file in args[0] and store tham in
         * int array a.
         */
        int[] a = in.readAllInts();

        /*
         * Parse the key from args[1]
         */
        int key = Integer.parseInt(args[1]);

        /*
         * search for key in int array a and store result in an integer named
         * index.
         */
        int index = search(key, a);

        /*
         * If index is less than 0, than the key in the above search was not
         * found in the array and we simply print out the index.
         */
        if (index < 0)
            StdOut.println(index);
        /*
         * Otherwise if the index is greater than or equal to 0 then the key was
         * found. We call findLastIndex to find the last index that matches the
         * key in the sorted array and print it
         */
        else
            StdOut.println(findLastIndex(a, key, index));
    }
}