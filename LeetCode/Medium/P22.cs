namespace LeetCode.Medium;

public class P22
{
    public IList<string> GenerateParenthesis(int n)
    {
        List<string> answer = new();
        Stack<(int left, int right, string res)> stack = new();
        stack.Push((0, 0, String.Empty));

        while (stack.Count > 0)
        {
            (int left, int right, string curStr) = stack.Pop();
            if (left == right && left == n)
            {
                answer.Add(curStr);
                continue;
            }

            if (left < n)
                stack.Push((left + 1, right, curStr + "("));
            if (right < n && right < left)
                stack.Push((left, right + 1, curStr + ")"));
        }

        return answer;
    }
}