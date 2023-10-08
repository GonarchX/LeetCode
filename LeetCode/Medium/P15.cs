namespace LeetCode.Medium;

// 15. 3Sum
// https://leetcode.com/problems/3sum/
public class P15
{
    // Сортируем массив и проходим по каждому уникальному элементу в нем так, чтобы все наши триплеты
    // были уникальными. После того как мы выбрали первый элемент,
    // при помощи двух указателей находим два числа в массиве, которые дадут нужную нам сумму
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var sNums = nums.OrderBy(x => x).ToList();
        List<IList<int>> res = new();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && sNums[i - 1] == sNums[i]) 
                continue;
            
            var first = sNums[i];
            var left = i + 1;
            var right = sNums.Count - 1;
            while (left < right)
            {
                if (sNums[right] + sNums[left] == first)
                    res.Add(new List<int> { first, sNums[left], sNums[right] });
                else if (sNums[right] + sNums[left] > first)
                    right--;
                else
                    left++;
            }
        }

        return res;
    }
}