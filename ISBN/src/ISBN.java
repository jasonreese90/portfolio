public class ISBN
{
    /*
     * Calculates the check digit of an ISBN10 number, parameter takes the first
     * 9 digits of ISBN.
     */
    public static String calculateISBN(String isbn)
    {
        /*
         * Represents the sum of the digits of the isbn, each digit is
         * multiplied by 10 through 1 in a decending order then each product is
         * summed.
         */
        int sum = 0;

        /*
         * Loop through the first 9 digits of our ISBN
         */
        for (int i = 0; i < 9; i++)
        {
            /*
             * Converts a char located at index i in our ISBN to an int and
             * stores it in digit
             */
            int digit = Character.getNumericValue(isbn.charAt(i));

            /*
             * Calculate the product of the current digit in the ISBN with the
             * the difference of 10 and i. i represents the current index of the
             * ISBN and to calculate the product we need to calculate a integer
             * between 10 and 0 based on the current position, which is based on
             * the current position in the ISBN, in reverse order.
             */
            sum += digit * (10 - i);
        }

        /*
         * The tenth digit of the ISBN is the check digit. To get this we take
         * the sum calculated above and divide it by 11 the remainder of this is
         * then subtracted from 11 to find how far away from 11 the remainder
         * is.
         */
        int checkdigit = 11 - (sum % 11);

        /*
         * Ensure that the check digit is not 11, which means that the remainder
         * calculated above was 0, which means the sum was a multiple of 11. If
         * the check digit is a multiple of 11, then the check digit is 0, so we
         * set the check digit to 0
         * 
         */
        if (checkdigit == 11)
            checkdigit = 0;

        /*
         * ISBN check digit is represented by single digits 0 through 9, however
         * it is possible to have a check digit up to 10. In the case of a check
         * digit of 10, then X is used to represent 10.
         */
        if (checkdigit == 10)
            isbn += "X";
        /*
         * If the check digit is not 10 then we just add the check digit to the
         * end of the ISBN
         */
        else
            isbn += checkdigit;

        // return the ISBN with the appended check digit
        return isbn;
    }

    public static void main(String[] args)
    {
        /*
         * Notify user what the calculated ISBN with check digit is by using
         * printf and passing the return value of calculateISBN, which uses
         * command line argument 0 as the parameter for calculateISBN.
         */
        System.out.printf("The ISBN number would be %s\n",
                calculateISBN(args[0]));
    }

}
