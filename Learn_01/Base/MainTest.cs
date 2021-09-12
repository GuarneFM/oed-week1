#nullable enable
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContainerLibrary.Classes;
using ContainerLibrary.HelperClasses;
using Learn_01_Week_2.Classes;
using Learn_01_Week_2.LanguageExtensions;


namespace Learn_01_Week_2
{
    public partial class MainTest
    {
        /// <summary>
        /// Perform initialization before test runs using assertion on current test name.
        /// </summary>
        [TestInitialize]
        public void Initialization()
        {
            Mocking.Initialization();
            
            if (TestContext.TestName == nameof(WhileChunking))
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

                foreach (var file in Directory.GetFiles(path))
                {
                    /*
                     * Using an indexer to get the last char and assert if a number
                     * ^ (hat) means to index from end of the string, this is new to C# 8
                     */
                    if (file.FileNameLastCharIsDigit())
                    {
                        File.Delete(file); // for a real app we would use a try/catch
                    }
                }
            }
        }

        /// <summary>
        /// Perform cleanup after test runs using assertion on current test name.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == nameof(Simple_If_Statement_2))
            {
                // TODO
            }
        }
        /// <summary>
        /// Perform any initialize for the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }
        /// <summary>
        /// File name to use for deserializing IccTrans data
        /// </summary>
        public static string TransactionJsonFile = "IccTransData.json";

        /// <summary>
        /// Can also be a full method body
        /// </summary>
        /// <returns></returns>
        public static (List<IccTran> transactionList, Exception exception) ReadIccTransactionRecordsFromFile() 
            => JsonHelpers.JsonToListModel<IccTran>(TransactionJsonFile);


        /// <summary>
        /// Demonstrates <see cref="Enumerable.Any"/>
        /// </summary>
        /// <returns></returns>
        public static List<string> GetExcelFilesUsingAny()
        {

            var allowedExtensions = new[]
            {
                ".xls", 
                ".xlsx"
            };
            
            List<string?> excelFiles = Directory
                .GetFiles(AppDomain.CurrentDomain.BaseDirectory)
                .Where(file => allowedExtensions
                    .Any(file.ToLower().EndsWith))
                .Select(Path.GetFileName)

                .ToList();

            /*
             * ! (null-forgiving) operator
             * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving
             */
            return excelFiles!;

        }
        public static List<string> GetExcelFilesUsingNoviceVersion()
        {

            List<string> excelFiles = new();

            var fileLists = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);

            foreach (var item in fileLists)
            {
                if (Path.GetExtension(item) == ".xls" || Path.GetExtension(item) == ".xlsx")
                {
                    excelFiles.Add(Path.GetFileName(item));
                }
            }


            return excelFiles;

        }
    }
}
