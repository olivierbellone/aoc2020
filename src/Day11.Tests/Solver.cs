using System;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day11.Tests
{
    public class Solver
    {
        private readonly string _input = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

        [Fact]
        public void TestPart1()
        {
            Assert.Equal(37, Day11.Solver.Part1(Plan.FromString(_input)));
        }

        [Fact]
        public void TestPart2()
        {
            Assert.Equal(26, Day11.Solver.Part2(Plan.FromString(_input)));
        }
    }
}
