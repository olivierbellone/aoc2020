﻿using System;
using System.IO;

[assembly: CLSCompliant(true)]

namespace Day17
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

            var dimension = PocketDimension.FromString(File.ReadAllText(filename));

            Console.WriteLine(Solver.Part1(dimension));
            Console.WriteLine(Solver.Part2(dimension));

            return 0;
        }
    }
}
