public class Solution {
    public bool CanBeEqual(int[] target, int[] arr) {
        if (target.Length != arr.Length)
            return false;
        
        Dictionary<int, int> targetCount = new Dictionary<int, int>();
        Dictionary<int, int> arrCount = new Dictionary<int, int>();

        foreach (var num in target)
        {
            if (targetCount.ContainsKey(num))
                targetCount[num]++;
            else
                targetCount[num] = 1;
        }

        foreach (var num in arr)
        {
            if (arrCount.ContainsKey(num))
                arrCount[num]++;
            else
                arrCount[num] = 1;
        }

        foreach (var key in targetCount.Keys)
        {
            if (!arrCount.ContainsKey(key) || arrCount[key] != targetCount[key])
                return false;
        }

        return true;
    }
}