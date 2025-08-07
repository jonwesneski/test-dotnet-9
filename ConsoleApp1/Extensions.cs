using System;

namespace ConsoleApp1;

public static class Extensions
{
    public static string Readable<T>(this List<List<T>> listOfLists)
    {
        IEnumerable<string> joinedInnerLists = listOfLists.Select(innerList => string.Join(", ", innerList));
        return string.Join(" | ", joinedInnerLists);
    }

    public static string Readable<T>(this T[][] listOfLists)
    {
        IEnumerable<string> joinedInnerLists = listOfLists.Select(innerList => string.Join(", ", innerList));
        return string.Join(" | ", joinedInnerLists);
    }

    public static string Readable<T>(this T[] something)
    {
        return string.Join(", ", something);
    }

    public static string Readable<T>(this List<T> something)
    {
        return string.Join(", ", something);
    }
}
