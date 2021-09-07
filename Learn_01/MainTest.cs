using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Learn_01.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerLibrary;
using ContainerLibrary.Extensions;

namespace Learn_01
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        /// <summary>
        /// Basic [if statement] utilizing a [foreach iterator statement]
        ///
        /// Hidden in this method
        /// - Using the debugger with conditions
        ///    - We will alter the value for the [if statement] to show simple debugging techniques
        /// 
        /// </summary>
        /// <remarks>
        /// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/if-else
        /// </remarks>
        [TestMethod]
        [TestTraits(Trait.IfStatements)]
        public void Simple_If_Statement_3()
        {
            var results = ReadIccTransactionRecordsFromFile()
                .transactionList.ToList();

            int countForPin = 0;

            foreach (var iccTran in results)
            {
                if (iccTran.TrPin == "0003")
                {
                    countForPin += 1;
                }
            }

            Assert.IsTrue(countForPin > 0);

            var count = results.Count(record => record.TrPin == "0003");
            Console.WriteLine($"Found {count} and {countForPin}");

        }


        [TestMethod]
        [TestTraits(Trait.IfStatements)]
        public void Simple_If_Statement_2()
        {
            Assert.IsNull(MockedEntities.nullEmployee());
            Assert.IsTrue(MockedEntities.nullEmployee() is null);
            Assert.IsTrue(MockedEntities.nullEmployee() == null);
            Assert.IsTrue(MockedEntities.notNullEmployee() is not null);
            Assert.IsTrue(MockedEntities.notNullEmployee() != null);
        }
        /// <summary>
        /// Here the [if statement] uses C#8 property pattern matching
        ///
        /// {} is a compact version of "not-null"
        /// </summary>
        /// <remarks>
        /// https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/may/csharp-8-0-pattern-matching-in-csharp-8-0
        /// </remarks>
        [TestMethod]
        [TestTraits(Trait.IfStatements)]
        public void If_Nullable_Property_IsNull_PropertyMatching()
        {
            var customer = MockedEntities.GetCustomer();
            customer.Value = 9;

           
            Assert.IsTrue(customer.Value.HasValue);
            Assert.IsTrue(customer.Value == 9);



            /*
             * assert Value is null -
             * Karen note, everyone on the team must understand this syntax else
             * don't use it, instead use .HasValue or is [not] null
             */
            Assert.IsTrue(customer.Value is { }, "Expected not null");

            Assert.IsTrue(customer.Value.HasValue, "Expected not null");
            Assert.IsTrue(customer.Value is not null, "Expected not null");

            customer.Value = null;
            Assert.IsTrue(customer.Value is null, "Expected null");

            customer.FirstName = null;

            Assert.IsTrue(customer.FirstName is null, "Expected null");

            customer.FirstName = "Jon";
            Assert.AreEqual(customer.FirstName,"Jon");

            //-----------------------------------------------------------
            // Work against a class instance
            //-----------------------------------------------------------

            customer = null;
            Assert.IsNull(customer);
            Assert.IsTrue(customer.IsNull());

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (customer is { })
            {
                Debug.WriteLine("Customer is null");
            }
            else
            {
                Debug.WriteLine("Customer is not null");
            }

            Assert.IsFalse(customer is { });

            // ReSharper disable once ExpressionIsAlwaysNull
            switch (customer)
            {
                case { }:
                    Debug.WriteLine("Customer is null");
                    break;
                default:
                    Debug.WriteLine("Customer is not null");
                    break;
            }
        }

        /// <summary>
        /// Simple [for] statement, mirrors the above [do while] statement
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.ForSimpleStatements)]
        public void For_Simple()
        {

            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> result = new();

            var (transactionList, exception) = ReadIccTransactionRecordsFromFile();

            Assert.IsTrue(exception is null);


            for (int index = 0; index < 9; index++)
            {
                result.Add(transactionList[index].Identifier);
            }


            CollectionAssert.AreEqual(expected, result.ToArray());

        }
        [TestMethod]
        [TestTraits(Trait.ForSimpleStatements)]
        public void ForEach_Simple()
        {

            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> result = new();

            var (transactionList, exception) = ReadIccTransactionRecordsFromFile();

            Assert.IsTrue(exception is null);

            // ... indicates Resharper can optimize this code and the Assert too.
            foreach (var index in expected)
            {
                result.Add(transactionList[index - 1].Identifier);
            }

            CollectionAssert.AreEqual(expected, result.ToArray());

        }
        /// <summary>
        /// Demonstrates using .ForEach language extension rather tha a
        /// traditional [for-each] statement.
        ///
        /// Easy to write, in some cases may be hard to debug if not using
        /// Resharper as Resharper will offer to convert to a traditional
        /// [for-each] statement
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.ForSimpleStatements)]
        public void ForEach_Lambda()
        {

            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> result = new();

            var (transactionList, exception) = ReadIccTransactionRecordsFromFile();

            Assert.IsTrue(exception is null);

            transactionList
                .Take(9)
                .ToList()
                .ForEach(record => result.Add(record.Identifier));


            CollectionAssert.AreEqual(expected, result.ToArray());

        }

    }
}
