public class ProblemStatement
{
    public IEnumerable<int> InputNumbers { get; }
    public int DesiredResult { get; }

    public ProblemStatement(
        IEnumerable<int> inputs,
        int desiredResult)
    {
        InputNumbers = inputs;
        DesiredResult = desiredResult;
    }

    public override string ToString() =>
        $"Problem Statement: {{{InputNumbersFormattedList}}} -> {DesiredResult}";

    private string InputNumbersFormattedList =>
        string.Join(", ", InputNumbers.Select(number => $"{number}").ToArray());
}