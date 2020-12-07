using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day7
{
    public class BagRules
    {
        /// <summary>Returns the list of all bags for this set of rules.</summary>
        public IList<Bag> Bags { get => this._bags.Values.ToList(); }

        private static readonly Regex ruleRegex = new Regex(@"(?<color>.+) bags contain (?<contained>.+)\.");

        private static readonly Regex containedRegex = new Regex(@"(?<number>\d+) (?<color>.+) bags?");

        private IDictionary<string, Bag> _bags = new Dictionary<string, Bag>();

        private BagRules()
        {
        }

        public static BagRules FromString(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            BagRules rules = new BagRules();

            foreach (string line in input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                Match m = ruleRegex.Match(line);

                if (!m.Success)
                {
                    throw new ArgumentException($"Invalid rule: \"{line}\"", nameof(input));
                }

                Bag bag = rules.GetOrCreateBag(m.Groups["color"].Value);

                string contained = m.Groups["contained"].Value;

                if (contained == "no other bags")
                {
                    continue;
                }
                else
                {
                    foreach (string item in contained.Split(','))
                    {
                        m = containedRegex.Match(item);

                        if (!m.Success)
                        {
                            throw new ArgumentException($"Invalid contained item: \"{item}\"", nameof(input));
                        }

                        Bag containedBag = rules.GetOrCreateBag(m.Groups["color"].Value);
                        long number = long.Parse(m.Groups["number"].Value, CultureInfo.InvariantCulture);
                        bag.AddContainedBagInfo(containedBag, number);
                    }
                }
            }

            return rules;
        }

        public Bag GetBagByColor(string color)
        {
            return _bags[color];
        }

        private Bag GetOrCreateBag(string color)
        {
            if (!_bags.ContainsKey(color))
            {
                _bags[color] = new Bag(color);
            }
            
            return _bags[color];
        }
    }
}
