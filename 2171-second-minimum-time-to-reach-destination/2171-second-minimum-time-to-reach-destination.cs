public class Solution {
        public int SecondMinimum(int n, int[][] edges, int time, int change)
        {
            List<int>[] graph = new List<int>[n+1];
            for (int i = 0; i<graph.Length; i++)
            {
                graph[i] = new List<int>();
            }
            foreach (var e in edges)
            {
                graph[e[0]].Add(e[1]);//build the graph
                graph[e[1]].Add(e[0]);
            }
            int[][] memo = new int[n+1][];//build the memo
            for (int i = 0; i<memo.Length; i++)
            {
                memo[i] = new int[] { int.MaxValue, int.MaxValue };
            }
            //using queue to BFS, every element in q is [index,totalTime] pair
            var q = new Queue<int[]>();
            int[] seed = new int[] { 1, 0 };
            q.Enqueue(seed);
            while(q.Count > 0)
            {
                int size = q.Count;
                while (size-->0)
                {
                    var top = q.Dequeue();
                    //we can only leave vertex on green light
                    int offset = top[1]%(change*2);
                    if (offset<change)//green light
                    {
                        foreach (var i in graph[top[0]])
                        {
                            int arriveTime = top[1]+time;
                            if (arriveTime>memo[i][1])
                                continue;//slower than 2nd, discard
                            else if (arriveTime==memo[i][0]|| arriveTime==memo[i][1])
                                continue;//want unique result, discard duplicate
                            else
                            {
                                if (arriveTime<memo[i][0])//better than 1st
                                {
                                    memo[i][1] = memo[i][0];
                                    memo[i][0] = arriveTime;
                                }
                                else
                                {
                                    memo[i][1] = arriveTime;
                                }
                                int[] nextVisit = new int[] { i, arriveTime };
                                q.Enqueue(nextVisit);
                            }
                        }
                    }
                    else
                    {
                        //wait unitl next green light
                        top[1]+=2*change - offset;
                        q.Enqueue(top);
                    }
                }
            }
            return memo[n][1];
        }



}