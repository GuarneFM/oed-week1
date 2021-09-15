using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerLibrary.Extensions
{
    public static class GeneralExtensions
    {
        /// <summary>
        /// Produces an array where the first element is startValue, last element is endValue with all values between both case insensitive.
        /// </summary>
        /// <param name="sender">List of <see cref="string"/></param>
        /// <param name="startValue">first element to start the range</param>
        /// <param name="endValue">last element to end the range</param>
        /// <returns>range between startValue and endValue or null if neither start or end values do not exist in sender array</returns>
        public static List<string> BetweenElements(this List<string> sender, string startValue, string endValue)
        {

            var startIndex = sender.FindIndex(element =>
                element.Equals(
                    startValue,
                    StringComparison.OrdinalIgnoreCase));

            var endIndex = sender.FindIndex(element =>
                element.Equals(
                    endValue,
                    StringComparison.OrdinalIgnoreCase)) - startIndex + 1;

            return startIndex == -1 || endIndex == -1 ? null : sender.GetRange(startIndex, endIndex);

        }
        /// <summary>
        /// Produces an array where the first element is startValue, last element is endValue with all values between both.
        /// </summary>
        /// <param name="sender">List of <see cref="int"/></param>
        /// <param name="startValue">first element to start the range</param>
        /// <param name="endValue">last element to end the range</param>
        /// <returns>range between startValue and endValue or null if neither start or end values do not exist in sender array</returns>
        public static List<int> BetweenElements(this List<int> sender, int startValue, int endValue)
        {

            var startIndex = sender.FindIndex(element =>
                element.Equals(startValue));

            var endIndex = sender.FindIndex(element =>
                element.Equals(endValue)) - startIndex + 1;

            return startIndex == -1 || endIndex == -1 ?
                null :
                sender.GetRange(startIndex, endIndex);
        }


        public static List<DateTime> BetweenDates(this List<DateTime> sender, DateTime startValue, DateTime endValue)
        {

            var startIndex = sender.FindIndex(element =>
                element.Date.Equals(startValue.Date));

            var endIndex = sender.FindIndex(element =>
                element.Date.Equals(endValue.Date)) - startIndex + 1;

            return startIndex == -1 || endIndex == -1 ?
                null :
                sender.GetRange(startIndex, endIndex);
        }

        #region Historical 

        /// <summary>
        /// Concat two arrays of the same type (not needed)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        /// <remarks>
        /// At one time this was not part of the .NET Framework, now it is.
        /// </remarks>
        public static T[] Concat<T>(this T[] first, T[] second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            List<T> list = new List<T>(first.Length + second.Length);
            list.AddRange(first);
            list.AddRange(second);

            return list.ToArray();
        }

        #endregion
    }
}

