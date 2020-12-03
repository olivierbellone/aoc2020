using System;

namespace Day3
{
    public class Map
    {
        private readonly string[] _lines;
        private readonly int _height;
        private readonly int _width;

        public Map(string[] lines)
        {
            this._lines = lines ?? throw new ArgumentNullException(nameof(lines));
            this._height = lines.Length;
            this._width = lines[0].Length;
        }

        /// <summary>
        /// Counts the number of trees encountered for a given slope.
        /// </summary>
        public long CountTrees(int right, int down)
        {
            long trees = 0;

            int x = 0;
            for (int y = 0; y < this._height; y += down)
            {
                if (this._lines[y][x] == '#')
                {
                    trees += 1;
                }

                x += right;
                x %= this._width;
            }

            return trees;
        }
    }
}
