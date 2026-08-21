public class MinStack {

    private readonly Stack<(int, int)> _stack = new();
    
    public void Push(int value)
    {
        if (_stack.Count != 0)
        {
            var current = _stack.Peek();
            if (value < current.Item2)
            {
                _stack.Push((value,value));
                return;
            }
            _stack.Push((value,current.Item2));
            return;
        }
        _stack.Push((value,value));
    }
    
    public void Pop()
    {
        _stack.Pop();
    }
    
    public int Top()
    {
        return _stack.Peek().Item1;
    }
    
    public int GetMin() {
        return _stack.Peek().Item2;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(value);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */