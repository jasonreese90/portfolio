/*
 * Implements a string stack using a linked list
 */
public class LinkedStackOfStrings
{
    /*
     * first node in linked list
     */
    private Node first;

    /*
     * Node class for our linked list
     */
    private class Node
    {
        /*
         * String item of the current node
         */
        private String item;
        /*
         * Next node in the linked list. If next is null the current item is the
         * last node in the linked list
         */
        private Node next;
    }

    /*
     * Method for determining if the stack is empty
     */
    public boolean isEmpty()
    {
        /*
         * if the first node is null, then there are no items on the stack
         */
        return (first == null);
    }

    /*
     * Method for adding items on top of the stack
     */
    public void push(String item)
    {
        // store first node so we don't lose it when creating a new first node
        Node oldFirst = first;

        // create new first node
        first = new Node();

        // assign it parameter item, which is a string
        first.item = item;

        // Assign first.next oldfirst to preserve the list order
        first.next = oldFirst;
    }

    /*
     * Method for removing items from the top of the stack
     */
    public String pop()
    {
        // store first.item in a temporary string so it can be returned later
        String item = first.item;

        /*
         * set the first node to first.next, effectively removing the current
         * first node from the list
         */
        first = first.next;

        // return the temp string we stored earlier
        return item;
    }

    /*
     * Method for determining if a specific string exists in the stack in any of
     * the node items
     */
    public boolean find(String item)
    {
        /*
         * Create a node instance and set it to the first node instance
         */
        Node node = first;

        /*
         * Loop until we find the search item or we hit null, if we hit null we
         * have reached the end of the list
         */
        while (node != null)
        {
            /*
             * Check if the node item contains the search string. If it does
             * return true
             */
            if (node.item.contains(item))
                return true;

            /*
             * Precede to the next node
             */
            node = node.next;
        }

        /*
         * If we exited the loop and have reached the point, then the search
         * string wasn't found and we can return false
         */
        return false;
    }

    public static void main(String[] args)
    {
        // Store the string in args[0] in search to be used later for searching
        String search = args[0];

        /*
         * Create an instance of our linked stack
         */
        LinkedStackOfStrings stack = new LinkedStackOfStrings();

        /*
         * Loop until Ctrl-Z (Windows) or Ctrl-D (Unix-like) is entered into
         * input
         */
        while (!StdIn.isEmpty())
        {
            // push the line from input to the stack
            stack.push(StdIn.readLine());
        }

        /*
         * Print out to the user if the string was found in the stack, using
         * printf and an inline conditional.
         */
        StdOut.printf("%s %s in the linked stack", search,
                stack.find(search) ? "exists" : "does not exist");

    }
}
