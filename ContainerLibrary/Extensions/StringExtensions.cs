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
        /// Determine if string is empty
        /// </summary>
        /// <param name="sender">String to test if null or whitespace</param>
        /// <returns>true if empty or false if not empty</returns>
        [DebuggerStepThrough]
        public static bool IsNullOrWhiteSpace(this string sender) => string.IsNullOrWhiteSpace(sender);
        /// <summary>
        /// Determine if a string can be represented as a numeric.
        /// </summary>
        /// <param name="text">value to determine if can be converted to a string</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool IsNumeric(this string text) => double.TryParse(text, out _);

        public static T GetValue<T>(this IDataReader sender, string columnName)
        {
            var value = sender[columnName];
            return value == DBNull.Value ? default : (T)value;
        }
        public static List<CharIndexed> Indexed(this string sender)
            => sender.Select((@char, index) =>
                new CharIndexed { Char = @char, Index = index }).ToList();

        public static string TrimLastCharacter(this string sender)
            => string.IsNullOrWhiteSpace(sender) ? sender : sender.TrimEnd(sender[^1]);

        public static string RemoveAllWhiteSpace(this string sender)
            => sender
                .ToCharArray().Where(character => !char.IsWhiteSpace(character))
                .Select(c => c.ToString()).Aggregate((value1, value2) => value1 + value2);

        public static string SplitCamelCase(this string sender) 
            => Regex.Replace(Regex.Replace(sender, 
                "(\\P{Ll})(\\P{Ll}\\p{Ll})", "$1 $2"), 
                "(\\p{Ll})(\\P{Ll})", "$1 $2");
    }
}
