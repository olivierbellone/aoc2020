using System;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day1.Tests
{
    public class Solver
    {
        [Fact]
        public void TestTryPart1()
        {
            int[] entries = new int[] { 1721, 979, 366, 299, 675, 1456 };

            Assert.True(Day1.Solver.TryPart1(entries, out int result));
            Assert.Equal(514579, result);
        }

        [Fact]
        public void TestTryPart2()
        {
            int[] entries = new int[] { 1721, 979, 366, 299, 675, 1456 };

            Assert.True(Day1.Solver.TryPart2(entries, out int result));
            Assert.Equal(241861950, result);
        }
    }
}
