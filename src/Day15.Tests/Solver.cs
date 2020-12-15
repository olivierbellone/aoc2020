using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day15.Tests
{
    public class Solver
    {
        [Fact]
        public void TestPart1()
        {
            Assert.Equal(436, Day15.Solver.Part1(new List<int> { 0, 3, 6 }));
        }

        [Fact]
        public void TestPart2()
        {
            Assert.Equal(175594, Day15.Solver.Part2(new List<int> { 0, 3, 6 }));
            Assert.Equal(2578, Day15.Solver.Part2(new List<int> { 1, 3, 2 }));
            Assert.Equal(3544142, Day15.Solver.Part2(new List<int> { 2, 1, 3 }));
            Assert.Equal(261214, Day15.Solver.Part2(new List<int> { 1, 2, 3 }));
            Assert.Equal(6895259, Day15.Solver.Part2(new List<int> { 2, 3, 1 }));
            Assert.Equal(18, Day15.Solver.Part2(new List<int> { 3, 2, 1 }));
            Assert.Equal(362, Day15.Solver.Part2(new List<int> { 3, 1, 2 }));
        }
    }
}
