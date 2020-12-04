using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public static class Solver
    {
        public static long Part1(IList<Passport> passports)
        {
            if (passports == null)
            {
                throw new ArgumentNullException(nameof(passports));
            }

            return passports.Where((p) => p.AllRequiredFieldsPresent()).Count();
        }

        public static long Part2(IList<Passport> passports)
        {
            if (passports == null)
            {
                throw new ArgumentNullException(nameof(passports));
            }

            return passports.Where((p) => p.AllRequiredFieldsValid()).Count();
        }
    }
}
