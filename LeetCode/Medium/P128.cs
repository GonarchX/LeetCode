namespace LeetCode.Medium;

// 128. Longest Consecutive Sequence
// https://leetcode.com/problems/longest-consecutive-sequence/
public class P128
{
    // Просто заводим сет с нашими числами и ищем в нем начала последовательностей, для этого такое число 
    // не должно иметь в сете числа меньше него на 1.
    // После того как нашли начало последовательности начинаем искать каждый число на 1 больше
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> hs = new HashSet<int>(nums);
        var maxSeq = 0;
        foreach (var num in nums)
        {
            if (!hs.Contains(num - 1))
            {
                var curNum = num + 1;
                while (hs.Contains(curNum))
                {
                    curNum++;
                }

                maxSeq = Math.Max(maxSeq, curNum - num);
            }
        }

        return maxSeq;
    }
}