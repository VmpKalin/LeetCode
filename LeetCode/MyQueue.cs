namespace LeetCode;

public class MyQueue {
    
    // Queue implementation by two stacks.
    // Queue - FIFO approach [5,4,3,2,1] - 1 first out
    // Stack - LIFO approach [1,2,3,4,5, we should add new items here] - 1 first out, but should most right - 5
    // Push add to the top - fine to add it
    // Pop remove from the top
    // What should I do on add and remove? Why do we need two stack values? Links?
    // What if in one stack we put simple order, and in second reversed?
    /*
       Explanation
       MyQueue myQueue = new MyQueue();
       myQueue.push(1); // queue is: [1]
       myQueue.push(2); // queue is: [1, 2] (leftmost is front of the queue)
       myQueue.peek(); // return 1
       myQueue.pop(); // return 1, queue is [2]
       myQueue.empty(); // return false
    */
    
    private readonly Stack<int> _stackInput = new(); // [5,4,3,2,1] - Count
    private readonly Stack<int> _stackReversedOutput = new(); // [1,2,3,4,5]
    public MyQueue() {
        
    }
    
    public void Push(int x) 
    {
        _stackInput.Push(x);
    }
    
    public int Pop() {
        if (_stackReversedOutput.Count == 0 && _stackInput.Count == 1)
        {
            return _stackInput.Pop();
        }

        MoveToOutputStack();

        return _stackReversedOutput.Pop();
    }

    private void MoveToOutputStack()
    {
        if (_stackReversedOutput.Count > 0) return;
        while (_stackInput.Count > 0)
        {
            _stackReversedOutput.Push(_stackInput.Pop());
        }
        // В чому різниця?
        // for (int i = 0; i < _stackInput.Count; i++)
        // {
        //     _stackReversedOutput.Push(_stackInput.Pop());
        //     i++;
        // }
    }

    public int Peek()
    {
        MoveToOutputStack();
        
        return _stackReversedOutput.Peek();
    }
    
    public bool Empty()
    {
        return _stackInput.Count + _stackReversedOutput.Count == 0; 
    }
}


 