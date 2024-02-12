using NumbersGameRedesigned.Common;
using System.Text.RegularExpressions;

internal class ConsoleProblemsReader
{
    public IEnumerable<ProblemStatement> ReadAll() =>
        RawNumbersSequence.Select(tuple => new ProblemStatement(tuple.inputs, tuple.result));

    private IEnumerable<(IEnumerable<int> inputs, int result)> RawNumbersSequence =>
        InputNumberSequences
            .Zip(DesiredResults, (inputs, result) => (inputs, result));

    private IEnumerable<IEnumerable<int>> InputNumberSequences =>
        Console.In.IncomingLines(PromptInputNumbers).NonNegativeIntegerSequences();

    private IEnumerable<int> DesiredResults =>
        Console.In.IncomingLines(PromptDesiredResult).SingleNonNegativeIntegers();

    private void PromptInputNumbers() =>
        Console.Write("Input numbers: ");

    private void PromptDesiredResult() =>
        Console.Write("Desired result: ");
}