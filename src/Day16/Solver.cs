using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day16
{
    public static class Solver
    {
        public static int Part1(Input input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input.ScanningErrorRate();
        }

        public static long Part2(Input input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var orderedRules = input.OrderedRules();

            return orderedRules
                .Where(kvp => kvp.Value.StartsWith("departure", StringComparison.InvariantCulture))
                .Aggregate(1L, (acc, kvp) => acc *= input.yourTicket[kvp.Key]);
        }
    }
}
