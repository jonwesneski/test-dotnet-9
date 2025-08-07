using System;

namespace ConsoleApp1.DSA;

public static class TwoPointer
{
    public static int[] TwoSum(List<int> numbers, int target)
    {
        //numbers.Sort();
        var leftPointer = 0;
        var rightPointer = numbers.Count - 1;
        while (leftPointer < rightPointer)
        {
            var total = numbers[leftPointer] + numbers[rightPointer];
            if (total == target)
            {
                return [leftPointer + 1, rightPointer + 1];
            }
            if (total < target)
            {
                leftPointer++;
            }
            else
            {
                rightPointer--;
            }
        }

        return [];
    }

    public static int MaxArea(int[] heights)
    {
        var leftPointer = 0;
        var rightPointer = heights.Length - 1;
        var answer = 0;

        while (leftPointer < rightPointer)
        {
            var currentArea = Math.Min(heights[leftPointer], heights[rightPointer]) * (rightPointer - leftPointer);
            if (heights[leftPointer] < heights[rightPointer])
            {
                leftPointer++;
            }
            else
            {
                rightPointer--;
            }
            answer = Math.Max(answer, currentArea);
        }
        return answer;
    }
}
