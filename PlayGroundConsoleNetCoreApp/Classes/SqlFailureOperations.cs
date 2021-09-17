using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayGroundConsoleNetCoreApp.Classes
{
    /// <summary>
    /// 
    /// Code is based off  -> Microsoft TechNet SQL-Server freezes when connecting (C#)
    /// https://social.technet.microsoft.com/wiki/contents/articles/54260.sql-server-freezes-when-connecting-c.aspx
    ///
    /// Demonstrates how to control opening a SQL-Server connection which may have a invalid connection string,
    /// server is unavailable or insufficient permissions.
    ///
    /// Normal time-out is about 30 seconds, in this example we allow four seconds
    /// 
    /// </summary>
    public class SqlFailureOperations
    {
        #region For this code sample none of these fields need to be private yet in a real app they might when in multi-task environment
        private static CancellationTokenSource _cancellationTokenSource = new(TimeSpan.FromSeconds(4));
        private static string _connectionString = "";
        public static bool RunWithoutIssues = true;
        #endregion

        /*
         * Event to raise on connection failure to server
         */
        public delegate void OnConnectionFailed(string exceptionMessage);
        public static event OnConnectionFailed ConnectionFailed;

        public delegate void OnUnhandledException(Exception exception);
        public static event OnUnhandledException UnhandledException;

        /// <summary>
        /// Caller for opening a connection
        /// </summary>
        /// <returns></returns>
        public static async Task OpenConnection()
        {
            if (_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(4));
            }

            DataTableResults results = await ReadProductsTask(_cancellationTokenSource.Token);
            Debug.WriteLine(results.ExceptionMessage);

        }

        public static async Task<DataTableResults> ReadProductsTask(CancellationToken cancellationToken)
        {
            var result = new DataTableResults() { DataTable = new DataTable() };

            /*
             * Dependent on RunWithoutIssues use a valid or invalid connection string
             */
            _connectionString = RunWithoutIssues ?
                "Data Source=.\\sqlexpressISSUE;Initial Catalog=NorthWind2020;Integrated Security=True" :
                "Data Source=.\\sqlexpress;Initial Catalog=NorthWind2020;Integrated Security=True";

            // ReSharper disable once MethodSupportsCancellation
            return await Task.Run(async () =>
            {
                await using var cn = new SqlConnection(_connectionString);
                await using var cmd = new SqlCommand() { Connection = cn };
                cmd.CommandText = SelectStatement();

                try
                {
                    await cn.OpenAsync(cancellationToken);
                }
                catch (TaskCanceledException tce)
                {
                    ConnectionFailed?.Invoke($"Connection timed out: {tce.Message}");

                    result.ConnectionFailed = true;
                    result.ExceptionMessage = "Connection Failed";
                    return result;
                }
                catch (Exception exception)
                {
                    UnhandledException?.Invoke(exception);
                    result.GeneralException = exception;
                    return result;
                }

                result.DataTable.Load(await cmd.ExecuteReaderAsync(cancellationToken));

                return result;

            });

        }

        /// <summary>
        /// Valid SQL for NorthWind2020 database
        /// </summary>
        /// <returns></returns>
        private static string SelectStatement()
        {
            return "SELECT P.ProductID, P.ProductName, P.SupplierID, S.CompanyName, P.CategoryID, " +
                   "C.CategoryName, P.QuantityPerUnit, P.UnitPrice, P.UnitsInStock, P.UnitsOnOrder, " +
                   "P.ReorderLevel, P.Discontinued, P.DiscontinuedDate " +
                   "FROM  Products AS P INNER JOIN Categories AS C ON P.CategoryID = C.CategoryID " +
                   "INNER JOIN Suppliers AS S ON P.SupplierID = S.SupplierID";
        }
    }
}
