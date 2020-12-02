using System;
using System.Linq;

namespace Day2
{
    public record Entry(int min, int max, char letter, string password)
    {
        /// <summary>
        /// Indicates whether the password is valid according to the policy of the Sled Rental
        /// Place Down The Street.
        /// </summary>
        public bool ValidSRPDTS()
        {
            int count = this.password.Where(x => x.Equals(this.letter)).Count();
            return (count >= this.min && count <= this.max);
        }

        /// <summary>
        /// Indicates whether the password is valid according to the Official Toboggan Corporate
        /// Policy.
        /// </summary>
        public bool ValidOTCA()
        {
            return this.password[min - 1] == this.letter ^ this.password[max - 1] == this.letter;
        }
    }
}
