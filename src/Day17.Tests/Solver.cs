using System;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day17.Tests
{
    public class Solver
    {
        private Day17.PocketDimension _dimension = Day17.PocketDimension.FromString(@".#.
..#
###");

        [Fact]
        public void TestPart1()
        {
            Assert.Equal(112, Day17.Solver.Part1(_dimension));
        }

        [Fact]
        public void TestPart2()
        {
            Assert.Equal(848, Day17.Solver.Part2(_dimension));
        }
    }
}
