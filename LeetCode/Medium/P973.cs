namespace LeetCode.Medium;

public class P973
{
    public int[][] KClosest(int[][] points, int k)
    {
        PriorityQueue<int[], double> pq = new(points.Select(x => (
            new[] { x[0], x[1] }, // Point coords
            Math.Sqrt(Math.Pow(x[0], 2) + Math.Pow(x[1], 2)))) // Distance to center
        );
        
        int[][] res = new int[k][];

        for (int i = 0; i < k; i++)
        {
            res[i] = pq.Dequeue();
        }

        return res;
    }
}