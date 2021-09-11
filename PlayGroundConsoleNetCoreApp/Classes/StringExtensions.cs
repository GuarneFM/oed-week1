using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGroundConsoleNetCoreApp.Classes
{
    public static class StringExtensions
    {


        /// <summary>
        /// Determines whether two specified String objects have the same value, case insensitive.
        /// </summary>
        /// <param name="first">The first string to compare, or null.</param>
        /// <param name="second">The second string to compare, or null.</param>
        /// <returns>true if the value of first is the same as the value of second; otherwise, false. If both first and second are null, the method returns true.</returns>
        public static bool EqualsIgnoreCase(this string first, string second) =>
            string.Equals(first, second, StringComparison.OrdinalIgnoreCase);
    }
}
