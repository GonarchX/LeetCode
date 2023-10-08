using System.Text;

namespace LeetCode.Medium;

// 443. String Compression
// https://leetcode.com/problems/string-compression/
public class P443
{
    public int Compress(char[] chars)
    {
        if (chars.Length == 1) return 1;

        StringBuilder sb = new();

        var curGroupLen = 0;
        var groupChar = chars[0];

        for (int i = 0; i < chars.Length; i++)
        {
            var curChar = chars[i];

            // Я иду по массиву
            // и если вижу, что текущий элемент не равен элементу группы, то я сохраняю предыдущую группу,
            // а также создаю новую группу
            if (curChar != groupChar)
            {
                sb.Append(groupChar);
                if (curGroupLen > 1)
                    sb.Append(curGroupLen);

                groupChar = curChar;
                curGroupLen = 1;
            }
            else curGroupLen++;

            // если я оказался в конце массива, то мне необходимо сохранить текущую группу 
            if (i == chars.Length - 1)
            {
                sb.Append(groupChar);
                if (curGroupLen > 1)
                    sb.Append(curGroupLen);
            }
        }

        var res = sb.ToString();

        for (int i = 0; i < res.Length; i++)
        {
            chars[i] = res[i];
        }

        return res.Length;
    }
}