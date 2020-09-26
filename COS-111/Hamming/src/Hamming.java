public class Hamming
{
    /*
     * Calculates the hamming distance between 2 binary strings
     */
    private static int hammingDistance(String s1, String s2)
    {
        /*
         * Variable for holding the eventual distance
         */
        int count = 0;

        /*
         * loop through the length of the binary strings, since they are implied
         * to be equal length
         */
        for (int i = 0; i < s1.length(); i++)
        {
            /*
             * If the char at index i aren't the same in both strings, then
             * there is a difference, and hamming distance calculates the number
             * of different bits, so we increment the count
             */
            if (s1.charAt(i) != s2.charAt(i))
                count++;
        }

        /*
         * return the count, which is the hamming distance
         */
        return count;
    }

    /*
     * Generates of an array of binary strings, for the given number of bits in
     * n
     */
    private static String[] generateBinaryStrings(int n)
    {
        /*
         * Calculates the number of binary strings for the given number of bits,
         * which can be found by 2^n
         */
        int size = (int) Math.pow(2, n);

        /*
         * Create an array to hold the binary strings, using the size variable
         * as the size of the array, which ensures we have the correct number of
         * strings for the given number of bits
         */
        String[] s = new String[size];

        /*
         * Loop for each binary string combination, while i is less than size
         */
        for (int i = 0; i < size; i++)
        {
            /*
             * Place the formatted binary string in string array s, place them
             * at the calculated index at size - i -1, this ensures that the
             * binary representation of 0 will always be the last string in the
             * array, which will produce an array that is in descending order.
             * The binary string is formatted by using Integer.toBinaryString,
             * however this removes any leading zeros, so to retain leading
             * zeros we use String.format with %ns, where n is the number of
             * bits, so for example if n = 4 then the format string will end up
             * as %4s, this ensures a string is of a fixed length, by adding
             * leading white-spaces to any string that is smaller than the
             * specified size, all we have to do is simply replace the
             * white-spaces with 0s.
             */
            s[size - i - 1] = String.format("%" + Integer.toString(n) + "s",
                    Integer.toBinaryString(i)).replace(' ', '0');
        }

        /*
         * Return the now populated array
         */
        return s;
    }

    public static void main(String[] args)
    {
        /*
         * Parse the hamming distance to look for, and store it in k
         */
        int k = Integer.parseInt(args[0]);

        /*
         * Store the string in args[1] in s. This is the binary string we will
         * use for comparison
         */
        String s = args[1];

        /*
         * Loop through each string returned by generateBinaryStrings, which use
         * the the number of binary digits in string s as the parameter
         */
        for (String binaryStr : generateBinaryStrings(s.length()))
        {
            /*
             * Calculate the hamming distance between the current binary string
             * and the string provided for comparison, if it is equal to k,
             * which is the hamming distance to look for, then print the binary
             * string to the user 
             */
            if (hammingDistance(binaryStr, s) == k)
                System.out.print(binaryStr + " ");
        }
        
        //End the line
        System.out.print("\n");
    }
}
