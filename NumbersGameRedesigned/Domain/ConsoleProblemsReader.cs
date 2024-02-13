using NumbersGameRedesigned.Common;

namespace NumbersGameRedesigned.Domain;

internal class ConsoleInputsReader
{
    private string _promptLabel;
    public ConsoleInputsReader(string promptLabel = "Input numbers: ")
    {
        _promptLabel = promptLabel;
    }

    public IEnumerable<IEnumerable<int>> ReadAll() =>
        Console.In.IncomingLines(Prompt).PositiveIntegerSequences();

    private void Prompt() =>
        Console.Write(_promptLabel);
}

internal class ConsoleProblemsReader
{
    private ConsoleInputsReader InputsReader { get; } = new ConsoleInputsReader(" Input numbers: ");
    public IEnumerable<ProblemStatement> ReadAll() =>
        RawNumbersSequence.Select(tuple => new ProblemStatement(tuple.inputs, tuple.result));

    private IEnumerable<(IEnumerable<int> inputs, int result)> RawNumbersSequence =>
        InputNumberSequences
            .Zip(DesiredResults, (inputs, result) => (inputs, result));

    private IEnumerable<IEnumerable<int>> InputNumberSequences =>
        InputsReader.ReadAll();

    private IEnumerable<int> DesiredResults =>
        Console.In.IncomingLines(PromptDesiredResult).SingleNonNegativeIntegers();

    private void PromptInputNumbers() =>
        Console.Write(" Input numbers: ");

    private void PromptDesiredResult() =>
        Console.Write("Desired result: ");
}