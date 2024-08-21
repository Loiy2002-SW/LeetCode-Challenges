public class Solution {
    public int StrangePrinter(string s) 
    {
        int n = s.Length;
        int[,] dp = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            dp[i, i] = 1;
        }

        for (int len = 2; len <= n; len++)
        {
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len - 1;
                dp[i, j] = len;

                for (int k = i; k < j; k++)
                {
                    if (s[i] == s[k + 1])
                    {
                        dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k + 1, j] - 1);
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k + 1, j]);
                    }
                }
            }
        }

        return dp[0, n - 1];
    }
}