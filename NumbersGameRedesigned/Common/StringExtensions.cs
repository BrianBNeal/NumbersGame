using System.Text.RegularExpressions;

namespace NumbersGameRedesigned.Common;
internal static class StringExtensions
{
    public static IEnumerable<int> ToNonNegativeInts(this string s) =>
        Regex.Matches(s, @"\d+")
            .Select(match => match.Value)
            .Select(int.Parse);
}
