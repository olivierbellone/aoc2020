using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day5.Tests
{
    public class Solver
    {
        [Fact]
        public void TestPart1()
        {
            var seats = new List<Day5.Seat> {
                Day5.Seat.FromString("FBFBBFFRLR"),
                Day5.Seat.FromString("BFFFBBFRRR"),
                Day5.Seat.FromString("FFFBBBFRRR"),
                Day5.Seat.FromString("BBFFBBFRLL"),
            };
            Assert.Equal(820, Day5.Solver.Part1(seats));
        }

        [Fact]
        public void TestPart2()
        {
            var seats = new List<Day5.Seat> {
                new Day5.Seat(1, 1),
                new Day5.Seat(1, 2),
                new Day5.Seat(1, 3),
                // Missing seat is (1, 4)
                new Day5.Seat(1, 5),
                new Day5.Seat(1, 6),
            };
            // 12 = 1*8 + 4
            Assert.Equal(12, Day5.Solver.Part2(seats));
        }
    }
}
