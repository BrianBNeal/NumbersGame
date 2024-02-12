using System.Collections;

namespace NumbersGameRedesigned.Common;

class Partitioning<T> : IEnumerable<Partition<T>>
{
    private IEnumerable<Partition<T>> Partitions { get; }

    public Partitioning(IEnumerable<Partition<T>> partitions)
    {
        Partitions = partitions.ToList();
    }

    public IEnumerator<Partition<T>> GetEnumerator() =>
        Partitions.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();
}