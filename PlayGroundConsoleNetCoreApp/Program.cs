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

            string value = "1a";

            if (int.TryParse(value, out var result))
            {
                Debug.WriteLine(result);
            }
            else
            {
                Debug.WriteLine($"{value} is not an int");
            }


            
            if (value.IsNumeric())
            {
                
            }
            else
            {
                
            }



            value = "1.2";
            if (decimal.TryParse(value, out var someResult))
            {
                
            }
            else
            {
                
            }




       








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

