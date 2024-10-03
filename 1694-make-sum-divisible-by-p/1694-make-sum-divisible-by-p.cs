public class Solution {
    public int MinSubarray(int[] nums, int p) {
        ReadOnlySpan<int> spanNums = nums;
        long totalSum = 0;

        for (int i = 0; i < spanNums.Length; i++) {
            totalSum += spanNums[i];
        }

        int targetRemainder = (int)(totalSum % p);
        if (targetRemainder == 0) return 0; 
        Dictionary<int, int> dict = new Dictionary<int, int>();
        dict[0] = -1;

        long currentSum = 0;
        int minLength = spanNums.Length;

        for (int i = 0; i < spanNums.Length; i++) {
            currentSum += spanNums[i];
            int currentRemainder = (int)(currentSum % p);

            int remainderToFind = (currentRemainder - targetRemainder + p) % p;

            if (dict.TryGetValue(remainderToFind, out int index)) {
                minLength = Math.Min(minLength, i - index);
            }

            dict[currentRemainder] = i;
        }
        return minLength == spanNums.Length ? -1 : minLength;
    }
}