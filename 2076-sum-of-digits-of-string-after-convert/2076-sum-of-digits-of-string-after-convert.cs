public class Solution {
    int getsum(int num)
    {
        int sum = 0;
        while(num != 0)
        {
            sum = (sum + (num%10));
            num = num/10;
        }
        return sum;
    }
    int get_int(char a)
    {
        return (int)a - (int)'a' + 1;
    }
    
    public int GetLucky(string s, int k) {
        int num = 0;

        for(int i = 0;i<s.Length;i++)
        {
            int asci = get_int(s[i]);
            num = num + getsum(asci);
        }
        k--;
        while((k>0) && (num >= 10))
        {
            num = getsum(num);
            k--;
        }
        return num;
    }
}