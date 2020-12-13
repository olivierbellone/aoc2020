using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

[assembly: CLSCompliant(true)]

namespace Day13
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

            var lines = File.ReadAllLines(filename);
            var timestamp = long.Parse(lines[0], CultureInfo.InvariantCulture);
            IList<string> ids = lines[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(Solver.Part1(timestamp, ids));
            Console.WriteLine(Solver.Part2(ids));

            return 0;
        }
    }
}
