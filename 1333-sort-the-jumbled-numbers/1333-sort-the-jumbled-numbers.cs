public class Solution {
    public int[] SortJumbled(int[] mapping, int[] nums) {
        
        int MapNumber(int num)
        {
            char[] digits = num.ToString().ToCharArray();
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = (char)('0' + mapping[digits[i] - '0']);
            }
            return int.Parse(new string(digits));
        }

        var mappedList = nums.Select(num => (original: num, mapped: MapNumber(num))).ToList();

        mappedList.Sort((a, b) =>
        {
            int cmp = a.mapped.CompareTo(b.mapped);
            return cmp != 0 ? cmp : Array.IndexOf(nums, a.original).CompareTo(Array.IndexOf(nums, b.original));
        });

        return mappedList.Select(x => x.original).ToArray();  
    }
}