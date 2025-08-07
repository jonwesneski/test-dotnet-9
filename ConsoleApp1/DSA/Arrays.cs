using System;
using System.Globalization;

namespace ConsoleApp1.DSA;

public static class Arrays
{
    public static int? MajorityElement(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            return null;
        }

        var candidate = numbers[0];
        var count = 0;
        foreach (var item in numbers)
        {
            if (count == 0)
            {
                candidate = item;
            }
            count += candidate > 0 ? 1 : -1;
        }
        return candidate;
    }

    public static int? FirstMissingPositiveNumber(List<int> numbers)
    {
        numbers.Sort();
        var current = 1;
        for (var i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] <= 0 || (i > 0 && numbers[i - 1] == numbers[i]))
            {
                continue;
            }
            if (numbers[i] != current)
            {
                break;
            }
            current++;
        }
        return current;
    }

    public static List<List<string>> GroupAnagrams(string[] words)
    {
        var map = new Dictionary<string, List<string>>();
        var start = (int)'a';
        foreach (string word in words)
        {
            var alphabetCount = new int[26];
            foreach (char c in word)
            {
                var index = (int)c - start;
                alphabetCount[index]++;
            }
            var key = string.Join("", alphabetCount);
            if (map.TryGetValue(key, out List<string>? value))
            {
                value.Add(word);
            }
            else
            {
                map.Add(key, [word]);
            }
        }
        return [.. map.Values];
    }

    public static int[] FrequentK(int[] numbers, int k)
    {
        var map = new Dictionary<int, int>();
        foreach (var number in numbers)
        {
            if (map.TryGetValue(number, out int value))
            {
                value += 1;
                map[number] = value;
            }
            else
            {
                map.Add(number, 1);
            }
        }
        return [.. map.Where(kv => kv.Value >= k).ToDictionary().Keys];
    }

    public static int LongestSequence(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            return 0;
        }

        var mySet = new HashSet<int>(numbers);
        var longest = 1;
        foreach (var num in mySet)
        {
            var currentNum = num - 1;
            if (mySet.Contains(currentNum))
            {
                var count = 2;
                while (mySet.Contains(--currentNum))
                {
                    count++;
                }
                longest = Math.Max(longest, count);
            }
        }
        return longest;
    }
}
