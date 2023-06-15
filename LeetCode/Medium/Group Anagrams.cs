namespace LeetCode.Medium;

// 49. Group Anagrams
// https://leetcode.com/problems/group-anagrams/
public class GroupAnagrams
{
    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> grouppedAnagrams = new();

            foreach (var str in strs)
            {
                var copyStr = str.ToArray();
                Array.Sort(copyStr);
                var sortedStr = new string(copyStr);

                if (grouppedAnagrams.ContainsKey(sortedStr))
                    grouppedAnagrams[sortedStr].Add(str);
                else
                    grouppedAnagrams.Add(sortedStr, new List<string>() { str });
            }


            List<IList<string>> res = new(grouppedAnagrams.Count);
        
            res.AddRange(grouppedAnagrams.Select(grouppedAnagram => grouppedAnagram.Value));

            return res;
        }
    }
}