using System;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day12.Tests
{
    public class Solver
    {
        private readonly string _input = @"F10
N3
F7
R90
F11";

        [Fact]
        public void TestPart1()
        {
            Assert.Equal(25, Day12.Solver.Part1(_input));
        }

        [Fact]
        public void TestPart2()
        {
            Assert.Equal(286, Day12.Solver.Part2(_input));
        }
    }
}
