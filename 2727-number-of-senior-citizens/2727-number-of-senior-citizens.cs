public class Solution {
    public int CountSeniors(string[] details) {
         int count = 0;

        foreach (var detail in details)
        {
            // Extract the age part (characters at index 11 and 12)
            int age = int.Parse(detail.Substring(11, 2));

            // Check if the age is greater than 60
            if (age > 60)
            {
                count++;
            }
        }

        return count;

    }
}