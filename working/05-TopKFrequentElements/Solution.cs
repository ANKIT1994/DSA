using System;
using System.Collections.Generic;
using System.Linq;

// Top K Frequent Elements (LC 347)
// https://leetcode.com/problems/
class TopKFrequentElements
{
    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Top K Frequent Elements (LC 347)");
        Console.WriteLine($"  Date: {DateTime.Now:yyyy-MM-dd}");
        Console.WriteLine("========================================\n");

        // Sample test cases
        int[] nums1 = { 1, 1, 1, 2, 2, 3 };
        int k1 = 2;
        Console.WriteLine("Test Case 1:");
        Console.WriteLine($"Input: nums = [{string.Join(", ", nums1)}], k = {k1}");
        Console.WriteLine($"Output: [{string.Join(", ", TopKFrequent(nums1, k1))}]\n");

        int[] nums2 = { 4, 4, 4, 4, 5, 5, 6 };
        int k2 = 1;
        Console.WriteLine("Test Case 2:");
        Console.WriteLine($"Input: nums = [{string.Join(", ", nums2)}], k = {k2}");
        Console.WriteLine($"Output: [{string.Join(", ", TopKFrequent(nums2, k2))}]\n");

        Console.ReadLine();
    }

    public static int[] TopKFrequent(int[] nums, int k)
    {
        List<int>[] bucket = new List<int>[nums.Length + 1];
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

        foreach (int n in nums)
        {
            if (frequencyMap.ContainsKey(n))
            {
                frequencyMap[n]++;
            }
            else
            {
                frequencyMap[n] = 1;
            }
        }

        foreach (var kvp in frequencyMap)
        {
            int key = kvp.Key;
            int frequency = kvp.Value;

            if (bucket[frequency] == null)
            {
                bucket[frequency] = new List<int>();
            }
            bucket[frequency].Add(key);
        }

        List<int> result = new List<int>();

        for (int i = bucket.Length - 1; i >= 0; i--)
        {
            if (bucket[i] != null)
            {
                foreach (int val in bucket[i])
                {
                    result.Add(val);

                    if (result.Count == k)
                    {
                        return result.ToArray();
                    }
                }
            }
        }

        return result.ToArray();
    }
}

