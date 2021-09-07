using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContainerLibrary.Classes;


// ReSharper disable once CheckNamespace - do not change
namespace Learn_01
{
    public partial class MainTest
    {
        /// <summary>
        /// Perform initialization before test runs using assertion on current test name.
        /// </summary>
        [TestInitialize]
        public void Initialization()
        {
            if (TestContext.TestName == nameof(Simple_If_Statement_2))
            {
                // TODO
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
        public static (List<IccTran> transactionList, Exception exception) ReadIccTransactionRecordsFromFile() =>
            Helpers.JsonToListModel<IccTran>(TransactionJsonFile);


    }
}
