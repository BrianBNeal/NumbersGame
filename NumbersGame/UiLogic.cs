using System.Text.RegularExpressions;

static class UiLogic
{
    internal static ProblemStatement? ReadProblem()
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

    internal static void WriteReport(ArithmaticExpression? expression)
    {
        string report = expression?.ToString() ?? "No solution found.";

        Console.WriteLine(report);
        Console.WriteLine();
    }
}
