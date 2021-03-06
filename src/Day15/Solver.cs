using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    public static class Solver
    {
        public static int Part1(IList<int> numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            return FindNumberAtTurn(numbers, 2020);
        }

        public static int Part2(IList<int> numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            return FindNumberAtTurn(numbers, 30000000);
        }

        private static int FindNumberAtTurn(IList<int> numbers, int turn)
        {
            IDictionary<int, (int, int)> numberToTurns = numbers
                .Select((numbers, idx) => (numbers, idx))
                .ToDictionary(t => t.Item1, t => (-1, t.Item2));

            foreach (int currentTurn in Enumerable.Range(numbers.Count, turn - numbers.Count))
            {
                int lastNumber = numbers.Last();
                (int secondLastTurn, int lastTurn) = numberToTurns[lastNumber];

                int number = secondLastTurn != -1 ? lastTurn - secondLastTurn : 0;

                if (!numberToTurns.ContainsKey(number))
                {
                    numberToTurns[number] = (-1, currentTurn);
                }
                else
                {
                    numberToTurns[number] = (numberToTurns[number].Item2, currentTurn);
                }
                numbers.Add(number);
            }

            return numbers.Last();
        }
    }
}
