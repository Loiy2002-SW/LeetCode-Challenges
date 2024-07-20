public class Solution {
     public int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
        int numRows = rowSum.Length;
        int numCols = colSum.Length;
        
        int[][] result = new int[numRows][];
        for (int i = 0; i < numRows; i++) {
            result[i] = new int[numCols];
        }
        
        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
                int minVal = Math.Min(rowSum[i], colSum[j]);
                result[i][j] = minVal;
                rowSum[i] -= minVal;
                colSum[j] -= minVal;
            }
        }
        
        return result;
    }
}
