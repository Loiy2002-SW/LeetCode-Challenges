public class Solution {
    public int StoneGameII(int[] piles) {
        int n = piles.Length;
        var sums = new int[n];
        sums[n-1] = piles[n-1];
        for(int i = n -2; i>=0;i--) sums[i] = sums[i+1] + piles[i];
        var arr= new int[n,n];
        return dfs(0,1);

        int dfs(int s, int m){
            if(s == n) return 0; 
            if(2*m >= n - s) return sums[s];
            if(arr[s,m] != 0) return arr[s,m];
            var min=Int32.MaxValue;
            for(var i=1;i<=2*m;i++) min=Math.Min(min,dfs(s+i,Math.Max(m,i)));
            return arr[s,m]=sums[s]-min;
        }
    }
}