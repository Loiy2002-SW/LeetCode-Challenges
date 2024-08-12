public class KthLargest {

    private int k;
    private PriorityQueue<int, int> minHeap = new();

    public KthLargest(int k, int[] nums) {
        this.k = k;
        foreach(int num in nums)
        {
            Add(num);
        }
    }
    
    public int Add(int val) 
    {
        minHeap.Enqueue(val, val);
        if(minHeap.Count > k) minHeap.Dequeue();
        return minHeap.Peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */