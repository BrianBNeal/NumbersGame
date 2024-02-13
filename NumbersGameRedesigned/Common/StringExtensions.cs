using System.Text.RegularExpressions;

namespace NumbersGameRedesigned.Common;
internal static class StringExtensions
{
    public static IEnumerable<IEnumerable<int>> PositiveIntegerSequences(this IEnumerable<string> lines) =>
        lines.Select(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
            .Select(stretches => stretches.Select(stretch =>
                (
                    correct: int.TryParse(stretch, out int value) && value > 0,
                    value
                )))
            .Where(matches => matches.AllNotEmpty(tuple => tuple.correct))
            .Select(matches => matches.Select(tuple => tuple.value));

    public static IEnumerable<int> SingleNonNegativeIntegers(this IEnumerable<string> lines) =>
        lines.Select(line =>
            (
                correct: int.TryParse(line, out int value) && value >= 0,
                value   
            ))
            .Where(tuple => tuple.correct)
            .Select(tuple => tuple.value);
}