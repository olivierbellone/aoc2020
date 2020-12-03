using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day3.Tests
{
    public class Solver
    {
        Day3.Map map = new Day3.Map(new string[] {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#",
        });

        [Fact]
        public void TestPart1()
        {
            Assert.Equal(7, Day3.Solver.Part1(map));
        }

        [Fact]
        public void TestPart2()
        {
            Assert.Equal(336, Day3.Solver.Part2(map));
        }
    }
}
