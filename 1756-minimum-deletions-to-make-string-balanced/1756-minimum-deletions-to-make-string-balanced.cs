public class Solution {
    public int MinimumDeletions(string s) {
       int countB = 0; // Number of 'b's seen so far
        int deletions = 0; // Minimum deletions needed to balance the string

        foreach (char c in s) {
            if (c == 'b') {
                countB++;
            } else { // c == 'a'
                deletions = Math.Min(deletions + 1, countB);
            }
        }

        return deletions; 
    }
}