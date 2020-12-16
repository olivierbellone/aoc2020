using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day16
{
    public record Input
    {
        public IDictionary<string, IList<(int, int)>> rules { get; init; }
        public IList<int> yourTicket { get; init; }
        public IList<IList<int>> nearbyTickets { get; init; }

        public static Input FromString(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            var blocks = str.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);

            var rules = blocks[0]
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Split(": "))
                .ToDictionary(
                    x => x[0],
                    x => (IList<(int, int)>)x[1]
                        .Split(" or ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(y => {
                            var t = y.Split("-", StringSplitOptions.RemoveEmptyEntries);
                            return (
                                int.Parse(t[0], CultureInfo.InvariantCulture),
                                int.Parse(t[1], CultureInfo.InvariantCulture)
                            );
                        })
                        .ToList()
                );
            
            var yourTicket = blocks[1]
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x, CultureInfo.InvariantCulture))
                .ToList();

            var nearbyTickets = blocks[2]
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)[1..]
                .Select(line => (IList<int>)line
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x, CultureInfo.InvariantCulture))
                    .ToList())
                .ToList();

            return new Input
            {
                rules = rules,
                yourTicket = yourTicket,
                nearbyTickets = nearbyTickets,
            };
        }

        public int ScanningErrorRate()
        {
            return nearbyTickets
                .Select(ticket => ticket
                    .Select(field => IsFieldValid(field) ? 0 : field)
                    .Sum()
                )
                .Sum();
        }

        public Dictionary<int, string> OrderedRules()
        {
            var orderedRules = new Dictionary<int, string>();

            var validNearbyTickets = nearbyTickets.Where(ticket => IsTicketValid(ticket)).ToList();
            var fieldsByPositions = Enumerable.Range(0, validNearbyTickets[0].Count)
                .Select(
                    i => validNearbyTickets.Select(ticket => ticket[i]).ToList()
                )
                .ToList();
            
            var ruleNames = rules.Keys.ToList();
            while (ruleNames.Count > 0)
            {
                for (int pos = 0; pos < fieldsByPositions.Count; pos++)
                {
                    if (orderedRules.Keys.Contains(pos))
                    {
                        continue;
                    }

                    var candidateRules = new List<string>();
                    foreach (var ruleName in ruleNames)
                    {
                        var rule = rules[ruleName];

                        if (fieldsByPositions[pos].All(field => rule.Any(range => field >= range.Item1 && field <= range.Item2)))
                        {
                            candidateRules.Add(ruleName);
                        }
                    }

                    if (candidateRules.Count == 1)
                    {
                        var ruleName = candidateRules[0];
                        ruleNames.Remove(ruleName);
                        orderedRules.Add(pos, ruleName);
                    }
                }
            }

            return orderedRules;
        }

        private bool IsTicketValid(IList<int> ticket)
        {
            return ticket.All(field => IsFieldValid(field));
        }

        private bool IsFieldValid(int field)
        {
            return rules.Values.Any(rule => rule
                .Any(range => field >= range.Item1 && field <= range.Item2)
            );
        }
    }
}
