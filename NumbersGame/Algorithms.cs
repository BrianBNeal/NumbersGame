
internal static class Algorithms
{
    private static IEnumerable<int> ExceptWithDuplicates(
        IEnumerable<int> source,
        IEnumerable<int> remove) =>
        source.Select(value => (value: value, count: 1))
            .Concat(remove.Select(value => (value: value, count: -1)))
            .GroupBy(tuple => tuple.value)
            .Select(group => (value: group.Key, count: group.Sum(tuple => tuple.count)))
            .Where(tuple => tuple.count > 0)
            .SelectMany(tuple => Enumerable.Repeat(tuple.value, tuple.count));

    private static bool IsSuperset(
        IEnumerable<int> sequence,
        IEnumerable<int> of) =>
        sequence.Select(value => (value: value, count: 1))
            .Concat(of.Select(value => (value: value, count: -1)))
            .GroupBy(tuple => tuple.value)
            .All(group => group.Sum(tuple => tuple.count) >= 0);



    internal static ArithmaticExpression? Solve(ProblemStatement problem)
    {
        Queue<ArithmaticExpression> combining = new(
            problem.InputNumbers.Select(x => new ArithmaticExpression(x)));

        HashSet<ArithmaticExpression> known = new();

        while (combining.TryDequeue(out ArithmaticExpression? current))
        {
            if (current.Value == problem.Target) return current;

            IEnumerable<int> availableNumbers = 
                ExceptWithDuplicates(problem.InputNumbers, current.UsedNumbers);

            IEnumerable<ArithmaticExpression> combinableWith = 
                known.Where(expr => IsSuperset(availableNumbers, expr.UsedNumbers));

            foreach (var existing in combinableWith)
            {
                // addition
                combining.Enqueue(
                    current.CombineWith(existing, '+', current.Value + existing.Value));

                // subtraction
                combining.Enqueue(
                    current.CombineWith(existing, '-', current.Value - existing.Value));
                combining.Enqueue(
                    existing.CombineWith(current, '-', existing.Value - current.Value));

                //multiplication
                combining.Enqueue(
                    current.CombineWith(existing, '*', current.Value * existing.Value));

                //division
                if (existing.Value != 0 && current.Value % existing.Value == 0)
                    combining.Enqueue(
                        current.CombineWith(existing, '/', current.Value / existing.Value));
                if (current.Value != 0 && existing.Value % current.Value == 0)
                    combining.Enqueue(
                        existing.CombineWith(current, '/', existing.Value / current.Value));
            }

            known.Add(current);
        }

        return null;
    }

    
}
