using System;
using System.Globalization;
using System.Linq;

namespace NextBiggerTask
{
    public static class NumberExtension
    {
        /// <summary>
        /// Finds the nearest largest integer consisting of the digits of the given positive integer number and null if no such number exists.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        /// The nearest largest integer consisting of the digits  of the given positive integer and null if no such number exists.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when source number is less than 0.</exception>
        public static int? NextBiggerThan(int number)
        {
            if (number < 0 || number == int.MinValue)
            {
                throw new ArgumentException("source number is less than 0", nameof(number));
            }
            else if (number == int.MaxValue)
            {
                return null;
            }

            var dig = number.ToString(CultureInfo.InvariantCulture).ToCharArray();
            for (int i = dig.Length - 1; i > 0; i--)
            {
                if (dig[i - 1] < dig[i])
                {
                    char temp = dig[i - 1];
                    dig[i - 1] = dig[i];
                    dig[i] = temp;
                    
                    for (int j = i; j < dig.Length; j++)
                    {
                        for (int k = j + 1; k < dig.Length; k++)
                        {
                            if (dig[j] > dig[k])
                            {
                                char t = dig[j];
                                dig[j] = dig[k];
                                dig[k] = t;
                            }
                        }
                    }

                    return int.Parse(dig);
                }
            }
            
            return null;
        }
    }
}
