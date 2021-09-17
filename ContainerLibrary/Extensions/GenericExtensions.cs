using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerLibrary.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Is the instance of a class null
        /// </summary>
        /// <typeparam name="T">Concrete class type</typeparam>
        /// <param name="senderInstance">Instance of concrete class</param>
        /// <returns>True if null, false if not null</returns>
        public static bool IsNull<T>(this T senderInstance) where T : new() 
            => senderInstance is null;

        /// <summary>
        /// Is the instance of a class not null
        /// </summary>
        /// <typeparam name="T">Concrete class type</typeparam>
        /// <param name="senderInstance">Instance of concrete class</param>
        /// <returns>True if not null, false if null</returns>
        public static bool IsNotNull<T>(this T senderInstance) where T : new() 
            => !senderInstance.IsNull();

        /// <summary>
        /// Provides a generic method to determine if data is between lower and upper range
        /// </summary>
        /// <typeparam name="T">Type e.g. DateTime, int etc</typeparam>
        /// <param name="value">Data to assert</param>
        /// <param name="lowerValue">Lower range</param>
        /// <param name="upperValue">Upper range</param>
        /// <returns></returns>
        public static bool Between<T>(this T value, T lowerValue, T upperValue) where T : struct, IComparable<T> 
            => Comparer<T>.Default.Compare(value, lowerValue) >= 0 && Comparer<T>.Default.Compare(value, upperValue) <= 0;

        /// <summary>
        /// Determine if T is less than maximumValue 
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="sender">Value to test</param>
        /// <param name="maximumValue">Max value</param>
        /// <returns></returns>
        public static bool LessThan<T>(this IComparable<T> sender, T maximumValue) 
            => sender.CompareTo(maximumValue) <= 0;

        /// <summary>
        /// Provides a IN like condition generic method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool InCondition<T>(this T sender, params T[] values) 
            => values.Contains(sender);

        public static List<T> GetRange<T>(this List<T> list, Range range)
        {
            /*
             * Named value Tuple
             */
            (int start, int length) = range.GetOffsetAndLength(list.Count);
            return list.GetRange(start, length);
        }

    }
}
