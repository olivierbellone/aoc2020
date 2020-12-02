using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

[assembly: CLSCompliant(true)]

namespace Day2
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            string filename = args.Length > 0 ? args[0] : "input.txt";
            if (!File.Exists(filename))
            {
                Console.Error.WriteLine($"File not found: {filename}");
                return 100;
            }

            var entries = new List<Entry>();
            var regex = new Regex("(?<min>\\d+)-(?<max>\\d+) (?<letter>[a-z]): (?<password>[a-z]+)");
            foreach (string line in File.ReadAllLines(filename))
            {
                Match match = regex.Match(line);
                entries.Add(new Entry(
                    int.Parse(match.Groups["min"].Value, CultureInfo.InvariantCulture),
                    int.Parse(match.Groups["max"].Value, CultureInfo.InvariantCulture),
                    match.Groups["letter"].Value.ToCharArray()[0],
                    match.Groups["password"].Value
                ));
            }

            Console.WriteLine(Solver.Part1(entries));
            Console.WriteLine(Solver.Part2(entries));

            return 0;
        }
    }
}
