public class ProblemStatement
{
    public IEnumerable<int> InputNumbers { get; }

    public ProblemStatement(IEnumerable<int> inputs)
    {
        InputNumbers = inputs;
    }

    public override string ToString() =>
        $"Problem Statement: [{InputNumbersFormattedList}]";

    private string InputNumbersFormattedList =>
        string.Join(", ", InputNumbers.Select(number => $"{number}").ToArray());
}