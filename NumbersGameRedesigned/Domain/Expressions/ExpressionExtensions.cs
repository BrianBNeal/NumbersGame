using System.Numerics;

namespace NumbersGameRedesigned.Domain.Expressions;

static class ExpressionExtensions
{
    public static Expression Add(this Expression head, IEnumerable<Expression> others) =>
        others.Aggregate(head, (current, other) => new Add(current, other));

    public static Expression Subtract(this Expression head, IEnumerable<Expression> others) =>
        others.Aggregate(head, (current, other) => new Subtract(current, other));

    public static Expression Multiply(this Expression head, IEnumerable<Expression> others) =>
        others.Aggregate(head, (current, other) => new Multiply(current, other));
}