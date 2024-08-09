public class Solution {
    public int NumMagicSquaresInside(int[][] grid) {
        int count = 0;

        // Iterate through each possible 3x3 subgrid
        for (int i = 0; i <= grid.Length - 3; i++)
        {
            for (int j = 0; j <= grid[0].Length - 3; j++)
            {
                if (IsMagic(grid, i, j))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static bool IsMagic(int[][] grid, int row, int col)
    {
        // A magic square must contain exactly the numbers 1-9
        HashSet<int> uniqueNumbers = new HashSet<int>();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int num = grid[row + i][col + j];
                if (num < 1 || num > 9 || !uniqueNumbers.Add(num))
                {
                    return false;
                }
            }
        }

        // Check the sum of rows, columns, and diagonals
        int sum1 = grid[row][col] + grid[row][col + 1] + grid[row][col + 2];
        int sum2 = grid[row + 1][col] + grid[row + 1][col + 1] + grid[row + 1][col + 2];
        int sum3 = grid[row + 2][col] + grid[row + 2][col + 1] + grid[row + 2][col + 2];

        int colSum1 = grid[row][col] + grid[row + 1][col] + grid[row + 2][col];
        int colSum2 = grid[row][col + 1] + grid[row + 1][col + 1] + grid[row + 2][col + 1];
        int colSum3 = grid[row][col + 2] + grid[row + 1][col + 2] + grid[row + 2][col + 2];

        int diagSum1 = grid[row][col] + grid[row + 1][col + 1] + grid[row + 2][col + 2];
        int diagSum2 = grid[row][col + 2] + grid[row + 1][col + 1] + grid[row + 2][col];

        return sum1 == 15 && sum2 == 15 && sum3 == 15 &&
               colSum1 == 15 && colSum2 == 15 && colSum3 == 15 &&
               diagSum1 == 15 && diagSum2 == 15;
    }
    
}