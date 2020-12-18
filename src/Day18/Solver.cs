using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day18
{
    public static class Solver
    {
        public static long Part1(IEnumerable<string> expressions)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException(nameof(expressions));
            }

            return expressions.Aggregate(0L, (acc, exp) => acc += Solve(exp, EvaluatePart1));
        }

        public static long Part2(IEnumerable<string> expressions)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException(nameof(expressions));
            }

            return expressions.Aggregate(0L, (acc, exp) => acc += Solve(exp, EvaluatePart2));
        }

        private static long Solve(string expression, Func<string, long> evaluator)
        {
            while (expression.Contains('(', StringComparison.InvariantCulture))
            {
                expression = Regex.Replace(
                    expression,
                    @"\([^\(\)]+\)",
                    m => evaluator(m.Groups[0].Value[1..(m.Groups[0].Value.Length - 1)]).ToString(CultureInfo.InvariantCulture)
                );
            }
            return evaluator(expression);
        }

        private static long EvaluatePart1(string expression)
        {
            string[] tokens = expression.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            long result = long.Parse(tokens[0], CultureInfo.InvariantCulture);

            int i = 1;
            while (i < tokens.Length)
            {
                if (tokens[i] == "+")
                {
                    i += 1;
                    result += long.Parse(tokens[i], CultureInfo.InvariantCulture);
                }
                else if (tokens[i] == "*")
                {
                    i += 1;
                    result *= long.Parse(tokens[i], CultureInfo.InvariantCulture);
                }
                i++;
            }
            return result;
        }

        private static long EvaluatePart2(string expression)
        {
            while (expression.Contains('+', StringComparison.InvariantCulture))
            {
                expression = Regex.Replace(
                    expression,
                    @"(\d+) \+ (\d+)",
                    m => (long.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture) + long.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture)
                );
            }
            return EvaluatePart1(expression);
        }
    }
}
