using System;
using System.Collections.Generic;
using System.Linq;

namespace Day19
{
    public static class Solver
    {
        public static int Part1(RuleSet ruleSet, IEnumerable<string> messages)
        {
            if (ruleSet == null)
            {
                throw new ArgumentNullException(nameof(ruleSet));
            }
            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            return messages.Where(message => ruleSet.Matches(message, 0)).Count();
        }

        public static int Part2(RuleSet ruleSet, IEnumerable<string> messages)
        {
            if (ruleSet == null)
            {
                throw new ArgumentNullException(nameof(ruleSet));
            }
            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            ruleSet = ruleSet.Clone();
            ruleSet.Rules[8] = Rule.FromString("42 | 42 8");
            ruleSet.Rules[11] = Rule.FromString("42 31 | 42 11 31");

            return messages.Where(message => ruleSet.Matches(message, 0)).Count();
        }
    }
}
