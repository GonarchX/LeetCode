namespace LeetCode.Medium;

// 238. Product of Array Except Self
// https://leetcode.com/problems/product-of-array-except-self/
public class P238
{
    // Сначала собираем произведения чисел в массиве правее текущего числа, не включая его самого
    // Затем собираем произведения чисел в массиве левее текущего числа, не включая его самого
    // Пример:
    // Numbers:  2      3      4     5
    // Lefts:           2      2*3   2*3*4
    // Rights:   3*4*5  4*5    5     
    // Result:   3*4*5  2*4*5  2*3*5 2*3*4   
    public int[] ProductExceptSelf(int[] nums)
    {
        var res = new int[nums.Length];
        var left = 1;
        var right = 1;
        res[0] = 1;
        
        for (int i = 1; i < nums.Length; i++)
        {
            left *= nums[i - 1];
            res[i] = left;
        }

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            right *= nums[i + 1];
            res[i] *= right;
        }

        return res;
    }
}