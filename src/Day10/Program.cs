using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;

[assembly: CLSCompliant(true)]

namespace Day10
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

            Console.WriteLine(Solver.Part1(numbers));
            Console.WriteLine(Solver.Part2(numbers));

            return 0;
        }
    }
}
