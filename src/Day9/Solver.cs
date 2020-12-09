using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Day9
{
    public static class Solver
    {
        public static bool TryPart1(IList<long> numbers, out long result, int preambleLength = 25)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            for (int i = preambleLength; i < numbers.Count; i++)
            {
                IEnumerable<long> slice = numbers.Skip(i - preambleLength).Take(preambleLength);

                var sums = slice
                    .SelectMany((_, i) => slice.Where((_, j) => i < j), (x, y) => x + y)
                    .ToHashSet();

                long nextNumber = numbers[i];

                if (!sums.Contains(nextNumber))
                {
                    result = nextNumber;
                    return true;
                }
            }

            result = 0L;
            return false;
        }

        public static bool TryPart2(IList<long> numbers, out long result, int preambleLength = 25)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (!TryPart1(numbers, out long invalidNumber, preambleLength))
            {
                result = 0;
                return false;
            }

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                IEnumerable<long> slice = null;
                long sum = 0L;
                for (int j = 1; sum < invalidNumber; j++)
                {
                    slice = numbers.Skip(i).Take(j);
                    sum = slice.Sum();
                }

                if (sum == invalidNumber)
                {
                    result = slice.Min() + slice.Max();
                    return true;
                }
            }

            result = 0L;
            return false;
        }
    }
}
