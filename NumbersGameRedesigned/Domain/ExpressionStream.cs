using NumbersGameRedesigned.Common;
using NumbersGameRedesigned.Domain.Expressions;
using System.Runtime.CompilerServices;

namespace NumbersGameRedesigned.Domain;

internal class ExpressionStream
{
    //old algo was =,+,-,-,*,/,/
    public IEnumerable<Expression> DistinctFor(IEnumerable<int> inputNumbers) =>
        Split(inputNumbers)
            .Where(split => split.left.Any())
            .Select(split => 
                CreateAdditive(split.left.First(), split.left.Skip(1), split.right));

    private Expression CreateAdditive(
        int head,
        IEnumerable<int> add,
        IEnumerable<int> subtract) =>
        CreateAdditive(
            new Literal(head),
            add.Select(value => new Literal(value)),
            subtract.Select(value => new Literal(value)));

    private Expression CreateAdditive(
        Literal head,
        IEnumerable<Literal> add,
        IEnumerable<Literal> subtract) =>
        head.Add(add).Subtract(subtract);

    private IEnumerable<(IEnumerable<int> left, IEnumerable<int> right)> Split(
        IEnumerable<int> numbers) =>
        numbers.IsEmpty() ? new[] { (Enumerable.Empty<int>(), Enumerable.Empty<int>()) }
        : Split(numbers.First(), numbers.Skip(1));

    private IEnumerable<(IEnumerable<int> left, IEnumerable<int> right)> Split(
        int head,
        IEnumerable<int> tail) =>
        Combine(TrivialSplit(head), Split(tail).ToList());

    private IEnumerable<(IEnumerable<int> left, IEnumerable<int> right)> Combine(
        IEnumerable<(IEnumerable<int> left, IEnumerable<int> right)> head,
        IEnumerable<(IEnumerable<int> left, IEnumerable<int> right)> tail) =>
        head.SelectMany(split => tail.Select(
            tuple => (split.left.Concat(tuple.left), split.right.Concat(tuple.right))));

    private IEnumerable<(IEnumerable<int> left, IEnumerable<int> right)> TrivialSplit(
        int number) =>
        new (IEnumerable<int>, IEnumerable<int>)[]
        {
            (new[] {number },  Enumerable.Empty<int>()),
            (Enumerable.Empty<int>(), new[] {number})
        };
}
