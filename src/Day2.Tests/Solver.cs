using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day2.Tests
{
    public class Solver
    {
        [Fact]
        public void TestPart1()
        {
            var entries = new List<Day2.Entry> {
                new Day2.Entry(1, 3, 'a', "abcde"),
                new Day2.Entry(1, 3, 'b', "cdefg"),
                new Day2.Entry(2, 9, 'c', "ccccccccc"),
            };

            Assert.Equal(2, Day2.Solver.Part1(entries));
        }

        [Fact]
        public void TestPart2()
        {
            var entries = new List<Day2.Entry> {
                new Day2.Entry(1, 3, 'a', "abcde"),
                new Day2.Entry(1, 3, 'b', "cdefg"),
                new Day2.Entry(2, 9, 'c', "ccccccccc"),
            };

            Assert.Equal(1, Day2.Solver.Part2(entries));
        }
    }
}
