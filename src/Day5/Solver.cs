using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    public static class Solver
    {
        public static long Part1(IList<Seat> seats)
        {
            if (seats == null)
            {
                throw new ArgumentNullException(nameof(seats));
            }

            return seats.Max(seat => seat.ID);
        }

        public static long Part2(IList<Seat> seats)
        {
            if (seats == null)
            {
                throw new ArgumentNullException(nameof(seats));
            }

            List<int> seatIDs = seats.Select(seat => seat.ID).ToList();

            int expectedSum = (seatIDs.Min() + seatIDs.Max()) * (seatIDs.Count + 1) / 2;
            int actualSum = seatIDs.Sum();

            return expectedSum - actualSum;
        }
    }
}
