while (true)
{
    ProblemStatement? problem = UiLogic.ReadProblem();
    if (problem == null) break;
    ArithmaticExpression? expression = Algorithms.Solve(problem);

    string report = expression?.ToString() ?? "No solution found.";
    Console.WriteLine(report);
    Console.WriteLine();
}