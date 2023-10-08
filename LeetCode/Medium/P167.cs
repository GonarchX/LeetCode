namespace LeetCode.Medium;

// 167. Two Sum II - Input Array Is Sorted
// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
public class P167
{
    // Тут просто заводим левый и правый указатели: на первый и последний элемент
    // Если сумма элементов равна target - возвращаем их
    // Если сумма элементов больше traget - двигаем правый указатель влево, иначе левый вправо
    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0;
        int right = numbers.Length;

        while (left < right)
        {
            if (numbers[right] - numbers[left] == target)
                return new int[] { left, right };
            else if (numbers[right] - numbers[left] > target)
                left++;
            else if (numbers[right] - numbers[left] < target)
                right--;
        }

        return new[] { left, right };
    }
}