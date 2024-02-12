
//repeat until no input
//read input numbers
//find an expression
//print the expression

//problem statements list
//solver
//print

using NumbersGameRedesigned.Common;

ProblemStatements().WriteLinesTo(Console.Out);

static IEnumerable<ProblemStatement> ProblemStatements() =>
        new ConsoleProblemsReader().ReadAll();