internal class ArithmaticExpression
{
    public ArithmaticExpression(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public override string ToString()
    {
        return $@"{Value} = {Value}";
    }
}
