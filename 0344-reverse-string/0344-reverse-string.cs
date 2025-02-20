public class Solution {
    public void ReverseString(char[] s) {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            // Swap the characters at left and right indices
            char temp = s[left];
            s[left] = s[right];
            s[right] = temp;

            // Move the pointers towards the center
            left++;
            right--;
        }
    }
}