using System;
using System.Collections.Generic;
using System.IO;

[assembly: CLSCompliant(true)]

namespace Day19
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

            string[] parts = File.ReadAllText(filename).Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
            var ruleSet = RuleSet.FromString(parts[0]);
            string[] messages = parts[1].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(Solver.Part1(ruleSet, messages));
            Console.WriteLine(Solver.Part2(ruleSet, messages));

            return 0;
        }
    }
}
