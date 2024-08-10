public class Solution {
    public int RegionsBySlashes(string[] grid) {
        int n = grid.Length;
        int size = 4 * n * n;
        UnionFind uf = new UnionFind(size);

        for (int r = 0; r < n; ++r) {
            for (int c = 0; c < n; ++c) {
                int index = 4 * (r * n + c);
                char val = grid[r][c];

                // Connect internal triangles
                if (val == '/') {
                    uf.Union(index + 0, index + 3);
                    uf.Union(index + 1, index + 2);
                } else if (val == '\\') {
                    uf.Union(index + 0, index + 1);
                    uf.Union(index + 2, index + 3);
                } else {
                    uf.Union(index + 0, index + 1);
                    uf.Union(index + 1, index + 2);
                    uf.Union(index + 2, index + 3);
                }

                // Connect external triangles
                if (r + 1 < n) {
                    uf.Union(index + 2, index + 4 * n + 0);
                }
                if (c + 1 < n) {
                    uf.Union(index + 1, index + 4 + 3);
                }
            }
        }

        int regions = 0;
        for (int i = 0; i < size; ++i) {
            if (uf.Find(i) == i) {
                regions++;
            }
        }
        return regions;
    }
}

public class UnionFind {
    private int[] parent;
    private int[] rank;
    
    public UnionFind(int size) {
        parent = new int[size];
        rank = new int[size];
        for (int i = 0; i < size; ++i) {
            parent[i] = i;
            rank[i] = 1;
        }
    }
    
    public int Find(int x) {
        if (parent[x] != x) {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }
    
    public void Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY) {
            if (rank[rootX] > rank[rootY]) {
                parent[rootY] = rootX;
            } else if (rank[rootX] < rank[rootY]) {
                parent[rootX] = rootY;
            } else {
                parent[rootY] = rootX;
                rank[rootX]++;
            }
        }
    }
}