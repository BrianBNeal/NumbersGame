using NumbersGameRedesigned.Domain.Expressions;
using System.Numerics;

namespace NumbersGameRedesigned.Domain;

abstract class Expression
{
    public abstract int Value { get; }
}

static class ExpressionExtensions
{
    public static Expression Add(this Expression head, IEnumerable<Expression> others) =>
        others.Aggregate(head, (current, other) => new Add(current, other));

    public static Expression Subtract(this Expression head, IEnumerable<Expression> others) =>
        others.Aggregate(head, (current, other) => new Subtract(current, other));
}