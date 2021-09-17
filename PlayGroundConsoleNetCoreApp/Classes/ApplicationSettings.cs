using System;

namespace PlayGroundConsoleNetCoreApp.Classes
{
    /// <summary>
    /// Discussion
    /// </summary>
    public sealed class ApplicationSettings
    {
        private static readonly Lazy<ApplicationSettings> Lazy = new(() 
            => new ApplicationSettings());

        /// <summary>
        /// Access point to methods and properties
        /// </summary>
        public static ApplicationSettings Instance => Lazy.Value;
        public char[] ChartArray { get; set; }
    }

}
