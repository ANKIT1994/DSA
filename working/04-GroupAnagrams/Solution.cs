using System;
using System.Collections.Generic;
using System.Linq;

// Group Anagrams (LC 49)
// https://leetcode.com/problems/
public IList<IList<string>> GroupAnagrams(string[] strs)
{
    Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

    foreach (string word in strs)
    {
        char[] arr = word.ToCharArray();
        Array.Sort(arr);
        string key = new string(arr);

        if (!map.ContainsKey(key))
        {
            map[key] = new List<string>();
        }

        map[key].Add(word);
    }

    return map.Values.Cast<IList<string>>().ToList();
}

class GroupAnagrams
{
    // TODO: Implement solution here

    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Group Anagrams (LC 49)");
        Console.WriteLine($"  Date: {DateTime.Now:yyyy-MM-dd}");
        Console.WriteLine("========================================\n");

        // TODO: Add test cases here

        Console.ReadLine();
    }
}
