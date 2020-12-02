using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    public static class Solver
    {
        public static int Part1(IList<Entry> entries)
        {
            if (entries == null)
            {
                throw new ArgumentNullException(nameof(entries));
            }

            return entries.Where(entry => entry.ValidSRPDTS()).Count();
        }

        public static int Part2(IList<Entry> entries)
        {
            if (entries == null)
            {
                throw new ArgumentNullException(nameof(entries));
            }

            return entries.Where(entry => entry.ValidOTCA()).Count();
        }
    }
}
