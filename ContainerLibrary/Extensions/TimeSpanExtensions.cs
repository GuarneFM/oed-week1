using System;

namespace ContainerLibrary.Extensions
{
public static class TimeSpanExtensions
{
    /// <summary>
    /// Conditionally format TimeSpan dependent on if there are days, hours, minutes.
    /// Does not handle years and milliseconds
    /// </summary>
    /// <param name="span"><see cref="TimeSpan"/> from two dates</param>
    /// <returns>Formatted string</returns>
    public static string FormatElapsed(this TimeSpan span) => span.Days switch
    {
        > 0 => $"{span.Days} days, {span.Hours} hours, {span.Minutes} minutes, {span.Seconds} seconds",
        _ => span.Hours switch
        {
            > 0 => $"{span.Hours} hours, {span.Minutes} minutes, {span.Seconds} seconds",
            _ => span.Minutes switch
            {
                > 0 => $"{span.Minutes} minutes, {span.Seconds} seconds",
                _ => span.Seconds switch
                {
                    > 0 => $"{span.Seconds} seconds",
                    _ => ""
                }
            }
        }
    };
}
}

