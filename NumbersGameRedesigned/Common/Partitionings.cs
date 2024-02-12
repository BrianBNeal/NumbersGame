namespace NumbersGameRedesigned.Common;

static class Partitionings
{
    public static Partitionings<T> Of<T>(IEnumerable<T> sequence) =>
        new Partitionings<T>(sequence);
}

class Partitionings<T>
{
    private IEnumerable<T> EntireSequence { get; }

    public Partitionings(IEnumerable<T> data)
    {
        EntireSequence = data.ToList();
    }

    public IEnumerable<Partitioning<T>> All() =>
        new Partitioning<T>(EntireSequence.AsPartition())
            .ExpandEndlessly(partitioning => partitioning.Expand());
}
