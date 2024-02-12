﻿
//repeat until no input
//read input numbers
//find an expression
//print the expression

//problem statements list
//solver
//print

using NumbersGameRedesigned.Common;
using NumbersGameRedesigned.Domain;

ExpressionStreamDemo();


static void ExpressionStreamDemo() => // a way to view the workings of the ExpressionStream for dev purposes
    InputNumbersSequence()
        .Select(new ExpressionStream().DistinctFor)
        .SelectMany(expressions => Report(expressions, "No expressions found."))
        .WriteLinesTo(Console.Out);

static void ProductionBehavior() => 
    ProblemStatements()
        .Select(new ExactSolver().DistinctExpressionsFor)
        .SelectMany(expressions => Report(expressions, "No solutions for the problem."))
        .WriteLinesTo(Console.Out);

static IEnumerable<string> Report(IEnumerable<Expression> expressions, string onEmpty) =>
    expressions
        .Select((expression, index) => $"{index + 1,3}. {expression} = {expression.Value}")
        .DefaultIfEmpty(onEmpty);

static IEnumerable<IEnumerable<int>> InputNumbersSequence() =>
    new ConsoleInputsReader().ReadAll();

static IEnumerable<ProblemStatement> ProblemStatements() =>
        new ConsoleProblemsReader().ReadAll();