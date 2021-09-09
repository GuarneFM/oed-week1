using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerLibrary.Extensions
{
    public static class NumericExtensions
    {
        /// <summary>
        /// Determine if sender is even
        /// </summary>
        /// <param name="sender">Int to work against</param>
        /// <returns>True if even, false if odd</returns>
        public static bool IsEven(this int sender) => sender % 2 == 0;

        /// <summary>
        /// Determine if sender is odd
        /// </summary>
        /// <param name="sender">Int to work against</param>
        /// <returns>True if odd, false if even</returns>
        public static bool IsOdd(this int sender) => !IsEven(sender);

        public static (int major, decimal fraction) GetParts(this double sender)
        {
            decimal fraction = (decimal)sender;
            int majorPart = (int)fraction;
            decimal decimalPart = fraction % 1.0m;

            return (majorPart, decimalPart);
        }

        public static int GetMajor(this decimal sender) 
            => (int)sender;
    }
}
