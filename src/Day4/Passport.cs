using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    public record Passport(
        string birthYear,
        string issueYear,
        string expirationYear,
        string height,
        string hairColor,
        string eyeColor,
        string passportID,
        string countryID
    )
    {
        private static readonly Regex heightRegex = new Regex("^(?<num>\\d+)(?<unit>\\w+)$");

        private static readonly Regex hairColorRegex = new Regex("^#[0-9a-f]{6}$");

        private static readonly Regex passportIDRegex = new Regex("^[0-9]{9}$");

        private static readonly string[] validEyeColors = new string[] {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth",
        };

        public static Passport FromString(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            var fields = str.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.None)
                .Where(field => !string.IsNullOrEmpty(field.Trim()))
                .Select(field => field.Split(':', 2))
                .ToDictionary(
                    components => components[0],
                    components => components[1]
                );
            
            return new Passport(
                fields.ContainsKey("byr") ? fields["byr"] : null,
                fields.ContainsKey("iyr") ? fields["iyr"] : null,
                fields.ContainsKey("eyr") ? fields["eyr"] : null,
                fields.ContainsKey("hgt") ? fields["hgt"] : null,
                fields.ContainsKey("hcl") ? fields["hcl"] : null,
                fields.ContainsKey("ecl") ? fields["ecl"] : null,
                fields.ContainsKey("pid") ? fields["pid"] : null,
                fields.ContainsKey("cid") ? fields["cid"] : null
            );
        }

        public bool AllRequiredFieldsPresent()
        {
            return !string.IsNullOrEmpty(birthYear) &&
                !string.IsNullOrEmpty(issueYear) &&
                !string.IsNullOrEmpty(expirationYear) &&
                !string.IsNullOrEmpty(height) &&
                !string.IsNullOrEmpty(hairColor) &&
                !string.IsNullOrEmpty(eyeColor) &&
                !string.IsNullOrEmpty(passportID);
        }

        public bool AllRequiredFieldsValid()
        {
            return ValidBirthYear() &&
                ValidIssueYear() &&
                ValidExpirationYear() &&
                ValidHeight() &&
                ValidHairColor() &&
                ValidEyeColor() &&
                ValidPassportID();
        }

        public bool ValidBirthYear()
        {
            if (string.IsNullOrEmpty(birthYear))
            {
                return false;
            }

            int num = int.Parse(birthYear, CultureInfo.InvariantCulture);
            return num is >= 1920 and <= 2002;
        }

        public bool ValidIssueYear()
        {
            if (string.IsNullOrEmpty(issueYear))
            {
                return false;
            }

            int num = int.Parse(issueYear, CultureInfo.InvariantCulture);
            return num is >= 2010 and <= 2020;
        }

        public bool ValidExpirationYear()
        {
            if (string.IsNullOrEmpty(expirationYear))
            {
                return false;
            }

            int num = int.Parse(expirationYear, CultureInfo.InvariantCulture);
            return num is >= 2020 and <= 2030;
        }

        public bool ValidHeight()
        {
            if (string.IsNullOrEmpty(height))
            {
                return false;
            }

            Match match = heightRegex.Match(height);
            if (!match.Success)
            {
                return false;
            }

            int num = int.Parse(match.Groups["num"].Value, CultureInfo.InvariantCulture);
            return (match.Groups["unit"].Value) switch
            {
                "cm" => num is >= 150 and <= 193,
                "in" => num is >= 59 and <= 76,
                _ => false,
            };
        }

        public bool ValidHairColor()
        {
            if (string.IsNullOrEmpty(hairColor))
            {
                return false;
            }

            return hairColorRegex.Match(hairColor).Success;
        }

        public bool ValidEyeColor()
        {
            if (string.IsNullOrEmpty(eyeColor))
            {
                return false;
            }

            return validEyeColors.Contains(eyeColor);
        }

        public bool ValidPassportID()
        {
            if (string.IsNullOrEmpty(passportID))
            {
                return false;
            }

            return passportIDRegex.Match(passportID).Success;
        }
    }
}
