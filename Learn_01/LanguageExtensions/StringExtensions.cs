using System;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace Learn_01.LanguageExtensions
{
    /// <summary>
    /// Common string extensions 
    /// </summary>
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

        public static char LastChar(this string sender) => sender[^1];
        public static char FileNameLastChar(this string file) => Path.GetFileNameWithoutExtension(file)[^1];
        public static bool FileNameLastCharIsDigit(this string file) => char.IsDigit(file.FileNameLastChar());

    }
}
