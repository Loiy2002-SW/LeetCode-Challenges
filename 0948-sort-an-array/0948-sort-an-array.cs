public class Solution {
   public int[] SortArray(int[] nums)
    {
        if (nums == null || nums.Length <= 1)
            return nums;

        MergeSort(nums, 0, nums.Length - 1);
        return nums;
    }

    private void MergeSort(int[] nums, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSort(nums, left, mid);
            MergeSort(nums, mid + 1, right);
            Merge(nums, left, mid, right);
        }
    }

    private void Merge(int[] nums, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        for (int i = 0; i < n1; i++)
            leftArray[i] = nums[left + i];
        for (int i = 0; i < n2; i++)
            rightArray[i] = nums[mid + 1 + i];

        int iLeft = 0, iRight = 0, k = left;
        while (iLeft < n1 && iRight < n2)
        {
            if (leftArray[iLeft] <= rightArray[iRight])
            {
                nums[k] = leftArray[iLeft];
                iLeft++;
            }
            else
            {
                nums[k] = rightArray[iRight];
                iRight++;
            }
            k++;
        }

        while (iLeft < n1)
        {
            nums[k] = leftArray[iLeft];
            iLeft++;
            k++;
        }

        while (iRight < n2)
        {
            nums[k] = rightArray[iRight];
            iRight++;
            k++;
        
    }
}

}