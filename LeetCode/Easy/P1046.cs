namespace LeetCode.Easy;

public class P1046
{
    public int LastStoneWeight(int[] stones) {
        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(stones.Select(x => (x, -x)));

        while (priorityQueue.Count > 1)
        {
            int diff = priorityQueue.Dequeue() - priorityQueue.Dequeue();
            if (diff > 0)
                priorityQueue.Enqueue(diff, -diff);
        }

        return priorityQueue.Count == 0 ? 0 : priorityQueue.Dequeue();
    }
}