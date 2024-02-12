using NumbersGameRedesigned.Common;
using System.Text.RegularExpressions;

internal class ConsoleProblemsReader
{
    public IEnumerable<ProblemStatement> ReadAll() =>
        RawNumbersSequence.Select(inputs => new ProblemStatement(inputs));

    private IEnumerable<IEnumerable<int>> RawNumbersSequence =>
        Console.In.IncomingLines(PromptInputNumbers).NonNegativeIntegerSequences();

    private void PromptInputNumbers() =>
        Console.Write(" Input numbers: ");
}