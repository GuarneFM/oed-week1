using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ContainerLibrary;
using Learn_01.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerLibrary.Extensions;
using Learn_01.Classes;
using Learn_01.LanguageExtensions;
using static ContainerLibrary.MockedEntities;

namespace Learn_01
{
    /// <summary>
    /// </summary>
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

            var countForPin = 0;

            foreach (var iccTran in results)
            {
                if (iccTran.TrPin == "0003")
                {
                    countForPin += 1;
                }
            }

            Assert.IsTrue(countForPin == 314);

        }

        [TestMethod]
        [TestTraits(Trait.IfStatements)]
        public void IfStringIsEmptyOrWhiteSpace()
        {
            string monthName = "";

            if (!string.IsNullOrWhiteSpace(monthName))
            {
                
            }

            if (monthName.IsNullOrWhiteSpace())
            {
                
            }

            monthName = Mocked.RussianMonthNames().FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(monthName))
            {

            }

            if (monthName.IsNullOrWhiteSpace())
            {

            }


        }



        [TestMethod]
        [TestTraits(Trait.IfStatements)]
        public void Simple_If_Statement_2()
        {
            Assert.IsNull(nullEmployee());
            Assert.IsTrue(nullEmployee() is null);
            Assert.IsTrue(nullEmployee() == null);
            Assert.IsTrue(notNullEmployee() is not null);
            Assert.IsTrue(notNullEmployee() != null);
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
            var customer = GetCustomer();
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
        /// Demonstrates a logic test using .Any
        /// </summary>
        /// <remarks>
        /// By altering <see cref="Mocking.DummyFileNameList"/> can break this test as we are looking at a count
        /// </remarks>
        [TestMethod]
        [TestTraits(Trait.IfStatements)]
        public void If_Any()
        {
            int expectedCount = 4;
            
            Assert.AreEqual(GetExcelFilesUsingAny().Count, expectedCount, "Did you change mocked data?");
            
            Assert.AreEqual(GetExcelFilesUsingNoviceVersion().Count, expectedCount, "Did you change mocked data?");
            
        }

        /// <summary>
        /// determine whether an array contains only odd numbers.
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.IfStatements)]
        public void If_All()
        {
            bool validator(int[] numbers)
            {
                foreach (var value in numbers)
                {
                    if (value % 2 != 1) continue;
                    return true;
                }
                return false;

            }
            int[] numbersArray = { 1, 11, 3, 19, 41, 65, 19 };

           
            Assert.IsTrue(numbersArray.All(item => item % 2 == 1));
            
            Assert.IsTrue(validator(numbersArray));
            
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
                .Take(9) // take first nine records
                .ToList()
                .ForEach(record => result.Add(record.Identifier));


            CollectionAssert.AreEqual(expected, result.ToArray());

        }

    }
}
