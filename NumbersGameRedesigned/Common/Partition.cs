using System.Collections;

namespace NumbersGameRedesigned.Common;

internal class Partition<T> : IEnumerable<T>
{
    private IEnumerable<T> Content { get; }
    public IEnumerable<(Partition<T> left, Partition<T> right)> Split() =>
        Split(Content);

    public Partition(IEnumerable<T> content)
    {
        Content = content.ToList();
    }
    public Partition(params T[] content) : this((IEnumerable<T>)content) { }

    private static Partition<T> Empty => new Partition<T>(Enumerable.Empty<T>());

    public IEnumerable<(Partition<T> left, Partition<T> right)> SplitAscending() =>
        Content.IsEmpty() ? new[] {(Partition<T>.Empty, Partition<T>.Empty)}
            : SplitAndPrependLeft(Content.First(), Content.Skip(1));

    private IEnumerable<(Partition<T> left, Partition<T> right)> Split(
        IEnumerable<T> sequence) =>
        sequence.IsEmpty() ? new[] { (Partition<T>.Empty, Partition<T>.Empty) }
        : Split(sequence.First(), sequence.Skip(1));

    private IEnumerable<(Partition<T> left, Partition<T> right)> Split(
        T head,
        IEnumerable<T> tail) =>
        Combine(TrivialSplit(head), Split(tail).ToList());

    private IEnumerable<(Partition<T> left, Partition<T> right)> SplitAndPrependLeft(
        T leftHead, IEnumerable<T> toSplit) =>
        Split(toSplit)
            .Select(split => Prepend(leftHead, split.left, split.right));

    private (Partition<T> left, Partition<T> right) Prepend(
        T leftHead, Partition<T> left, Partition<T> right) =>
            (new Partition<T>(
                new[] 
                {
                    leftHead 
                }.Concat(left)), right);

    private IEnumerable<(Partition<T> left, Partition<T> right)> Combine(
        IEnumerable<(Partition<T> left, Partition<T> right)> head,
        IEnumerable<(Partition<T> left, Partition<T> right)> tail) =>
        head.SelectMany(split => tail.Select(
            tuple => (split.left.Concat(tuple.left), split.right.Concat(tuple.right))));

    private IEnumerable<(Partition<T> left, Partition<T> right)> TrivialSplit(
        T value) =>
        new (Partition<T>, Partition<T>)[]
        {
            (new Partition<T>(value),  Partition<T>.Empty),
            (Partition<T>.Empty, new Partition<T>(value))
        };

    public Partition<T> Concat(Partition<T> other) =>
        new Partition<T>(Content.Concat(other.Content));

    public IEnumerator<T> GetEnumerator() =>
        Content.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();
}