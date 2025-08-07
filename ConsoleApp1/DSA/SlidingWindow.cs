using System;

namespace ConsoleApp1.DSA;

//Use this pattern when dealing with problems involving contiguous subarrays or substrings.
public static class SlidingWindow
{
    public static decimal FindMaxAverage(int[] numbers, int k)
    {
        var leftPointer = 0;
        var rightPointer = leftPointer + (k - 1);
        var result = 0;
        while (rightPointer < numbers.Length)
        {
            var sum = 0;
            for (var i = leftPointer; i <= rightPointer; i++)
            {
                sum += numbers[i];
            }

            result = Math.Max(result, sum);
            leftPointer++;
            rightPointer++;
        }

        return result / (decimal)k;
    }
}
