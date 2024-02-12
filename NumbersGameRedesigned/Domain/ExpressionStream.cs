
using NumbersGameRedesigned.Common;

namespace NumbersGameRedesigned.Domain;

internal class ExpressionStream
{
    //old algo was =,+,-,-,*,/,/
    public IEnumerable<Expression> DistinctFor(IEnumerable<int> inputNumbers) => 
        inputNumbers.IsEmpty() ? Enumerable.Empty<Expression>()
        : inputNumbers.Skip(1).IsEmpty() ? new Expression[] { new Literal(inputNumbers.Single()) } 
        : Enumerable.Empty<Expression>();
}

internal class Literal : Expression
{
    public override int Value { get; }

    public Literal(int value)
    {
        Value = value;
    }

    public override string ToString() =>
        $"{Value}";
}