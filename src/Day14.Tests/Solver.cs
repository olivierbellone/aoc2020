using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day14.Tests
{
    public class Solver
    {
        [Fact]
        public void TestPart1()
        {
            string input = @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0";
            Assert.Equal(165, Day14.Solver.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            string input = @"mask = 000000000000000000000000000000X1001X
mem[42] = 100
mask = 00000000000000000000000000000000X0XX
mem[26] = 1";
            Assert.Equal(208, Day14.Solver.Part2(input));
        }
    }
}
