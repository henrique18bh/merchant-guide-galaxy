using MerchantGuideGalaxy.Constants;
using MerchantGuideGalaxy.Exception;
using System.Linq;
using System.Text.RegularExpressions;

namespace MerchantGuideGalaxy.Extensions
{
    public static class RomanNumeralsExtensionsMethods
    {
        public static int ConvertRomanNumeralsToInt(this string romanNumber, string romanRegex)
        {
            Match match = Regex.Match(romanNumber, romanRegex);
            if (!match.Success)
            {
                throw new InvalidNumberException();
            }
            int[] values = romanNumber.Select(GetSymbolValue).ToArray();
            int result = 0;

            for (int i = 0; i < values.Length; i++)
            {
                int currentValue = values[i];
                int nextValue = i + 1 < values.Length ? values[i + 1] : 0;
                result += CalculateRoman(currentValue, nextValue);
            }
            return result;
        }

        private static int CalculateRoman(int currentValue, int nextValue)
        {
            return nextValue > currentValue ? -currentValue : currentValue;
        }

        private static int GetSymbolValue(char romanNumeral)
        {
            switch (romanNumeral.ToString())
            {
                case RomanNumerals.I:
                    return 1;
                case RomanNumerals.V:
                    return 5;
                case RomanNumerals.X:
                    return 10;
                case RomanNumerals.L:
                    return 50;
                case RomanNumerals.C:
                    return 100;
                case RomanNumerals.D:
                    return 500;
                case RomanNumerals.M:
                    return 1000;
                default:
                    throw new InvalidNumberException();
            }
        }
    }
}
