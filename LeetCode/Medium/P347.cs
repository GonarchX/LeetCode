namespace LeetCode.Medium;

// 347. Top K Frequent Elements
// https://leetcode.com/problems/top-k-frequent-elements/
public class P347
{
    public class Solution
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> dict = new();

            // Проходим по исходной последовательности, формируя словарь вида
            // { число: количество в исходной последовательности} 
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }
            
            return dict
                .OrderByDescending(x => x.Value) // Сортируем полученный словарь по количеству чисел в исходной последовательности
                .Take(k) // Берем k чисел
                .Select(x => x.Key) // Т.к. мы работаем с KeyValuePairs, нам необходимо взять только ключ без значения 
                .ToArray(); // Конвертируемый в необходимый тип
        }
    }
}