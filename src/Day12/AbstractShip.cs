using System;
using System.Globalization;

namespace Day12
{
    public abstract class AbstractShip
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public int Distance => Math.Abs(X) + Math.Abs(Y);

        public void ProcessInput(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            foreach (string line in input.Split("\n", StringSplitOptions.RemoveEmptyEntries))
            {
                ProcessAction(
                    line[0].ToString(),
                    int.Parse(line[1..], CultureInfo.InvariantCulture)
                );
            }
        }

        public abstract void ProcessAction(string action, int value);
    }
}
