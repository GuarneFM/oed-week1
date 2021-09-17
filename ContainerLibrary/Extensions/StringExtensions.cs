using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ContainerLibrary.Classes;

namespace ContainerLibrary.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether two specified String objects have the same value, case insensitive.
        /// </summary>
        /// <param name="first">The first string to compare, or null.</param>
        /// <param name="second">The second string to compare, or null.</param>
        /// <returns>
        /// true if the value of first is the same as the value of second; otherwise,
        /// false. If both first and second are null, the method returns true.
        /// </returns>
        public static bool EqualsIgnoreCase(this string first, string second) 
            => string.Equals(first, second, StringComparison.OrdinalIgnoreCase);
        
        /// <summary>
        /// Determine if string is empty
        /// </summary>
        /// <param name="sender">String to test if null or whitespace</param>
        /// <returns>true if empty or false if not empty</returns>
        [DebuggerStepThrough]
        public static bool IsNullOrWhiteSpace(this string sender) 
            => string.IsNullOrWhiteSpace(sender);

        /// <summary>
        /// Determine if a string can be represented as a numeric.
        /// </summary>
        /// <param name="sender">value to determine if can be converted to a string</param>
        /// <returns>true if sender can represent a number</returns>
        public static bool IsNumeric(this string sender) 
            => double.TryParse(sender, out _);

        /// <summary>
        /// Get value from a DataReader by column name, if value for column is DBNull then
        /// return the default value for the type
        ///
        /// e.g.
        /// bool is false
        /// char is '\0'
        /// 
        /// integral numeric types represent integer numbers is 0
        /// The floating-point numeric types represent real numbers is 0
        /// Reference types (object or string for instance) null
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        /// <remarks>
        /// Default values of C# types (C# reference)
        /// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/default-values
        /// </remarks>
        public static T GetValue<T>(this IDataReader sender, string columnName)
        {
            var value = sender[columnName];
            return value == DBNull.Value ? default : (T)value;
        }

        /// <summary>
        /// Provides strong type return for use in a Lambda statement to split a string
        /// into chars along with their respected indices.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>List&lt;CharIndexed&gt;</returns>
        public static List<CharIndexed> Indexed(this string sender)
            => sender.Select((@char, index) =>
                new CharIndexed { Char = @char, Index = index }).ToList();

        /// <summary>
        /// Used to remove last character from a string
        /// </summary>
        /// <param name="sender">string with at least one char</param>
        /// <returns></returns>
        public static string TrimLastCharacter(this string sender)
            => string.IsNullOrWhiteSpace(sender) ? sender : sender.TrimEnd(sender[^1]);

        /// <summary>
        /// Remove all white space in a string, at start, end and in-between
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static string RemoveAllWhiteSpace(this string sender)
            => sender
                .ToCharArray().Where(character => !char.IsWhiteSpace(character))
                .Select(c => c.ToString()).Aggregate((value1, value2) => value1 + value2);

        /// <summary>
        /// Split string by upper cased chars e.g. KarenAnnePayne becomes Karen Anne Payne
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static string SplitCamelCase(this string sender) 
            => Regex.Replace(Regex.Replace(sender, 
                "(\\P{Ll})(\\P{Ll}\\p{Ll})", "$1 $2"), 
                "(\\p{Ll})(\\P{Ll})", "$1 $2");

        public static string ReverseEx(this string sender)
        {
            char[] charArray = sender.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
