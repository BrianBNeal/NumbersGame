using NumbersGameRedesigned.Common;
using NumbersGameRedesigned.Domain.Expressions;

namespace NumbersGameRedesigned.Domain;

internal class ExpressionStream
{
    public IEnumerable<Expression> DistinctFor(
        IEnumerable<int> inputNumbers) =>
        inputNumbers.Select(number => new Literal(number))
            .AsPartition()
            .Split()
            .Where(split => split.left.Any())
            .Select(split => 
                CreateAdditive(split.left.First(), split.left.Skip(1), split.right));

    private Expression CreateAdditive(
        Literal head,
        IEnumerable<Literal> add,
        IEnumerable<Literal> subtract) =>
        head.Add(add).Subtract(subtract);
}