using System;

namespace Day12
{
    public static class Solver
    {
        public static long Part1(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var ship = new ShipPart1();
            ship.ProcessInput(input);
            return ship.Distance;
        }

        public static long Part2(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var ship = new ShipPart2();
            ship.ProcessInput(input);
            return ship.Distance;
        }
    }
}
