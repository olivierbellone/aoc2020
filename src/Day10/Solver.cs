using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public static class Solver
    {
        public static long Part1(IList<long> numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            numbers = numbers.OrderBy(x => x).ToList();
            numbers.Insert(0, 0);
            numbers.Add(numbers.Max() + 3);

            var diffs = new Dictionary<long, int>();
            long jolts = 0L;

            while (numbers.Any())
            {
                long min = numbers[0];
                numbers.RemoveAt(0);

                long diff = min - jolts;
                if (!diffs.ContainsKey(diff))
                {
                    diffs[diff] = 0;
                }
                diffs[diff]++;

                jolts = min;
            }

            return diffs[1] * diffs[3];
        }

        public static long Part2(IList<long> numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            numbers = numbers.OrderBy(x => x).ToList();
            numbers.Insert(0, 0);
            numbers.Add(numbers.Max() + 3);

            pathCounts = new Dictionary<long, long> {{(numbers.Count - 2), 1L}};
            return FindValid(numbers);
        }

        private static IDictionary<long, long> pathCounts;

        private static long FindValid(IList<long> numbers, int start = 0)
        {
            if (pathCounts.ContainsKey(start))
            {
                return pathCounts[start];
            }

            long count = 0L;
            foreach (int i in Enumerable.Range(1, 3))
            {
                if ((start + i < numbers.Count) && (numbers[start + i] - numbers[start] <= 3))
                {
                    count += FindValid(numbers, start + i);
                }
            }
            pathCounts[start] = count;
            return count;
        }
    }
}
