public class Solution {
    public int RemoveStones(int[][] stones) {
        
        int n = stones.Length;
        bool[] visited = new bool[n];
        int islands = 0;

        for(int i=0;i<n;i++)
        {
            if(!visited[i])
            {
                DFS(stones,i,visited);
                islands++;
            }               
        }        
        return stones.Length - islands;
    }

    void DFS(int[][] stones,int curr,bool[] visited)
    {
        visited[curr] = true;

        for(int i=0;i<stones.Length;i++)
        {
            if(!visited[i] && (stones[i][0] == stones[curr][0] || stones[i][1] == stones[curr][1]))
                DFS(stones,i,visited);
        }
    } 
}