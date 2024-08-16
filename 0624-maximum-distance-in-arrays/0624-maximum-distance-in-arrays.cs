public class Solution {
    public int MaxDistance(IList<IList<int>> arrays) {
        int smallest = arrays[0][0];
        int biggest = arrays[0][arrays[0].Count - 1];
        int maxDistance = 0;

        for (int i = 1; i < arrays.Count; i++) 
        {
            maxDistance = Math.Max(maxDistance, Math.Abs(arrays[i][arrays[i].Count - 1] - smallest));
            maxDistance = Math.Max(maxDistance, Math.Abs(biggest - arrays[i][0]));
            smallest = Math.Min(smallest, arrays[i][0]);
            biggest = Math.Max(biggest, arrays[i][arrays[i].Count - 1]);
        }

        return maxDistance;
    }
}