using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ContainerLibrary.Classes;
//using ContainerLibrary.Extensions;
using ContainerLibrary.Extensions;
using PlayGroundConsoleNetCoreApp.Classes;


namespace PlayGroundConsoleNetCoreApp
{
    partial class Program
    {

        static void Main(string[] args)
        {

        }

        private static void HourArray()
        {
            var hours = Hours.HalfHour;
            Debug.WriteLine($"{hours.Length}");
        }

        private static void ElapsedTime()
        {
            var startDate = DateTime.Now.AddHours(-1).AddMinutes(1).AddSeconds(-20);
            var endDate = DateTime.Now;

            Debug.WriteLine($"span {(endDate - startDate).FormatElapsed()}");
            Debug.WriteLine($"test {endDate.Subtract(startDate).FormatElapsed()}");
        }

        private static void RefactorThese()
        {

            WorkingWithCharacters.IndexString();
            WorkingWithCharacters.RemoveAllSpaces();
            WorkingWithCharacters.WorkingWithRanges();
            WorkingWithCharacters.StringArraysLastSixMonths();
            WorkingWithCharacters.AllCultureOnCurrentMachine();
            WorkingWithCharacters.RandomInts();
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

    internal class Order
    {
    }
}

