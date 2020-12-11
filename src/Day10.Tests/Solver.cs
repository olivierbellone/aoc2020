using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day10.Tests
{
    public class Solver
    {
        private readonly IList<long> _input1 = new List<long> {
            16,
            10,
            15,
            5,
            1,
            11,
            7,
            19,
            6,
            12,
            4,
        };

        private readonly IList<long> _input2 = new List<long> {
            28,
            33,
            18,
            42,
            31,
            14,
            46,
            20,
            48,
            47,
            24,
            23,
            49,
            45,
            19,
            38,
            39,
            11,
            1,
            32,
            25,
            35,
            8,
            17,
            7,
            9,
            4,
            2,
            34,
            10,
            3,
        };

        [Fact]
        public void TestPart1()
        {
            Assert.Equal(35, Day10.Solver.Part1(_input1));
            Assert.Equal(220, Day10.Solver.Part1(_input2));
        }

        [Fact]
        public void TestPart2()
        {
            Assert.Equal(8, Day10.Solver.Part2(_input1));
            Assert.Equal(19208, Day10.Solver.Part2(_input2));
        }
    }
}
