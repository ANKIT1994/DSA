using System;
using System.Collections.Generic;
using System.Linq;

// Valid Anagram (LC 242)
// https://leetcode.com/problems/valid-anagram/

class ValidAnagram
{

    public bool IsAnagram(string s, string t)
    {
        Dictionary<char, int> lookupS = new Dictionary<char, int>();
        bool ans = true;
        if ((s.Length > t.Length) || (s.Length < t.Length))
        {
            return false;
        }
        foreach (char c in s)
        {
            if (!lookupS.ContainsKey(c))
            {
                lookupS[c] = 1;
            }
            else
            {
                lookupS[c]++;
            }
        }
        foreach (char c in t)
        {
            if (lookupS.ContainsKey(c))
            {
                lookupS[c]--;
            }

        }
        foreach (var ch in lookupS)
        {
            if (ch.Value != 0)
            {
                ans = false;
            }

        }
        return ans;
       
    }

    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Valid Anagram (LC 242)");
        Console.WriteLine($"  Date: {DateTime.Now:yyyy-MM-dd}");
        Console.WriteLine("========================================\n");

        // TODO: Add test cases here

        Console.ReadLine();
    }
}
