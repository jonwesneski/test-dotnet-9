using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1.DSA;

public static class PrefixSum
{
    public static int RangeIncrement(int n, Tuple<int, int, int>[] t)
    {
        var result = 0;
        var myArray = new int[n];
        for (var i = 0; i < t.Length; i++)
        {
            for (var j = t[i].Item1; j < t[i].Item2; j++)
            {
                myArray[j] += t[i].Item3;
                result = Math.Max(result, myArray[j]);
            }
        }
        return result;
    }

    public static int Equilibrium(int[] arr)
    {
        var prefixSums = new int[arr.Length];
        var suffixSums = new int[arr.Length];

        prefixSums[0] = arr[0];
        suffixSums[arr.Length - 1] = arr[arr.Length - 1];

        for (var i = 1; i < arr.Length; i++)
        {
            prefixSums[i] = prefixSums[i - 1] + arr[i];
        }

        for (var i = arr.Length - 2; i >= 0; i--)
        {
            suffixSums[i] = suffixSums[i + 1] + arr[i];
        }

        for (var i = 0; i < arr.Length; i++)
        {
            if (prefixSums[i] == suffixSums[i])
            {
                return i;
            }
        }

        return -1;
    }

    public static int[][] LeftRight(List<int> arr)
    {
        var leftSum = arr.Sum();

        var rightSum = 0;
        for (var i = arr.Count - 1; i >= 0; i--)
        {
            rightSum += arr[i];
            leftSum -= arr[i];
            if (leftSum == rightSum)
            {
                return [[.. arr.Take(i)],
                    [.. arr.Skip(i).Take(arr.Count - i)]];
            }
        }
        return [];
    }

    public static List<decimal> MeanRange(List<int> arr, Tuple<int, int>[] queries)
    {
        var prefixSums = new int[arr.Count + 1];
        prefixSums[1] = arr[0];
        for (var i = 1; i < arr.Count; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + arr[i];
        }

        var results = new List<decimal>();
        foreach (var q in queries)
        {
            decimal rangeCount = q.Item2 - (q.Item1 - 1);
            decimal rangeSum = prefixSums[q.Item2] - prefixSums[q.Item1 - 1];
            results.Add(Math.Floor(rangeSum / rangeCount));
        }

        return results;
    }

    public static List<int> ProductExceptSelf(int[] numbers)
    {
        var results = Enumerable.Repeat(0, numbers.Length).ToList();
        results[0] = 1;
        for (var i = 1; i < numbers.Length; i++)
        {
            results[i] = results[i - 1] * numbers[i - 1];
        }

        var right = 1;
        for (var i = numbers.Length - 1; i >= 0; i--)
        {
            results[i] *= right;
            right *= numbers[i];
        }

        return results;
    }
}
