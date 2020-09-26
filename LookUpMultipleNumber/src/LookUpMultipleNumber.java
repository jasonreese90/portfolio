
public class LookUpMultipleNumber
{
    public static void main(String[] args)
    {
        /*
         * Instance of in class that takes a filename and allows us to read from
         * the file
         */
        In in = new In(args[0]);

        /*
         * Holds the max values to print out per key
         */
        int maxVal = Integer.parseInt(args[1]);

        /*
         * Holds the index that determines which field to use for the key in the
         * comma separated file
         */
        int keyField = Integer.parseInt(args[2]);

        /*
         * Holds the index that determines which field to use for the value in
         * the comma separated file
         */
        int valField = Integer.parseInt(args[3]);

        /*
         * Read each line of the command separated file into a string array for
         * later processing
         */
        String[] database = in.readAllLines();

        // StdRandom.shuffle(database);

        /*
         * Create a symbol table with a key type of string and a value type of
         * Queue<String>. This allows for duplicate keys to store multiple
         * values
         */
        ST<String, Queue<String>> st = new ST<String, Queue<String>>();

        /*
         * Loop through each line in the comma separated file
         */
        for (int i = 0; i < database.length; i++)
        {
            /*
             * Split each field in a given line using a comma delimter
             */
            String[] tokens = database[i].split(",");

            /*
             * Get the key from the split line, which is located at the index
             * specified in keyField
             */
            String key = tokens[keyField];

            /*
             * Get the value from the split line, which is located at the index
             * specified in valueField
             */
            String val = tokens[valField];

            /*
             * Create a queue variable
             */
            Queue<String> q;

            /*
             * Get the instance of Queue<String> for the particular key. If q is
             * null, then create a new instance of Queue<String>, and put it in
             * the symbol table using at key
             */
            if ((q = st.get(key)) == null)
            {
                q = new Queue<String>();
                st.put(key, q);
            }

            /*
             * Push the value onto the queue
             */
            q.enqueue(val);
        }

        /*
         * Loop until Ctrl-Z (Windows) or Ctrl-D (Unix-like) is entered into
         * input
         */
        while (!StdIn.isEmpty())
        {
            /*
             * Read the input from user and store it in a string
             */
            String s = StdIn.readString();

            /*
             * Get the current queue associated with the s
             */
            Queue<String> q = st.get(s);

            int count = 0;

            while (!q.isEmpty())
            {
                if (count < maxVal)
                {
                    StdOut.print(q.dequeue() + " ");
                } else
                {
                    break;
                }

                count++;
            }

            StdOut.print("\n");

        }
    }
}
