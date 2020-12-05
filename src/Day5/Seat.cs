using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day5
{
    public record Seat(int Row, int Column)
    {
        public static Seat FromString(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            if (str.Length != 10)
            {
                throw new ArgumentException("string must be exactly 10 characters", nameof(str));
            }

            string encodedRow = str.Substring(0, 7)
                .Replace("F", "0", StringComparison.InvariantCulture)
                .Replace("B", "1", StringComparison.InvariantCulture);
            int row = Convert.ToInt32(encodedRow, 2);

            string encodedColumn = str.Substring(7, 3)
                .Replace("L", "0", StringComparison.InvariantCulture)
                .Replace("R", "1", StringComparison.InvariantCulture);
            int column = Convert.ToInt32(encodedColumn, 2);

            return new Seat(row, column);
        }

        public int ID => (Row * 8 + Column);
    }
}
