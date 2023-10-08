namespace LeetCode.Medium;

// 1493. Longest Subarray of 1's After Deleting One Element
// https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/
public class P1493
{
    public class Solution {
        // Алгоритм следующий:
        // У нас есть плавающий диапазон в массиве, в котором мы храним интервал значений "0" и "1"
        // с условием, что "0" у нас не более n
        // На каждом цикле прохода по исходному массиву мы добавляем текущий элемент в наш диапазон
        // Если текущий элемент является "0" и общее кол-во "0" превысило n,
        // тогда мы двигаем левую границу нашего диапазона до тех пор, пока кол-во "0" не станет равно n
        
        // В процессе прохода по массиву сохраняем максимальную полученную длину нашего диапазона,
        // чтобы вернуть ее в качестве ответа
        public int LongestSubarray(int[] nums) {
            var start = 0;
            var maxLen = 0;
            var zeroCount = 0;
        
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) zeroCount++;
            
                while (zeroCount > 1)
                {
                    if (nums[start] == 0)
                        zeroCount--;
                
                    start++;
                }
                        
                maxLen = Math.Max(maxLen, i - start);
            }
        
            return maxLen;
        }
    }
}