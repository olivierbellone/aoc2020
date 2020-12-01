using System;

namespace Day1
{
    public static class Solver
    {
        public static bool TryPart1(int[] entries, out int result)
        {
            if (entries == null)
            {
                throw new ArgumentNullException(nameof(entries));
            }
            if (entries.Length < 2)
            {
                throw new ArgumentException("Array must have at least 2 elements.");
            }

            for (int x = 0; x < entries.Length - 1; x++)
            {
                for (int y = x + 1; y < entries.Length; y++)
                {
                    int sum = entries[x] + entries[y];
                    if (sum == 2020)
                    {
                        result = entries[x] * entries[y];
                        return true;
                    }
                }
            }

            result = -1;
            return false;
        }

        public static bool TryPart2(int[] entries, out int result)
        {
            if (entries == null)
            {
                throw new ArgumentNullException(nameof(entries));
            }
            if (entries.Length < 3)
            {
                throw new ArgumentException("Array must have at least 3 elements.");
            }

            for (int x = 0; x < entries.Length - 2; x++)
            {
                for (int y = x + 1; y < entries.Length - 1; y++)
                {
                    for (int z = y + 1; z < entries.Length; z++)
                    {
                        int sum = entries[x] + entries[y] + entries[z];
                        if (sum == 2020)
                        {
                            result = entries[x] * entries[y] * entries[z];
                            return true;
                        }
                    }
                }
            }

            result = -1;
            return false;
        }
    }
}
