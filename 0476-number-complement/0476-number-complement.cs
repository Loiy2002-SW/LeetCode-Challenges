public class Solution 
{
    public int FindComplement(int num) 
    {
        int mask = (int)BitOperations.RoundUpToPowerOf2((uint)num) - 1;
        return (~num) & mask;
    }
}