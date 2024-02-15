namespace NumbersGameRedesigned.Domain.Expressions;

static class ExpressionExtensions
{
    public static Expression Add(this Expression head, IEnumerable<Expression> others) =>
        others.Aggregate(head, (current, other) => new Add(current, other));

    public static IEnumerable<Expression> TrySubtract(this Expression head, IEnumerable<Expression> others)
    {
        Expression current = head;
        foreach (Expression other in others)
        {
            if (current.Value - other.Value < 1)
                yield break;
            current = new Subtract(current, other);
        }

        yield return current;
    }

    public static IEnumerable<Expression> TryMultiply(this Expression head, IEnumerable<Expression> others)
    {
        Expression current = head;
        foreach (Expression other in others)
        {
            if (other.Value == 1 || current.Value == 1)
                yield break;
            current = new Multiply(current, other);
        }
        yield return current;
    }
        

    public static IEnumerable<Expression> TryDivide(
        this Expression head, IEnumerable<Expression> others)
    {
        Expression current = head;

        foreach (Expression other in others)
        {
            if (other.Value <= 1 || current.Value % other.Value != 0)
                yield break;
            current = new Divide(current, other);
        }

        yield return current;
    }
}