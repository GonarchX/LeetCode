namespace LeetCode.Medium;

public class P155
{
    public class MinStack
    {
        private readonly LinkedList<(int current, int min)> _minStack;

        public MinStack()
        {
            _minStack = new();
        }

        public void Push(int val)
        {
            int minElemInStack = int.MaxValue;
            if (_minStack.Count > 0)
            {
                minElemInStack = _minStack.First.Value.min;
            }

            int minElem = Math.Min(val, minElemInStack);
            _minStack.AddFirst((val, minElem));
        }

        public void Pop()
        {
            _minStack.RemoveFirst();
        }

        public int Top()
        {
            return _minStack.First.Value.current;
        }

        public int GetMin()
        {
            return _minStack.First.Value.min;
        }
    }
}