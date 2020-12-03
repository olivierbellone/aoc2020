using System;
using Xunit;

namespace Day3.Tests
{
    public class Map
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
        public void CountTrees()
        {
            Assert.Equal(2, _map.CountTrees(1, 1));
            Assert.Equal(7, _map.CountTrees(3, 1));
            Assert.Equal(3, _map.CountTrees(5, 1));
            Assert.Equal(4, _map.CountTrees(7, 1));
            Assert.Equal(2, _map.CountTrees(1, 2));
        }
    }
}
