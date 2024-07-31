public class Solution {
    public int MinHeightShelves(int[][] books, int shelfWidth) {
         int n = books.Length;
        int[] dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0; // No books means zero height

        for (int i = 1; i <= n; ++i)
        {
            int totalWidth = 0;
            int maxHeight = 0;

            for (int j = i - 1; j >= 0; --j)
            {
                totalWidth += books[j][0];
                if (totalWidth > shelfWidth)
                    break;

                maxHeight = Math.Max(maxHeight, books[j][1]);
                dp[i] = Math.Min(dp[i], dp[j] + maxHeight);
            }
        }

        return dp[n];
    }
}