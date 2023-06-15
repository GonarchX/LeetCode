namespace LeetCode.Medium;

// 49. Group Anagrams
// https://leetcode.com/problems/group-anagrams/
public class GroupAnagrams
{
    public class Solution
    {
        // Основная идея заключается в том, что для проверки является ли одна строка анаграммой другой,
        // необходимо лишь отсортировать обе эти строки и проверить их на эквивалентность
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            // Заводим массив, в котором
            // ключом является отсортированная строка, которую можно использовать для составления анаграмм 
            // значением являются все строки исходной последовательности, которые являются анаграммами ключа
            Dictionary<string, List<string>> grouppedAnagrams = new();

            // Проходим по каждому элементу входной последовательности
            foreach (var str in strs)
            {
                // Сортируем текущую строку, чтобы посмотреть является ли она чей-то анаграммой
                var copyStr = str.ToArray();
                Array.Sort(copyStr);
                var sortedStr = new string(copyStr);

                // Если мы находим отсортированную строку в нашем словаре, то делаем вывод, что наша строка,
                // является анаграммой к ключу 
                if (grouppedAnagrams.ContainsKey(sortedStr))
                    grouppedAnagrams[sortedStr].Add(str);
                // Иначе создаем новую запись в словаре вида
                else
                    grouppedAnagrams.Add(sortedStr, new List<string>() { str });
            }

            List<IList<string>> res = new(grouppedAnagrams.Count);
        
            res.AddRange(grouppedAnagrams.Select(groupedAnagrams => groupedAnagrams.Value));

            return res;
        }
    }
}