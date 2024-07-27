public class Solution {
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost) {
       var dist = new int[26][];
    for (int i = 0; i < 26; i++)
        dist[i] = new int[26];

    for (int i = 0; i < 26; i++)
        for (int j = 0; j < 26; j++)
            dist[i][j] = int.MaxValue / 2;

    for (int i = 0; i < original.Length; i++)
    {
        var s = original[i] - 'a';
        var d = changed[i] - 'a';

        if (cost[i] < dist[s][d])
            dist[s][d] = cost[i];
    }

    for (int i = 0; i < 26; i++)
        dist[i][i] = 0;

    for (int i = 0; i < 26; i++)
    {
        for (int j = 0; j < 26; j++)
        {
            for (int k = 0; k < 26; k++)
            {
                if (dist[j][k] > dist[j][i] + dist[i][k])
                    dist[j][k] = dist[j][i] + dist[i][k];
            }
        }
    }

    var result = 0L;
    for (int i = 0; i < source.Length; i++)
    {
        var s = source[i] - 'a';
        var d = target[i] - 'a';

        if (dist[s][d] == int.MaxValue / 2)
            return -1;
        else
            result += dist[s][d];
    }

    return result; 
    }
}