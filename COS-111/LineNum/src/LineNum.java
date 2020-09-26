public class LineNum
{
    public static void main(String[] args)
    {
        /*
         * Holds the index of the string to retrieve from the queue, parsed from
         * command line argument 0
         */
        int n = Integer.parseInt(args[0]);

        /*
         * Holds the string retrieved from the queue at index n.
         */
        String s = "";

        /*
         * Creates an instance of the Queue implementation. Since Queue is
         * generic, we provide them with the type of String
         */
        Queue<String> queue = new Queue<String>();

        /*
         * Loop until Ctrl-Z (Windows) or Ctrl-D (Unix-like) is entered into
         * input
         */
        while (!StdIn.isEmpty())
        {
            // Add line from input to the queue
            queue.enqueue(StdIn.readLine());
        }

        /*
         * Loop until the desired index is removed from the queue
         */
        for (int i = 0; i < n; i++)
        {
            // Remove element from queue and store it in s
            s = queue.dequeue();
        }

        /*
         * Print out the results to the user
         */
        StdOut.printf("%d from the first is %s\n", n, s);
    }
}
