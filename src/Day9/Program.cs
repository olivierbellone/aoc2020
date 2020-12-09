using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;

[assembly: CLSCompliant(true)]

namespace Day9
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

            List<long> numbers = File.ReadAllLines(filename)
                .Select(line => long.Parse(line, CultureInfo.InvariantCulture))
                .ToList();

            if (Solver.TryPart1(numbers, out long result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.Error.WriteLine("No solution found for part 1");
                return 1;
            }

            if (Solver.TryPart2(numbers, out result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.Error.WriteLine("No solution found for part 2");
                return 2;
            }

            return 0;
        }
    }
}
