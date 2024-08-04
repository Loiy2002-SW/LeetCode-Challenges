public class Solution {
    public int RangeSum(int[] nums, int n, int left, int right) {
       List<int> subarraySums = new List<int>();
        int MOD = 1000000007;
        
        // Calculate all subarray sums
        for (int i = 0; i < n; i++)
        {
            int currentSum = 0;
            for (int j = i; j < n; j++)
            {
                currentSum += nums[j];
                subarraySums.Add(currentSum);
            }
        }
        
        // Sort the subarray sums
        subarraySums.Sort();
        
        // Calculate the sum from the left to the right index (1-based)
        long result = 0;
        for (int i = left - 1; i <= right - 1; i++)
        {
            result = (result + subarraySums[i]) % MOD;
        }
        
        return (int)result; 
    }
}