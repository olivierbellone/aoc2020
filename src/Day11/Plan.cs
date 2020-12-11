using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Day11
{
    public class Plan
    {
        public int Height { get; }
        public int Width { get; }
        public bool Changed { get; private set; }

        private char[][] _seats;

        public Plan(int height, int width, char[][] seats)
        {
            Height = height;
            Width = width;
            Changed = true;
            _seats = seats;
        }

        public static Plan FromString(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            string[] lines = input.Split("\n", System.StringSplitOptions.RemoveEmptyEntries);
            int height = lines.Length;
            int width = lines[0].Length;

            return new Plan(
                height,
                width,
                lines.Select(line => line.ToCharArray()).ToArray()
            );
        }

        public int OccupiedSeats => _seats.SelectMany(line => line.Where(c => c == '#')).Count();

        public void StepPart1()
        {
            StepInternal(AdjacentOccupiedSeats, 4);
        }

        public void StepPart2()
        {
            StepInternal(VisibleOccupiedSeats, 5);
        }

        private void StepInternal(Func<int, int, int> occupiedSeatsFunc, int threshold)
        {
            char[][] newSeats = _seats.Select(line => line.ToArray()).ToArray();

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    int occupied = occupiedSeatsFunc(row, col);
                    if ((_seats[row][col] == 'L') && (occupied == 0))
                    {
                        newSeats[row][col] = '#';
                    }
                    if ((_seats[row][col] == '#') && (occupied >= threshold))
                    {
                        newSeats[row][col] = 'L';
                    }
                }
            }

            Changed = !Enumerable.Range(0, Height).All(row => _seats[row].SequenceEqual(newSeats[row]));
            _seats = newSeats;
        }

        private int AdjacentOccupiedSeats(int row, int col)
        {
            int result = 0;
            foreach (int incRow in Enumerable.Range(-1, 3))
            {
                foreach (int incCol in Enumerable.Range(-1, 3))
                {
                    if ((incRow == 0) && (incCol == 0))
                    {
                        continue;
                    }
                    int y = row + incRow;
                    int x = col + incCol;
                    if (x < 0 || x >= Width || y < 0 || y >= Height)
                    {
                        continue;
                    }

                    if (_seats[y][x] == '#')
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private int VisibleOccupiedSeats(int row, int col)
        {
            int result = 0;

            foreach (int incRow in Enumerable.Range(-1, 3))
            {
                foreach (int incCol in Enumerable.Range(-1, 3))
                {
                    if ((incRow == 0) && (incCol == 0))
                    {
                        continue;
                    }

                    int y = row;
                    int x = col;
                    while (true)
                    {
                        y += incRow;
                        x += incCol;
                        if (x < 0 || x >= Width || y < 0 || y >= Height)
                        {
                            break;
                        }
                        if (_seats[y][x] == 'L')
                        {
                            break;
                        }
                        if (_seats[y][x] == '#')
                        {
                            result++;
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
