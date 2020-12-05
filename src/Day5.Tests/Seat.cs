using System;
using Xunit;

namespace Day5.Tests
{
    public class Seat
    {
        [Fact]
        public void TestFromString()
        {
            var seat = Day5.Seat.FromString("FBFBBFFRLR");
            Assert.Equal(44, seat.Row);
            Assert.Equal(5, seat.Column);

            seat = Day5.Seat.FromString("BFFFBBFRRR");
            Assert.Equal(70, seat.Row);
            Assert.Equal(7, seat.Column);

            seat = Day5.Seat.FromString("FFFBBBFRRR");
            Assert.Equal(14, seat.Row);
            Assert.Equal(7, seat.Column);

            seat = Day5.Seat.FromString("BBFFBBFRLL");
            Assert.Equal(102, seat.Row);
            Assert.Equal(4, seat.Column);
        }
        [Fact]
        public void TestID()
        {
            var seat = new Day5.Seat(44, 5);
            Assert.Equal(357, seat.ID);

            seat = new Day5.Seat(70, 7);
            Assert.Equal(567, seat.ID);

            seat = new Day5.Seat(14, 7);
            Assert.Equal(119, seat.ID);

            seat = new Day5.Seat(102, 4);
            Assert.Equal(820, seat.ID);
        }
    }
}
