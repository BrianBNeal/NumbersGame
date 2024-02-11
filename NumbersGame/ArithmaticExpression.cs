
internal class ArithmaticExpression
{
    public int Value { get; }
    public IEnumerable<int> UsedNumbers { get; }
    public char Operator { get; }
    public ArithmaticExpression LeftChild { get; }
    public ArithmaticExpression RightChild { get; }

    public ArithmaticExpression(int value)
    {
        Value = value;
        UsedNumbers = new[] { value };
        Operator = '\0';
    }

    private ArithmaticExpression(int value, char @operator, ArithmaticExpression leftChild, ArithmaticExpression rightChild)
    {
        Value = value;
        Operator = @operator;
        UsedNumbers = leftChild.UsedNumbers.Concat(rightChild.UsedNumbers);
        LeftChild = leftChild;
        RightChild = rightChild;
    }

    public ArithmaticExpression CombineWith(ArithmaticExpression other, char @operator, int value) => 
        new ArithmaticExpression(value, @operator, this, other);

    public override string ToString() =>
        $"{PlainToString(this)} = {Value}";

    private string PlainToString(ArithmaticExpression expr) =>
        expr.Operator == '\0' ? $"{expr.Value}"
        : $"{expr.Parenthesize(expr.LeftChild)} {expr.Operator} {expr.Parenthesize(expr.RightChild)}";

    private string Parenthesize(ArithmaticExpression child) =>
        child.Operator == '\0' ? $"{child.Value}" : $"({PlainToString(child)})";
}
