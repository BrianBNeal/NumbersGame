using NumbersGameRedesigned.Common;
using NumbersGameRedesigned.Domain.Expressions;

namespace NumbersGameRedesigned.Domain;

internal class ExpressionStream
{
    public IEnumerable<Expression> DistinctFor(IEnumerable<int> inputNumbers) =>
        Partitionings.Of(AsLiterals(inputNumbers))
            .All()
            .Select(partitioning => partitioning.Select(Multiply))
            .SelectMany(subexpressions => subexpressions
                .AsPartition()
                .Split()
                .Where(split => split.left.Any()) //TODO: what is this doing?
                .Select(split =>
                    CreateAdditive(split.left.First(), split.left.Skip(1), split.right)));

    private IEnumerable<Expression> AsLiterals(IEnumerable<int> inputNumbers) =>
        inputNumbers.Select(number => new Literal(number));

    private Expression Multiply(IEnumerable<Expression> expressions) =>
        CreateMultiplicative(expressions.First(), expressions.Skip(1));

    private Expression CreateAdditive(Expression head, IEnumerable<Expression> add, IEnumerable<Expression> subtract) =>
        head.Add(add).Subtract(subtract);

    private Expression CreateMultiplicative(Expression head, IEnumerable<Expression> multiply) =>
        head.Multiply(multiply);
}
