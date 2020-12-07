using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public record Bag(string Color)
    {
        private IList<ContainedBagInfo> Children { get; } = new List<ContainedBagInfo>();

        public void AddContainedBagInfo(Bag child, long number)
        {
            this.Children.Add(new ContainedBagInfo(child, number));
        }

        /// <summary>
        /// Returns <c>true</c> if the bag can contain a bag of color <c>color</c>, either directly
        /// or because one of its contained bags can; otherwise, return <c>false</c>.
        /// </summary>
        public bool CanContain(string color)
        {
            return this.Children.Any((i) => i.Bag.Color == color || i.Bag.CanContain(color));
        }

        /// <summary>
        /// Returns the total number of bags contained in this bag, including this bag itself.
        /// </summary>
        public long ContainedBags()
        {
            return this.Children.Aggregate(
                1L,
                (acc, i) => acc += i.Number * i.Bag.ContainedBags()
            );
        }

        private record ContainedBagInfo(Bag Bag, long Number);
    }
}
