using System;
using System.Globalization;
using System.IO;
using System.Linq;

[assembly: CLSCompliant(true)]

namespace Day15
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

            var numbers = File.ReadAllText(filename).Trim().Split(",").Select(x => int.Parse(x, CultureInfo.InvariantCulture)).ToList();

            Console.WriteLine(Solver.Part1(numbers.ToList()));
            Console.WriteLine(Solver.Part2(numbers.ToList()));

            return 0;
        }
    }
}
