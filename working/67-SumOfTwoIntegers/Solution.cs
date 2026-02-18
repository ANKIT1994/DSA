using System;
using System.Collections.Generic;
using System.Linq;

// Sum of Two Integers (LC 371)
// https://leetcode.com/problems/
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

class SumOfTwoIntegers
{
    // TODO: Implement solution here

    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Sum of Two Integers (LC 371)");
        Console.WriteLine($"  Date: {DateTime.Now:yyyy-MM-dd}");
        Console.WriteLine("========================================\n");

          


        Console.ReadLine();
    }
}
