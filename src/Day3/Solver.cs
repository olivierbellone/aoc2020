using System;
using System.Linq;

namespace Day3
{
    public static class Solver
    {
        public static long Part1(Map map)
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            return map.CountTrees(3, 1);
        }

        public static long Part2(Map map)
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            var slopes = new (int, int)[] {(1, 1), (3, 1), (5, 1), (7, 1), (1, 2)};

            return slopes.Aggregate(
                1L,
                (acc, slope) => acc *= map.CountTrees(slope.Item1, slope.Item2));
        }
    }
}
