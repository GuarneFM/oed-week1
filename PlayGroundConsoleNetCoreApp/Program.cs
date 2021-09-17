
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PlayGroundConsoleNetCoreApp.Classes;


namespace PlayGroundConsoleNetCoreApp
{
    partial class Program
    {

        static void Main(string[] args)
        {

        }

        private static void RefactorThese()
        {

            //IndexString();
            //RemoveAllSpaces();
            //WorkingWithRanges();
            //StringArraysLastSixMonths();
            //AllCultureOnCurrentMachine();
            //RandomInts();
        }

        private static void StashTemp()
        {
            /*--------------------------------------------------------------------
             * Example code for handling inability to connection to a SQL-Server
             *  - Demonstrates controlling time-out
             *  - Demonstrates simple delegates and events
             --------------------------------------------------------------------*/
            //SqlFailureOperations.UnhandledException += SqlFailureOperationsOnUnhandledException;
            //SqlFailureOperations.ConnectionFailed += SqlFailureOperationsOnConnectionFailed;
            //await SqlFailureOperations.OpenConnection();
            //SqlFailureOperations.ConnectionFailed -= SqlFailureOperationsOnConnectionFailed;
            //SqlFailureOperations.UnhandledException -= SqlFailureOperationsOnUnhandledException;

        }

        #region Events for SqlFailureOperations
        private static void SqlFailureOperationsOnUnhandledException(Exception exception)
        {
            Debug.WriteLine(exception.Message);
        }

        private static void SqlFailureOperationsOnConnectionFailed(string exceptionMessage)
        {
            Debug.WriteLine(exceptionMessage);
        }
        #endregion
    }

}

