using System;
using System.IO;
using System.Linq;

[assembly: CLSCompliant(true)]

namespace Day1
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

            int[] entries = File.ReadLines(filename).Select(int.Parse).ToArray();
            
            if (Solver.TryPart1(entries, out int result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.Error.WriteLine("No solution found for part 1");
                return 1;
            }

            if (Solver.TryPart2(entries, out result))
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
