namespace LeetCode.Medium;

public class P56
{
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length <= 1)
            return intervals;

        List<int[]> sortedIntervals = new List<int[]>(intervals);
        sortedIntervals.Sort((a, b) => a[0] - b[0]);

        List<int[]> res = new ();
        /*
         * Идем по каждому интервалу из sortedIntervals
         * Сравнивая последний интервал из res и следующий интервал
         * Если конец последнего интервала из res >= начала следующего интервала,
         * то правую границу последнего интервала из res расширяем до максимальной правой границы между этими двумя интервалами
         * Иначе мы понимаем, что следующий интервал никак не пересекается с последним интервалом из res и его нужно добавить как отдельный интервал
         */ 
        
        res.Add(sortedIntervals[0]);
        
        for (var i = 1; i < sortedIntervals.Count; i++)
        {
            if (res[^1][1] >= sortedIntervals[i][0])
                res[^1][1] = Math.Max(res[^1][1], sortedIntervals[i][1]);
            else 
                res.Add(sortedIntervals[i]);
        }
        
        return res.ToArray();
    }
}