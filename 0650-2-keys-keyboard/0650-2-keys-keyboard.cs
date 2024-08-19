public class Solution {
    public int MinSteps(int n) {
        if (n == 1)
        {
            return 0;
        }

        if (n == 2)
        {
            return 2;
        }

        if (n == 3)
        {
            return 3;
        }

        if (n % 2 == 0)
        {
            return 2 + MinSteps(n / 2);
        }

        int lowestDenominator = 3;
        while (n % lowestDenominator != 0)
        {
            lowestDenominator += 2;
        }

        if (n == lowestDenominator) {
            return n;
        }

        return lowestDenominator + MinSteps(n / lowestDenominator);
    }
}