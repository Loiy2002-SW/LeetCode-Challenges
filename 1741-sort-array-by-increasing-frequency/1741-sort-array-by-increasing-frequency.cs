public class Solution {
    public int[] FrequencySort(int[] nums) {
         return nums.GroupBy(x => x)
                   .OrderBy(g => g.Count()) 
                   .ThenByDescending(g => g.Key) 
                   .SelectMany(g => g)
                   .ToArray();
    }
}