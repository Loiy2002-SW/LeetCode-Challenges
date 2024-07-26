public class Solution {
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        int INF = int.MaxValue / 2; // A large value to represent infinity

        // Initialize distance matrix
        int[,] dist = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dist[i, j] = (i == j) ? 0 : INF;
            }
        }

        // Populate the distance matrix with given edges
        foreach (var edge in edges)
        {
            int from = edge[0];
            int to = edge[1];
            int weight = edge[2];
            dist[from, to] = weight;
            dist[to, from] = weight;
        }

        // Apply Floyd-Warshall algorithm to find the shortest paths
        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }

        int minReachableCities = n; // A large number
        int resultCity = -1;

        // Count reachable cities within the distanceThreshold for each city
        for (int i = 0; i < n; i++)
        {
            int reachableCities = 0;
            for (int j = 0; j < n; j++)
            {
                if (i != j && dist[i, j] <= distanceThreshold)
                {
                    reachableCities++;
                }
            }

            // Check if the current city has fewer reachable cities or ties but has a greater index
            if (reachableCities <= minReachableCities)
            {
                if (reachableCities < minReachableCities || i > resultCity)
                {
                    minReachableCities = reachableCities;
                    resultCity = i;
                }
            }
        }

        return resultCity;
    }
}