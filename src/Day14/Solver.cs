using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day14
{
    public static class Solver
    {
        private static Regex reMem = new Regex(@"mem\[(?<addr>\d+)\]");

        public static long Part1(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            string[] lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            IDictionary<long, long> mem = new Dictionary<long, long>();

            long zeroes = long.MaxValue;
            long ones = 0;

            foreach (string line in lines)
            {
                string[] elements = line.Split(" = ");
                string action = elements[0];
                string value = elements[1];

                if (action == "mask")
                {
                    zeroes = long.MaxValue;
                    ones = 0;
                    long pow = 1;

                    foreach (char c in value.ToCharArray().Reverse())
                    {
                        if (c == '0')
                        {
                            zeroes &= long.MaxValue - pow;
                        }
                        else if (c == '1')
                        {
                            ones |= pow;
                        }
                        pow *= 2;
                    }
                }
                else
                {
                    Match m = reMem.Match(line);
                    long addr = long.Parse(m.Groups["addr"].Value, CultureInfo.InvariantCulture);

                    mem[addr] = (long.Parse(value, CultureInfo.InvariantCulture) & zeroes) | ones;
                }
            }

            return mem.Values.Sum();
        }

        public static long Part2(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            string[] lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            IDictionary<long, long> mem = new Dictionary<long, long>();

            string mask = string.Empty;
            int numXs = 0;

            foreach (string line in lines)
            {
                string[] elements = line.Split(" = ");
                string action = elements[0];
                string value = elements[1];

                if (action == "mask")
                {
                    mask = value;
                    numXs = mask.Where(c => c is 'X').Count();
                }
                else
                {
                    Match m = reMem.Match(line);
                    long baseAddr = long.Parse(m.Groups["addr"].Value, CultureInfo.InvariantCulture);

                    string baseAddrBin = Convert.ToString(baseAddr, 2).PadLeft(36, '0');

                    string maskedAddrBin = new string(mask.ToCharArray()
                        .Select((c, i) => c is 'X' or '1' ? c : baseAddrBin[i])
                        .ToArray());

                    IEnumerable<long> addrs = Enumerable.Range(0, 2 << numXs)
                        .Select(x => Convert.ToString(x, 2).PadLeft(numXs, '0'))
                        .Select(bin =>
                        {
                            int j = 0;
                            return maskedAddrBin.ToCharArray().Aggregate(string.Empty,
                                (acc, c) => acc + (c is 'X' ? bin[j++] : c));
                        })
                        .Select(x => Convert.ToInt64(x, 2));

                    foreach (long a in addrs)
                    {
                        mem[a] = long.Parse(value, CultureInfo.InvariantCulture);
                    }
                }
            }

            return mem.Values.Sum();
        }
    }
}
