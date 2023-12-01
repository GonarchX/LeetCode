namespace LeetCode.Easy;

public class P703
{
    public class KthLargest {
        private PriorityQueue<int, int> pq;
        private readonly int maxSize;
        public KthLargest(int k, int[] nums) {
            maxSize = k;
            pq = new(nums.Select(x => (x, x)));
            while (pq.Count > maxSize)
                pq.Dequeue();
        }
    
        public int Add(int val) {
            pq.Enqueue(val, val);
            if (pq.Count > maxSize)
                pq.Dequeue();
            return pq.Peek();
        }
    }
}