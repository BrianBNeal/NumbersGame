namespace NumbersGameRedesigned.Domain.Expressions;

internal class Divide : BinaryExpression
{
    public Divide(Expression numerator, Expression denominator) : base(numerator, denominator) { }
    protected override string OperatorToString => "/";
    protected override int Combine(int numerator, int denominator) => numerator / denominator;
}