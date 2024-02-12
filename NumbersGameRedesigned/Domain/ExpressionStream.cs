using NumbersGameRedesigned.Common;
using NumbersGameRedesigned.Domain.Expressions;

namespace NumbersGameRedesigned.Domain;

internal class ExpressionStream
{
    //old algo was =,+,-,-,*,/,/
    public IEnumerable<Expression> DistinctFor(IEnumerable<int> inputNumbers) =>
        inputNumbers.IsEmpty() ? Enumerable.Empty<Expression>()
        : new[] { Add(inputNumbers) };

    private Expression Add(IEnumerable<int> numbers) =>
        numbers.Select<int, Expression>(number => new Literal(number))
            .Aggregate((left, next) => new Add(left, next));
}
