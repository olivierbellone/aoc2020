using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Day13
{
    public static class Solver
    {
        public static long Part1(long timestamp, IEnumerable<string> busIds)
        {
            if (busIds == null)
            {
                throw new ArgumentNullException(nameof(busIds));
            }

            IEnumerable<(long, int)> validBusIdsWithIndexes = busIds
                .Select((busId, i) => (busId, i))
                .Where(t => t.Item1 != "x")
                .Select(t => (long.Parse(t.Item1, CultureInfo.InvariantCulture), t.Item2));

            var t = validBusIdsWithIndexes
                .Select(t => {
                    long tmp = closestMultipleGreaterThan(timestamp, t.Item1);
                    return (tmp % timestamp, t.Item1);
                })
                .OrderBy(t => t.Item1)
                .First();
            
            return t.Item1 * t.Item2;
        }

        private static long closestMultipleGreaterThan(long n, long x) => (n + x) - ((n + x) % x);

        public static long Part2(IEnumerable<string> busIds)
        {
            if (busIds == null)
            {
                throw new ArgumentNullException(nameof(busIds));
            }

            IEnumerable<(long, int)> validBusIdsWithIndexes = busIds
                .Select((busId, i) => (busId, i))
                .Where(t => t.Item1 != "x")
                .Select(t => (long.Parse(t.Item1, CultureInfo.InvariantCulture), t.Item2));

            return ChineseRemainderTheorem.Solve(
                validBusIdsWithIndexes.Select(t => t.Item1).ToArray(),
                validBusIdsWithIndexes.Select(t => t.Item1 - t.Item2).ToArray()
            );
        }

        private static class ChineseRemainderTheorem
        {
            public static long Solve(long[] n, long[] a)
            {
                long prod = n.Aggregate(1L, (i, j) => i * j);
                long p;
                long sm = 0;
                for (long i = 0; i < n.Length; i++)
                {
                    p = prod / n[i];
                    sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
                }
                return sm % prod;
            }
    
            private static long ModularMultiplicativeInverse(long a, long mod)
            {
                long b = a % mod;
                for (long x = 1; x < mod; x++)
                {
                    if ((b * x) % mod == 1)
                    {
                        return x;
                    }
                }
                return 1;
            }
        }
    }
}
