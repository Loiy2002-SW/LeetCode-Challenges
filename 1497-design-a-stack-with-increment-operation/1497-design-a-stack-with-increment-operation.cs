public class CustomStack {
    private int[] stack;   
    private int[] increments; 
    private int top;      
    private int maxSize;
    public CustomStack(int maxSize) {
        this.maxSize = maxSize;
        this.stack = new int[maxSize];        
        this.increments = new int[maxSize];   
        this.top = -1; 
    }
    
    public void Push(int x) {
        if (top < maxSize - 1) {
            stack[++top] = x;
        }
    }
    
    public int Pop() {
        if (top == -1) {
            return -1;
        }
        int popValue = stack[top] + increments[top];  
        if (top > 0) {
            increments[top - 1] += increments[top];
        }
        increments[top] = 0;
        top--;                
        return popValue;   
    }
    
    public void Increment(int k, int val) {
        int limit = Math.Min(k - 1, top);
        if (limit >= 0) {
            increments[limit] += val;
        }
    }
}
