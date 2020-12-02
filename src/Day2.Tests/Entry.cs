using System;
using Xunit;

namespace Day2.Tests
{
    public class Entry
    {
        [Fact]
        public void ValidSRPDTS()
        {
            Assert.True(new Day2.Entry(1, 3, 'a', "abcde").ValidSRPDTS());
            Assert.False(new Day2.Entry(1, 3, 'b', "cdefg").ValidSRPDTS());
            Assert.True(new Day2.Entry(2, 9, 'c', "ccccccccc").ValidSRPDTS());
        }

        [Fact]
        public void ValidOTCA()
        {
            Assert.True(new Day2.Entry(1, 3, 'a', "abcde").ValidOTCA());
            Assert.False(new Day2.Entry(1, 3, 'b', "cdefg").ValidOTCA());
            Assert.False(new Day2.Entry(2, 9, 'c', "ccccccccc").ValidOTCA());
        }
    }
}
