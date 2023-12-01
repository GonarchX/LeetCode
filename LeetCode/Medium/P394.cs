using System.Text;

namespace LeetCode.Medium;

public class P394
{
    public string DecodeString(string s) {
        Stack<string> wordStack = new();
        Stack<int> numStack = new();
        StringBuilder curWord = new();
        int curNum = 0;

        for (int i = 0; i < s.Length;i++)
        {
            if (Char.IsDigit(s[i]))
            {
                curNum = curNum * 10 + (s[i] - '0');
            }
            else if (Char.IsLetter(s[i]))
            {
                curWord.Append(s[i]);
            }
            else if (s[i] == '[')
            {
                wordStack.Push(curWord.ToString());
                numStack.Push(curNum);
                curWord = new StringBuilder();
                curNum = 0;
            }
            else if (s[i] == ']')
            {
                var prevWord = curWord;
                curWord = new StringBuilder(wordStack.Pop());
                var iterations = numStack.Pop();
                for (int j = 0; j < iterations; j++)
                {
                    curWord.Append(prevWord);
                }
            }
        }

        return curWord.ToString();
    }
}