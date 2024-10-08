public class Solution {
    public int MinSwaps(string s) {
        // Initialize counters for unmatched opening and closing brackets
        int open = 0;   // Count of unmatched opening brackets
        int close = 0;  // Count of unmatched closing brackets

        // Iterate through each character in the input string
        foreach(var c in s)
        {
            if(c == '[')
                // If we encounter an opening bracket, increment the 'open' counter
                open++;
            else if(c == ']')
            {
                if(open > 0)
                    // If there's an unmatched opening bracket, match it with this closing bracket
                    open--;
                else
                    // If there's no unmatched opening bracket, this is an unmatched closing bracket
                    close++;
            }
        }

        // Calculate the minimum number of swaps needed
        // We need to swap half of the unmatched closing brackets, plus one more if the count is odd
        return close / 2 + (close % 2);
    }
}