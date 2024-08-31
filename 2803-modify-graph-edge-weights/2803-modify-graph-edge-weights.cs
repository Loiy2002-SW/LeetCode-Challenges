public class Solution {
    public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target) {
        int[] vis = new int[n];
        Dictionary<int,int> map = new Dictionary<int,int>();
        List<(int,int,int)>[] adj = new List<(int,int,int)>[n];
        for(int i=0;i<n;i++) adj[i] = new List<(int,int,int)>();
        for(int i=0;i<edges.Length;i++)
        {
            adj[edges[i][0]].Add((edges[i][1],edges[i][2],i));
            adj[edges[i][1]].Add((edges[i][0],edges[i][2],i));
        }
        PriorityQueue<(int,int,int,string),int> pq = new PriorityQueue<(int,int,int,string),int>();
        pq.Enqueue((source,0,0,""),0);
        while(pq.Count>0)
        {
            var (node, weight, min, id) = pq.Dequeue();
            if(weight>target||(vis[node]!=0&&weight>=vis[node])) continue;
            vis[node] = weight==0?-1:weight;
            if(node==destination)
            {
                if(id==""&&weight!=target) break;
                else if(id=="")
                {
                    for(int i=0;i<edges.Length;i++)
                        if(edges[i][2]==-1)
                            edges[i][2] = 1000000005;
                    return edges;
                }
                HashSet<int> allid = new HashSet<int>(id.Split(',',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
                weight -= min;
                int c = 1;
                foreach(var i in allid)
                {
                    edges[i][2] = c==allid.Count?target-weight:1;
                    c++;
                    weight++;
                }
                for(int i=0;i<edges.Length;i++)
                    if(edges[i][2]==-1)
                        edges[i][2] = 1000000005;
                return edges;
            }
            foreach(var (dest,w,i) in adj[node])
            {
                if(w==-1) pq.Enqueue((dest,weight+1,min+1,id+i+","),int.MaxValue);
                else pq.Enqueue((dest,weight+w,min,id),weight+w);
            }
        } 
        return new int[0][];
    }
}