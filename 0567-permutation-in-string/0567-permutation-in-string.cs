public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length) return false;

        int[] s1_arr = new int[26];
        
        foreach(char a in s1)
        {
            s1_arr[a-'a']++;
        }

        int l = 0;
        int[] s2_arr = new int[26];
        
        for(int r=0; r<s2.Length; r++){
            s2_arr[s2[r]-'a']++;
            if (r-l+1 == s1.Length){
                if(s1_arr.SequenceEqual(s2_arr)){
                    return true;
                }
                s2_arr[s2[l]-'a']--;
                l += 1;
            }
        }
        return false;
    }
}