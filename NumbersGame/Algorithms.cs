internal static class Algorithms
{
    internal static ArithmaticExpression? Solve(ProblemStatement problem)
    {
        Queue<ArithmaticExpression> combining = new(
            problem.InputNumbers.Select(x => new ArithmaticExpression(x)));

        List<ArithmaticExpression> known = new();

        while (combining.TryDequeue(out ArithmaticExpression? current)) 
        { 
            if (current.Value == problem.Target) return current;

            IEnumerable<ArithmaticExpression> combinableWith = known
                .Where(x => !x.UsedNumbers.Intersect(current.UsedNumbers).Any());

            foreach (var existing in combinableWith)
            {
                combining.Enqueue(
                    current.CombineWith(existing, '+', current.Value + existing.Value));
                
                combining.Enqueue(
                    current.CombineWith(existing, '-', current.Value - existing.Value));
                combining.Enqueue(
                    existing.CombineWith(current, '-', existing.Value - current.Value));
            }

            known.Add(current);
        }

        return null;
    }
}
