using System;

namespace Day17
{
    public static class Solver
    {
        public static long Part1(PocketDimension dimension)
        {
            if (dimension == null)
            {
                throw new ArgumentNullException(nameof(dimension));
            }

            dimension = dimension.Clone();
            dimension.Step(6);
            return dimension.ActiveCubes;
        }

        public static long Part2(PocketDimension dimension)
        {
            if (dimension == null)
            {
                throw new ArgumentNullException(nameof(dimension));
            }

            dimension = dimension.Clone();
            dimension.Hyper = true;
            dimension.Step(6);
            return dimension.ActiveCubes;
        }
    }
}
