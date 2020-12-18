using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day18.Tests
{
    public class Solver
    {
        [Fact]
        public void TestPart1()
        {
            Assert.Equal(71, Day18.Solver.Part1(new List<string> { "1 + 2 * 3 + 4 * 5 + 6" }));
            Assert.Equal(51, Day18.Solver.Part1(new List<string> { "1 + (2 * 3) + (4 * (5 + 6))" }));
            Assert.Equal(26, Day18.Solver.Part1(new List<string> { "2 * 3 + (4 * 5)" }));
            Assert.Equal(437, Day18.Solver.Part1(new List<string> { "5 + (8 * 3 + 9 + 3 * 4 * 3)" }));
            Assert.Equal(12240, Day18.Solver.Part1(new List<string> { "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))" }));
            Assert.Equal(13632, Day18.Solver.Part1(new List<string> { "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2" }));
        }

        [Fact]
        public void TestPart2()
        {
            Assert.Equal(231, Day18.Solver.Part2(new List<string> { "1 + 2 * 3 + 4 * 5 + 6" }));
            Assert.Equal(51, Day18.Solver.Part2(new List<string> { "1 + (2 * 3) + (4 * (5 + 6))" }));
            Assert.Equal(46, Day18.Solver.Part2(new List<string> { "2 * 3 + (4 * 5)" }));
            Assert.Equal(1445, Day18.Solver.Part2(new List<string> { "5 + (8 * 3 + 9 + 3 * 4 * 3)" }));
            Assert.Equal(669060, Day18.Solver.Part2(new List<string> { "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))" }));
            Assert.Equal(23340, Day18.Solver.Part2(new List<string> { "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2" }));
        }
    }
}
