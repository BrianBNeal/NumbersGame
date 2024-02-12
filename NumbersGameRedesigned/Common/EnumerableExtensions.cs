namespace NumbersGameRedesigned.Common;
internal static class EnumerableExtensions
{
    public static bool IsEmpty<T>(this IEnumerable<T> sequence) =>
        !sequence.Any();

    public static void WriteLinesTo<T>(this IEnumerable<T> sequence, TextWriter destination) =>
        sequence.Select(obj => $"{obj}").WriteLinesTo(destination);

    public static void WriteLinesTo(this IEnumerable<string> sequence, TextWriter destination)
    {
        foreach (string line in sequence)
        {
            destination.WriteLine(line);
        }
    }

    public static bool AllNotEmpty<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
    {
        bool any = false;

        foreach (T obj in sequence)
        {
            if (!predicate(obj)) return false;
            any = true;
        }

        return any;
    }

    public static Partition<T> AsPartition<T>(this IEnumerable<T> sequence) =>
        new Partition<T>(sequence);

    public static (IEnumerable<T> prefix, T last) ExtractLast<T>(this IEnumerable<T> sequence)
    {
        List<T> prefix = new List<T>();
        using (IEnumerator<T> enumerator = sequence.GetEnumerator())
        {
            enumerator.MoveNext();
            T last = enumerator.Current;

            while (enumerator.MoveNext())
            {
                prefix.Add(last);
                last = enumerator.Current;
            }

            return (prefix, last);
        }
    }
}