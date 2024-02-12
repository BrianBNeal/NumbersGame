namespace NumbersGameRedesigned.Domain.Expressions;

internal abstract class BinaryExpression : Expression
{
    private Expression Left { get; }
    private Expression Right { get; }

    public override int Value =>
        Combine(Left.Value, Right.Value);

    protected BinaryExpression(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }

    protected abstract int Combine(int left, int right);
    protected abstract string OperatorToString {  get; }

    public override string ToString() =>
        $"{Left} {OperatorToString} {Right}";
}
