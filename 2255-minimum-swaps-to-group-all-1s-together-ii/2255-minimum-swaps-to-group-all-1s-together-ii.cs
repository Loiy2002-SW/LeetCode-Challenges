public class Solution {
    public int MinSwaps(int[] nums) {
               int totalOnes = 0;
        int n = nums.Length;

        // Calculate the total number of 1's in the array
        foreach (var num in nums)
        {
            if (num == 1)
                totalOnes++;
        }

        // If there are no 1's or all are 1's, no swap is needed
        if (totalOnes == 0 || totalOnes == n)
            return 0;

        // Initialize the sliding window and count the number of 0's
        int maxOnesInWindow = 0;
        int currentOnes = 0;

        // We will simulate the circular property by considering an array of double the length
        for (int i = 0; i < 2 * n; i++)
        {
            if (nums[i % n] == 1)
                currentOnes++;

            // When our window exceeds the size of totalOnes, we slide the window
            if (i >= totalOnes)
            {
                if (nums[(i - totalOnes) % n] == 1)
                    currentOnes--;
            }

            // Track the maximum number of 1's in any window of size totalOnes
            maxOnesInWindow = Math.Max(maxOnesInWindow, currentOnes);
        }

        // Minimum swaps required will be totalOnes - maxOnesInWindow
        return totalOnes - maxOnesInWindow;
    }
}