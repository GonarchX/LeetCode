namespace LeetCode.Easy;

// 228. Summary Ranges
// https://leetcode.com/problems/summary-ranges/
public class SummaryRanges
{
    public class Solution
    {
        // Идем по каждому элементу массива, проверяя разница между текущим и предыдущим элементом
        // Если разница больше 1, значит предыдущий элемент является концом диапазона, который надо добавить в ответ
        // Иначе текущий элемент является продолжением последнего диапазона
        public IList<string> SummaryRanges(int[] nums)
        {
            List<string> ranges = new();

            if (nums.Length == 0) return ranges;

            int startRange = nums[0];
            int endRange = startRange;
            int cur = nums[0];
            int prev = cur;

            for (int i = 0; i < nums.Length; i++)
            {
                cur = nums[i];

                if ((long)cur - prev > 1) // Понимаем, что разрыв диапазона 
                {
                    // Формируем новый диапазон, а старый сохраняем в ranges
                    endRange = prev;

                    AddRange(startRange, endRange, ranges);

                    startRange = cur;
                    endRange = cur;
                }
                else
                {
                    endRange = cur;
                }

                prev = cur;
            }

            // Необходимо для того, чтобы добавить диапазон после окончания цикла
            AddRange(startRange, endRange, ranges);

            return ranges;
        }

        // Добавить текущий диапазон к ответу
        private static void AddRange(int startRange, int endRange, List<string> ranges)
        {
            // Диапазон больше 1 числа
            if (startRange != endRange)
                // ranges = ["0->2", "4->5"]
                ranges.Add($"{startRange}->{endRange}");
            else
                ranges.Add(startRange.ToString());
        }
    }
}