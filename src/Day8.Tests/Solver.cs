using System;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day8.Tests
{
    public class Solver
    {
        private readonly string _input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";


        [Fact]
        public void TestPart1()
        {
            Assert.Equal(5, Day8.Solver.Part1(BootProgram.FromString(_input)));
        }

        [Fact]
        public void TestPart2()
        {
            Assert.Equal(8, Day8.Solver.Part2(BootProgram.FromString(_input)));
        }
    }
}
