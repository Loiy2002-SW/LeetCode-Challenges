public class Solution {
    public int NthUglyNumber(int n) {
        PriorityQueue<long, long> heap = new PriorityQueue<long, long>();
        HashSet<long> set = new HashSet<long>();
        heap.Enqueue(1,1);
        set.Add(1);
        int count = 0;
        while(heap.Count > 0){
            long val = heap.Peek();
            heap.Dequeue();
            set.Remove(val);
            count++;
            if(count == n){
                return (int)(val);
            }
            if(!set.Contains(val * 2)){
                heap.Enqueue(val * 2,val * 2);
                set.Add(val * 2);
            }
            if(!set.Contains(val * 3)){
                heap.Enqueue(val * 3,val * 3);
                set.Add(val * 3);
            }
            if(!set.Contains(val * 5)){
                heap.Enqueue(val * 5,val * 5);
                set.Add(val * 5);
            }
    
       }
        return -1;
    }
}