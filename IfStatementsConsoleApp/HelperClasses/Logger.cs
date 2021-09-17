using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace IfStatementsConsoleApp.HelperClasses
{
    /// <summary>
    /// Base example for writing information to a log file, in this case since the file name applicationLog.txt
    /// has no path it's generated in the application folder.
    ///
    /// Recommendation
    ///     When creating a class such as this that is general purpose place into a separate class project.
    /// </summary>
    public static class Logger
    {
        private static TextWriterTraceListener _textWriterTraceListener;

        public static void CreateLog()
        {
            _textWriterTraceListener = new TextWriterTraceListener(
                "applicationLog.txt",
                "PayneListener");

            Trace.Listeners.Add(_textWriterTraceListener);
        }

        public static void Close()
        {
            _textWriterTraceListener.Flush();
        }

        public static void Exception(string message, [CallerMemberName] string callerName = null) 
            => WriteEntry(message, "error", callerName);

        public static void Exception(Exception exception, [CallerMemberName] string callerName = null) 
            => WriteEntry(exception.Message, "error", callerName);

        public static void Warning(string message, [CallerMemberName] string callerName = null) 
            => WriteEntry(message, "warning", callerName);

        public static void Info(string message, [CallerMemberName] string callerName = null) 
            => WriteEntry(message, "info", callerName);

        public static void EmptyLine() => _textWriterTraceListener.WriteLine("");

        /// <summary>
        /// Simple time stamp with time zone
        /// </summary>
        public static void Timestamp() => _textWriterTraceListener.WriteLine($"{DateTime.Now:HH:mm:ss tt zz}");

        private static void WriteEntry(string message, string type, string callerName)
        {
            _textWriterTraceListener.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss},{type},{callerName},{message}");

        }
    }
}