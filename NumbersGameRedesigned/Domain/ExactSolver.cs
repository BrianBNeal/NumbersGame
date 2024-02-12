
namespace NumbersGameRedesigned.Domain;

internal class ExactSolver
{
    public ExactSolver()
    {
    }

    internal IEnumerable<Expression> DistinctExpressionsFor(ProblemStatement problem) =>
        new ExpressionStream()
            .DistinctFor(problem.InputNumbers)
            .Where(expression => expression.Value == problem.DesiredResult);
}
