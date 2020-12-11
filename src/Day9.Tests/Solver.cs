using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day9.Tests
{
    public class Solver
    {
        private readonly IList<long> _numbers = new List<long> {
            35,
            20,
            15,
            25,
            47,
            40,
            62,
            55,
            65,
            95,
            102,
            117,
            150,
            182,
            127,
            219,
            299,
            277,
            309,
            576,
        };


        [Fact]
        public void TestPart1()
        {
            Assert.True(Day9.Solver.TryPart1(_numbers, out long result, preambleLength: 5));
            Assert.Equal(127, result);
        }

        [Fact]
        public void TestPart2()
        {
            Assert.True(Day9.Solver.TryPart2(_numbers, out long result, preambleLength: 5));
            Assert.Equal(62, result);
        }
    }
}
