using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day6
{
    public static class Solver
    {
        public static long Part1(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input
                .Trim()
                .Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(group => Regex.Replace(group, @"[^a-z]", "").Distinct().Count())
                .Sum();
        }

        public static long Part2(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input
                .Trim()
                .Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(group => group
                    .Split(Environment.NewLine)
                    .Aggregate(
                        Regex.Replace(group, @"[^a-z]", "").Distinct(),
                        (acc, line) => acc.Intersect(line)
                    )
                    .Count()
                )
                .Sum();
        }
    }
}
