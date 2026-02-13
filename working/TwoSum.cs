using System;
using System.Collections.Generic;
using System.Linq;

class TwoSum
{
    
    public static int[] TwoSum(int[] nums, int target) {
        Dictionary<int,int> set = new Dictionary<int,int>();
        for (int i = 0 ; i < nums.Length ;i++){
            int value = target - nums[i];

            if (!set.ContainsKey(value))
            {
                set.Add(nums[i],i);
            }
            else { 
            return new int[] {set[value],i};
            }
        }
        return new int[] {0,0};
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Two Sum");
        Console.WriteLine($"  Date: {DateTime.Now:yyyy-MM-dd}");
        Console.WriteLine("========================================\n");

        int[] nums1 = { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 };
        
        foreach(int a in TwoSum(nums1, 11)){
            Console.WriteLine(a);
        }
        Console.ReadLine();

    }
}
