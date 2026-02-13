using System;
using System.Collections.Generic;
using System.Linq;

// Contains Duplicate (LC 217)
// https://leetcode.com/problems/contains-duplicate/

class ContainsDuplicate
{

    public static bool CheckDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!set.Contains(nums[i]))
            {
                set.Add(nums[i]);
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Contains Duplicate (LC 217)");
        Console.WriteLine($"  Date: {DateTime.Now:yyyy-MM-dd}");
        Console.WriteLine("========================================\n");

        bool check = CheckDuplicate(new int[] { 1, 2, 3, 1 });
            Console.WriteLine(check);
        Console.ReadLine();

    }
}
