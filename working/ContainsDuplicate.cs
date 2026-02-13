using System;
using System.Collections.Generic;
using System.Linq;

class ContainsDuplicate
{

    public bool CheckDuplicate(int[] nums)
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
        Console.WriteLine("Check Duplicate");
        Console.WriteLine($"  Date: {DateTime.Now:yyyy-MM-dd}");
        Console.WriteLine("========================================\n");

        bool check = CheckDuplicate(new int[] { 1, 2, 3, 1 });
            Console.WriteLine(check);
        Console.ReadLine();

    }
}
