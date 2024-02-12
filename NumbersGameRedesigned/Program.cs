
//repeat until no input
//read input numbers
//find an expression
//print the expression

//problem statements list
//solver
//print

using NumbersGameRedesigned.Common;
using NumbersGameRedesigned.Domain;

ProblemStatements()
    .Select(problem => new ExactSolver().DistinctExpressionsFor(problem))
    .SelectMany(expressions => expressions
        .Select((expression, index) =>
            $"{index + 1, 3}. {expression} = {expression.Value}")
        .DefaultIfEmpty("No solutions for the problem."))
    .WriteLinesTo(Console.Out);

static IEnumerable<ProblemStatement> ProblemStatements() =>
        new ConsoleProblemsReader().ReadAll();