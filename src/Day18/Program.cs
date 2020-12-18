using System;
using System.Collections.Generic;
using System.IO;

[assembly: CLSCompliant(true)]

namespace Day18
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

            IEnumerable<string> expressions = File.ReadLines(filename);

            Console.WriteLine(Solver.Part1(expressions));
            Console.WriteLine(Solver.Part2(expressions));

            return 0;
        }
    }
}
