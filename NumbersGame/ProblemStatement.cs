internal class ProblemStatement
{
    public List<int> InputNumbers { get; }
    public int Target {  get; }

    public ProblemStatement(
        List<int> numbers,
        int target)
    {
        InputNumbers = numbers;
        Target = target;
    }
}