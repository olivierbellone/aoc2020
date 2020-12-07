using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day7
{
    public static class Solver
    {
        public static long Part1(BagRules rules)
        {
            if (rules == null)
            {
                throw new ArgumentNullException(nameof(rules));
            }

            return rules.Bags.Where((bag) => bag.CanContain("shiny gold")).Count();
        }

        public static long Part2(BagRules rules)
        {
            if (rules == null)
            {
                throw new ArgumentNullException(nameof(rules));
            }

            return rules.GetBagByColor("shiny gold").ContainedBags() - 1;
        }
    }
}
