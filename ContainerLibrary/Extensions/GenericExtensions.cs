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
        public static bool IsNull<T>(this T senderInstance) where T : new() => senderInstance is null;

        /// <summary>
        /// Is the instance of a class not null
        /// </summary>
        /// <typeparam name="T">Concrete class type</typeparam>
        /// <param name="senderInstance">Instance of concrete class</param>
        /// <returns>True if not null, false if null</returns>
        public static bool IsNotNull<T>(this T senderInstance) where T : new() => !senderInstance.IsNull();

        public static bool Between<T>(this T value, T lowerValue, T upperValue) where T : struct, IComparable<T> =>
            Comparer<T>.Default.Compare(value, lowerValue) >= 0 && Comparer<T>.Default.Compare(value, upperValue) <= 0;

    }
}
