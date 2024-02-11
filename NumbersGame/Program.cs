while (true)
{
    ProblemStatement? problem = UiLogic.ReadProblem();
    if (problem == null) break;
    ArithmaticExpression? expression = Algorithms.Solve(problem);

    UiLogic.WriteReport(expression);

    
}