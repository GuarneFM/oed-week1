using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGroundConsoleNetCoreApp.Classes
{
public static class StringExtensions
{
    public static string TrimLastCharacter(this string sender) 
        => string.IsNullOrWhiteSpace(sender) ? sender : sender.TrimEnd(sender[^1]);
    
    public static string RemoveAllWhiteSpace(this string sender) 
        => sender
            .ToCharArray().Where(character => !char.IsWhiteSpace(character))
            .Select(c => c.ToString()).Aggregate((value1, value2) => value1 + value2);
}
}
