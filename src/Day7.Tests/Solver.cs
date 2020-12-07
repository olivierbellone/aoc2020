using System;
using System.Collections.Generic;
using Xunit;

[assembly: CLSCompliant(true)]

namespace Day7.Tests
{
    public class Solver
    {
        private readonly string _input1 = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

        private readonly string _input2 = @"shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.";

        [Fact]
        public void TestPart1()
        {
            Assert.Equal(4, Day7.Solver.Part1(BagRules.FromString(_input1)));
            Assert.Equal(0, Day7.Solver.Part1(BagRules.FromString(_input2)));
        }

        [Fact]
        public void TestPart2()
        {
            Assert.Equal(32, Day7.Solver.Part2(BagRules.FromString(_input1)));
            Assert.Equal(126, Day7.Solver.Part2(BagRules.FromString(_input2)));
        }
    }
}
