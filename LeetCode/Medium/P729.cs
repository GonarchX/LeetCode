using System.Collections;

namespace LeetCode.Medium;

public class P729
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] answer = new int[temperatures.Length];
        Stack<(int index, int value )> stack = new();

        for (int i = 0; i < temperatures.Length; i++)
        {
            var curElem = temperatures[i];

            while (stack.Count > 0 && stack.Peek().value < curElem)
            {
                var lastStackValue = stack.Peek();
                answer[lastStackValue.index] = lastStackValue.index - i;
                stack.Pop();
            }

            stack.Push((i, curElem));
        }

        return answer;
    }
}