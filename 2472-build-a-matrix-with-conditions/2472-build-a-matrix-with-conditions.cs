public class Solution {
    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions) {
        var rowGraph = new Dictionary<int, List<int>>();
        var colGraph = new Dictionary<int, List<int>>();
        var rowInDegree = new int[k + 1];
        var colInDegree = new int[k + 1];
        
        // Initialize the graphs and indegrees
        for (int i = 1; i <= k; i++) {
            rowGraph[i] = new List<int>();
            colGraph[i] = new List<int>();
        }
        
        // Build row graph
        foreach (var condition in rowConditions) {
            int above = condition[0];
            int below = condition[1];
            rowGraph[above].Add(below);
            rowInDegree[below]++;
        }
        
        // Build column graph
        foreach (var condition in colConditions) {
            int left = condition[0];
            int right = condition[1];
            colGraph[left].Add(right);
            colInDegree[right]++;
        }
        
        // Topological sort for rows
        var rowOrder = TopologicalSort(rowGraph, rowInDegree, k);
        if (rowOrder == null) return new int[0][];
        
        // Topological sort for columns
        var colOrder = TopologicalSort(colGraph, colInDegree, k);
        if (colOrder == null) return new int[0][];
        
        // Build the matrix
        var matrix = new int[k][];
        for (int i = 0; i < k; i++) {
            matrix[i] = new int[k];
        }
        
        var rowPositions = new int[k + 1];
        var colPositions = new int[k + 1];
        
        for (int i = 0; i < k; i++) {
            rowPositions[rowOrder[i]] = i;
            colPositions[colOrder[i]] = i;
        }
        
        for (int i = 1; i <= k; i++) {
            matrix[rowPositions[i]][colPositions[i]] = i;
        }
        
        return matrix;
    }
    
    private List<int> TopologicalSort(Dictionary<int, List<int>> graph, int[] inDegree, int k) {
        var queue = new Queue<int>();
        var order = new List<int>();
        
        for (int i = 1; i <= k; i++) {
            if (inDegree[i] == 0) {
                queue.Enqueue(i);
            }
        }
        
        while (queue.Count > 0) {
            var node = queue.Dequeue();
            order.Add(node);
            
            foreach (var neighbor in graph[node]) {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) {
                    queue.Enqueue(neighbor);
                }
            }
        }
        
        return order.Count == k ? order : null;
    }
}