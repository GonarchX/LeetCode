namespace LeetCode.Easy;

// 20. Valid Parentheses
// https://leetcode.com/problems/valid-parentheses/
public class P20
{
    public bool IsValid(string s)
    {
        var brackets = new Dictionary<char, char>
        {
            [')'] = '(',
            ['}'] = '{',
            [']'] = '['
        };
        var stack = new Stack<char>();
        
        // Берем и добавляем последовательно элементы нашей коллекции в стек,
        // если видим, что это элемент является открывающим.
        // Если видим, что элемент является закрывающим, тогда смотрим в наш стек
        // если последний элемент является соответствующим открывающимся элементом, тогда просто удаляем его,
        // иначе возвращаем false
        foreach (var bracket in s)
        {
            if (!brackets.ContainsKey(bracket))
                stack.Push(bracket);
            else
            {
                if (stack.Count <= 0 || stack.Pop() != brackets[bracket])
                    return false;
            }
        }

        if (stack.Count > 0)
            return false;
        
        return true;
    }
}