public class Solution {
    public int SmallestDistancePair(int[] nums, int k) {
        Array.Sort(nums);
        int lo = 0, hi = nums[nums.Length-1]-nums[0];
        while(lo < hi){
            int mid = lo+(hi-lo)/2, count = 0;
            for(int i = 0, j = 0; i < nums.Length; i++){
                while(nums[i]-nums[j] > mid) j++;
                count += i-j;
            }
            if(count < k)
                lo = mid+1;
            else
                hi = mid;
        }
        return lo;
    }
}