using NumbersGameRedesigned.Common;
using System.Text.RegularExpressions;

internal class ConsoleProblemsReader
{
    public IEnumerable<ProblemStatement> ReadAll() =>
        RawNumbersSequence.Select(inputs => new ProblemStatement(inputs));

    private IEnumerable<IEnumerable<int>> RawNumbersSequence =>
        Console.In.IncomingLines().Select(line => line.ToNonNegativeInts());
}