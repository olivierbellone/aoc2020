using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day16.Tests
{
    public class Solver
    {
        [Fact]
        public void TestPart1()
        {
            var input = Day16.Input.FromString(@"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12");
            Assert.Equal(71, Day16.Solver.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
        }
    }
}
