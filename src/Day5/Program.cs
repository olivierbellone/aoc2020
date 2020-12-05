using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

[assembly: CLSCompliant(true)]

namespace Day5
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

            var seats = new List<Seat>();
            foreach (string line in File.ReadAllLines(filename))
            {
                seats.Add(Seat.FromString(line));
            }

            Console.WriteLine(Solver.Part1(seats));
            Console.WriteLine(Solver.Part2(seats));

            return 0;
        }
    }
}
