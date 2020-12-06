using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day6.Tests
{
    public class Solver
    {
        private readonly string _input = @"abc

a
b
c

ab
ac

a
a
a
a

b";

        [Fact]
        public void TestPart1()
        {
            Assert.Equal(11, Day6.Solver.Part1(_input));
        }

        [Fact]
        public void TestPart2()
        {
            Assert.Equal(6, Day6.Solver.Part2(_input));
        }
    }
}
