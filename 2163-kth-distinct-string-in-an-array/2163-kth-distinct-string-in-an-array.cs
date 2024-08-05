public class Solution {
    public string KthDistinct(string[] arr, int k) {
        // Dictionary to count occurrences of each string
        Dictionary<string, int> countMap = new Dictionary<string, int>();
        
        // Count occurrences of each string
        foreach (string str in arr)
        {
            if (countMap.ContainsKey(str))
            {
                countMap[str]++;
            }
            else
            {
                countMap[str] = 1;
            }
        }

        // Iterate through the array to find the kth distinct string
        int distinctCount = 0;
        foreach (string str in arr)
        {
            if (countMap[str] == 1)
            {
                distinctCount++;
                if (distinctCount == k)
                {
                    return str;
                }
            }
        }

        // If fewer than k distinct strings, return an empty string
        return "";
    }
}