while (true)
{

    try
    {
        ProblemStatement? problem = UiLogic.ReadProblem();
        if (problem == null) break;
        ArithmaticExpression? expression = Algorithms.Solve(problem);

        UiLogic.WriteReport(expression);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        Console.ReadLine();
        throw;
    }
}