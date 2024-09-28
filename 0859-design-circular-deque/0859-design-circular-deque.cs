public class MyCircularDeque {
    private int[] deque;
    private int front;
    private int rear;
    private int size;
    private int capacity;
    public MyCircularDeque(int k) {
        capacity = k;
        deque = new int[k];
        front = 0;
        rear = 0;
        size = 0;
    }
    
    public bool InsertFront(int value) {
        if (IsFull()) {
            return false;
        }
        front = (front - 1 + capacity) % capacity;  // Move front backward in a circular manner
        deque[front] = value;
        size++;
        return true;
    }
    
    public bool InsertLast(int value) {
        if (IsFull()) {
            return false;
        }
        deque[rear] = value;
        rear = (rear + 1) % capacity;  // Move rear forward in a circular manner
        size++;
        return true;
    }
    
    public bool DeleteFront() {
        if (IsEmpty()) {
            return false;
        }
        front = (front + 1) % capacity;  // Move front forward in a circular manner
        size--;
        return true;
    }
    
    public bool DeleteLast() {
        if (IsEmpty()) {
            return false;
        }
        rear = (rear - 1 + capacity) % capacity;  // Move rear backward in a circular manner
        size--;
        return true;
    }
    
    public int GetFront() {
        if (IsEmpty()) {
            return -1;
        }
        return deque[front];
    }
    
    public int GetRear() {
        if (IsEmpty()) {
            return -1;
        }
        return deque[(rear - 1 + capacity) % capacity]; 
    }
    
    public bool IsEmpty() {
        return size == 0;
    }
    
    public bool IsFull() {
        return size == capacity;
    }
}
