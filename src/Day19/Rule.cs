using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Day19
{
    public record Rule(string Pattern, IList<IList<int>> OrRules)
    {
        /// <summary>
        /// Returns <c>true</c> if the rule is terminal (i.e. it matches a character sequence) or
        /// <c>false</c> if it isn't (i.e. it references other rules).
        /// </summary>
        public bool Terminal => Pattern != null;

        /// <summary>Initializes a new instance of <c>Rule</c> from a string.</summary>
        public static Rule FromString(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str.StartsWith("\"", StringComparison.InvariantCulture))
            {
                return new Rule(str.Trim('"'), null);
            }

            IList<IList<int>> orRules = str
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => (IList<int>)x
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(y => int.Parse(y, CultureInfo.InvariantCulture))
                    .ToList()
                )
                .ToList();

            return new Rule(null, orRules);
        }
    }
}
