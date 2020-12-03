using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day3.Tests
{
    public class Solver
    {
        private readonly Day3.Map _map = new Day3.Map(new string[] {
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
            Assert.Equal(7, Day3.Solver.Part1(_map));
        }

        [Fact]
        public void TestPart2()
        {
            Assert.Equal(336, Day3.Solver.Part2(_map));
        }
    }
}
