using System;

namespace Day11
{
    public static class Solver
    {
        public static long Part1(Plan plan)
        {
            if (plan == null)
            {
                throw new ArgumentNullException(nameof(plan));
            }

            while (plan.Changed)
            {
                plan.StepPart1();
            }
            return plan.OccupiedSeats;
        }

        public static long Part2(Plan plan)
        {
            if (plan == null)
            {
                throw new ArgumentNullException(nameof(plan));
            }

            while (plan.Changed)
            {
                plan.StepPart2();
            }
            return plan.OccupiedSeats;
        }
    }
}
