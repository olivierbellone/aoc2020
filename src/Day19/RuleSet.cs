using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day19
{
    public class RuleSet
    {
        /// <summary>Gets the dictionary mapping rule numbers to rule definitions.</summary>
        public IDictionary<int, Rule> Rules { get; }

        private RuleSet(IDictionary<int, Rule> rules) =>
            Rules = rules;


        /// <summary>Initializes a new instance of <c>RuleSet</c> from a string.</summary>
        public static RuleSet FromString(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            IDictionary<int, Rule> rules = new Dictionary<int, Rule>();

            foreach (string line in str.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] parts = line.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                int number = int.Parse(parts[0], CultureInfo.InvariantCulture);
                var rule = Rule.FromString(parts[1]);
                rules[number] = rule;
            }

            return new RuleSet(rules);
        }

        /// <summary>
        /// Returns a shallow clone of the <c>RuleSet</c> instance. The <c>Rule</c> instances in
        /// the <c>Rules</c> dictionary are not cloned.
        /// </summary>
        public RuleSet Clone()
        {
            return new RuleSet(Rules.ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
        }

        /// <summary>
        /// Returns <c>true</c> if the provided string <c>str</c> matches the rule with number
        /// <c>ruleNumber</c>; otherwise, returns <c>false</c>.
        /// </summary>
        public bool Matches(string str, int ruleNumber)
        {
            return Matches(str, new List<int> { ruleNumber });
        }

        /// <summary>
        /// Returns <c>true</c> if the provided string <c>str</c> matches the consecutive rules
        /// with numbers <c>ruleNumbers</c>; otherwise, returns <c>false</c>.
        /// </summary>
        public bool Matches(string str, IList<int> ruleNumbers)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            if (ruleNumbers == null)
            {
                throw new ArgumentNullException(nameof(ruleNumbers));
            }

            if (ruleNumbers.Count == 0)
            {
                return str.Length == 0;
            }

            Rule rule = Rules[ruleNumbers.First()];
            IList<int> rest = ruleNumbers.Skip(1).ToList();

            if (rule.Terminal)
            {
                return str.StartsWith(rule.Pattern, StringComparison.InvariantCulture) &&
                    Matches(str[rule.Pattern.Length..], rest);
            }

            return rule.OrRules.Any(andRules => Matches(str, andRules.Concat(rest).ToList()));
        }
    }
}
