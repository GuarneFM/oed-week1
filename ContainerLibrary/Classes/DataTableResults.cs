using System;
using System.Data;

namespace ContainerLibrary.Classes
{
    /// <summary>
    /// Not used as we are demonstrating a bad database connection while
    /// without a bad database connection this class provides one of two
    /// options for returning information, the other is a named value tuple
    /// </summary>
    public class DataTableResults
    {
        /// <summary>
        /// Holds data read from a database.
        /// </summary>
        public DataTable DataTable { get; set; }
        /// <summary>
        /// Set when there is a connection to the server failure
        /// </summary>
        public bool ConnectionFailed { get; set; }
        /// <summary>
        /// General exception message
        /// </summary>
        public string ExceptionMessage { get; set; }
        /// <summary>
        /// General exception if not connection failure
        /// </summary>
        public Exception GeneralException { get; set; }
        /// <summary>
        /// Is there an exception thrown
        /// </summary>
        public bool HasException => ConnectionFailed || GeneralException != null;
    }
}