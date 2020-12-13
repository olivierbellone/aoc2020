using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day13.Tests
{
    public class Solver
    {
        [Fact]
        public void TestPart1()
        {
            Assert.Equal(
                295,
                Day13.Solver.Part1(
                    939,
                    new List<string> { "7", "13", "x", "x", "59", "x", "31", "19" }
                )
            );
        }

        [Fact]
        public void TestPart2()
        {
            Assert.Equal(
                1068781,
                Day13.Solver.Part2(new List<string> { "7", "13", "x", "x", "59", "x", "31", "19" })
            );
            Assert.Equal(
                3417,
                Day13.Solver.Part2(new List<string> { "17", "x", "13", "19" })
            );
            Assert.Equal(
                754018,
                Day13.Solver.Part2(new List<string> { "67", "7", "59", "61" })
            );
            Assert.Equal(
                779210,
                Day13.Solver.Part2(new List<string> { "67", "x", "7", "59", "61" })
            );
            Assert.Equal(
                1261476,
                Day13.Solver.Part2(new List<string> { "67", "7", "x", "59", "61" })
            );
            Assert.Equal(
                1202161486,
                Day13.Solver.Part2(new List<string> { "1789", "37", "47", "1889" })
            );
        }
    }
}
