

public class Solution
{
    private int[] directions = { 0, 1, 0, -1, 0 };

    public int MinDays(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        if (CountIslands(grid) != 1)
            return 0;

        // Try to disconnect the grid by removing one land cell
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 1)
                {
                    grid[i][j] = 0;
                    if (CountIslands(grid) != 1)
                        return 1;
                    grid[i][j] = 1;
                }
            }
        }

        // If we can't disconnect the grid by removing one cell, return 2
        return 2;
    }

    private int CountIslands(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        bool[,] visited = new bool[rows, cols];
        int islands = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 1 && !visited[i, j])
                {
                    DFS(grid, i, j, visited);
                    islands++;
                }
            }
        }

        return islands;
    }

    private void DFS(int[][] grid, int row, int col, bool[,] visited)
    {
        visited[row, col] = true;
        for (int k = 0; k < 4; k++)
        {
            int newRow = row + directions[k];
            int newCol = col + directions[k + 1];
            if (newRow >= 0 && newRow < grid.Length && newCol >= 0 && newCol < grid[0].Length && 
                grid[newRow][newCol] == 1 && !visited[newRow, newCol])
            {
                DFS(grid, newRow, newCol, visited);
            }
        }
    }
}
