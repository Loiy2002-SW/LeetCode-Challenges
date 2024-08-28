public class Solution {
    public int CountSubIslands(int[][] grid1, int[][] grid2) 
    {
        int cnt = 0;
        
        for(int i=0; i<grid2.Length; i++)
        {
            for(int j=0; j<grid2[0].Length; j++)
            {
                if(grid2[i][j]==1)
                {
                    bool isSubIsland = true;
                    Dfs(grid2,i,j,grid1, ref isSubIsland);
                    
                    if(isSubIsland)
                        cnt++;
                }
            }
        }
        
        return cnt;
    }
    
    int[] dX = {-1,1,0,0};
    int[] dY = {0,0,-1,1};
    
    private void Dfs(int[][] grid2, int x, int y, int[][] grid1, ref bool isSubIsland)
    {
        if(x<0 || x>= grid2.Length || y<0 || y>=grid2[0].Length || grid2[x][y]==0)
            return;
            
        if(grid2[x][y] == -1)
            return;
            
        grid2[x][y] = -1;
        
        if(grid1[x][y] == 0)
            isSubIsland = false;
        
        for(int i=0;i<4;i++)
        {
            int m = x + dX[i];
            int n = y + dY[i];
            
            Dfs(grid2,m,n,grid1,ref isSubIsland);
        }
    }
}