
using System.Text.RegularExpressions;

while (true)
{
    ProblemStatement? problem = ReadProblem();
    if (problem == null) break;
    ArithmaticExpression expression = Solve(problem);

    string report = expression?.ToString() ?? "No solution found.";
    Console.WriteLine(report);
    Console.WriteLine();
}

ArithmaticExpression Solve(ProblemStatement problem)
{
    return null;
}

ProblemStatement? ReadProblem()
{
    Console.Write("Numbers to use (RETURN to exit): ");

    string input = Console.ReadLine() ?? string.Empty;

    string[] values = input.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);

    List<int> numbers = values
        .Where(x => Regex.IsMatch(x, @"^\d+$"))
        .Select(int.Parse)
        .ToList();

    if (numbers.Count == 0) return null;

    Console.Write("Enter target:");
    string rawTarget = Console.ReadLine() ?? string.Empty;
    if (!int.TryParse(rawTarget, out int target)) target = 0;

    return new ProblemStatement(numbers, target);
}

internal class ArithmaticExpression
{
}

internal class ProblemStatement
{
    private List<int> _numbers;
    private int _target;

    public ProblemStatement(
        List<int> numbers,
        int target)
    {
        _numbers = numbers;
        _target = target;
    }
}