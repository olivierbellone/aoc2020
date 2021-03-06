﻿using System;
using System.IO;

[assembly: CLSCompliant(true)]

namespace Day7
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

            BagRules rules = BagRules.FromString(File.ReadAllText(filename));

            Console.WriteLine(Solver.Part1(rules));
            Console.WriteLine(Solver.Part2(rules));

            return 0;
        }
    }
}
