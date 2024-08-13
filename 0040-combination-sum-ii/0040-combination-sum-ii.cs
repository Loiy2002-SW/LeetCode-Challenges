public class Solution
{
    List<int> partialRes = new List<int>();
    List<int> sortedCandidates;
    IList<IList<int>> res;
	
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        res = new List<IList<int>>();
        sortedCandidates = candidates.OrderBy(t => t).ToList();
        BackTrack(0, target);
        return res;
    }
	
    private void BackTrack(int currentCandidate, int currentTarget)
    {
        var prevC = -1;
        for (int i = currentCandidate; i < sortedCandidates.Count; i++)
        {
            var c = sortedCandidates[i];
            if (c > currentTarget)
                return;
            if (prevC == c)
                continue; 
            partialRes.Add(c);
            if (c == currentTarget)
                res.Add(partialRes.ToArray());
            else
                BackTrack(i + 1, currentTarget - c);
            partialRes.Remove(c);
            prevC = c;
        }
    }
}