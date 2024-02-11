internal static class Algorithms
{
    internal static ArithmaticExpression? Solve(ProblemStatement problem)
    {
        return problem.InputNumbers
            .Where(x => x == problem.Target)
            .Select(x => new ArithmaticExpression(x))
            .FirstOrDefault();
    }
}
