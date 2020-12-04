using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

[assembly: CLSCompliant(true)]

namespace Day4
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

            var passports = File.ReadAllText(filename).Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(str => Passport.FromString(str)).ToList();

            Console.WriteLine(Solver.Part1(passports));
            Console.WriteLine(Solver.Part2(passports));

            return 0;
        }
    }
}
