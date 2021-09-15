using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace ActiveDirectoryDemo
{
    static class Extensions
    {
        [DebuggerStepThrough]
        public static bool IsNullOrWhiteSpace(this string sender) => string.IsNullOrWhiteSpace(sender);
        [DebuggerStepThrough]
        public static string ToTitleCase(this string sender) => sender.IsNullOrWhiteSpace() ? sender : CultureInfo.InvariantCulture.TextInfo.ToTitleCase(sender.ToLower());
    }
}