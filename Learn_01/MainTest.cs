#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ContainerLibrary;
using ContainerLibrary.Classes;
using ContainerLibrary.Extensions;
using ContainerLibrary.HelperClasses;
using Learn_01_Week_2.Base;
using Learn_01_Week_2.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.DateTime;
using static ContainerLibrary.MockedEntities;

namespace Learn_01_Week_2
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
            var results = ReadIccTransactionRecordsFromFile().transactionList.ToList();

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


        /// <summary>
        /// Exploration into IsNullOrWhiteSpace and if statements
        /// </summary>
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


        [TestMethod]
        [TestTraits(Trait.IfStatements)]
        public void IfCustomerIsNull()
        {
            Customer SingleCustomer()
            {
                var singleNotNullCustomer = GetCustomer();
                singleNotNullCustomer.FirstName = "Karen";
                return singleNotNullCustomer;
            }

            Customer SingleNullCustomer()
            {
                return null;
            }

            /*
             * Extension methods
             */
            Assert.IsTrue(SingleNullCustomer().IsNull());
            Assert.IsTrue(SingleCustomer().IsNotNull());

            Customer customer = SingleCustomer();

            if (customer is { } customer1)
            {
                Debug.WriteLine($"Customer is not null, first name is {customer1.FirstName}");
            }
            else
            {
                Debug.WriteLine("Customer was null");
            }


            Customer notNullCustomer = SingleNullCustomer();
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (notNullCustomer is not { } customer2)
            {
                Debug.WriteLine("Customer was null");
            }
            else
            {
                Debug.WriteLine($"{customer2.FirstName}");
            }

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
            Customer customer = GetCustomer();

            Assert.IsTrue(customer is not null);
            Assert.IsFalse(customer is null);

            customer.Value = 9;


            Assert.IsTrue(customer.Value.HasValue);
            Assert.IsTrue(customer.Value == 9);



            /*
             * assert Value is null -
             * Karen note, everyone on the team must understand this syntax else
             * don't use it,
             *
             * instead use .HasValue or is [not] null as shown a few lines down
             *
             */
            Assert.IsTrue(customer.Value is { }, "Expected not null");

            Assert.IsTrue(customer.Value.HasValue, "Expected not null");
            Assert.IsTrue(customer.Value is not null, "Expected not null");

            customer.Value = null;
            Assert.IsTrue(customer.Value is null, "Expected null");

            customer.FirstName = null;

            Assert.IsTrue(customer.FirstName is null, "Expected null");

            customer.FirstName = "Jon";
            Assert.AreEqual(customer.FirstName, "Jon");

            //-----------------------------------------------------------
            // Work against a class instance
            //-----------------------------------------------------------

            customer = null;
            Assert.IsNull(customer);
            Assert.IsTrue(customer.IsNull());

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (customer is { })
            {
                Debug.WriteLine("Customer is null");
            }
            else
            {
                Debug.WriteLine("Customer is not null");
            }

            /*
             * Same as last assertion using a ternary operator
             */
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            Debug.WriteLine(customer is { } ?
                "Customer is null" :
                "Customer is not null");


            Assert.IsFalse(customer is { });

        }

        [TestMethod]
        [TestTraits(Trait.PatternMatching)]
        public void PatternMatching_1()
        {
            void Conventional(object personObject)
            {
                if (personObject.GetType() == typeof(Developer))
                {
                    Debug.WriteLine($"Conventional  {((Developer)personObject).FirstName}");
                }
                

                if (personObject.GetType() == typeof(Developer))
                {
                    
                    var developer = (Developer) personObject;
                    
                    if (developer.Manager.FirstName == "Anne")
                    {
                        Debug.WriteLine($"Conventional, Manager is Karen");
                    }
                    
                }
                
                /*
                 * And so forth
                 */
            }
            
            void PatternMatching(object personObject)
            {
                /*
                 * Assert personObject is a Developer and manager's first name is Anne
                 */
                if (personObject is Developer { Manager: { FirstName: "Anne" } } developerWithAnneAsManager)
                {
                    Debug.WriteLine($"CountryIdentifier is {developerWithAnneAsManager.CountryIdentifier}");
                }

                /*
                 * Assert personObject is a Developer and manager's first name length is 4
                 */
                if (personObject is Developer { Manager: { FirstName: { Length: 4 } } } developerWithManagerFirstnameLengthOfFour)
                {
                    Debug.WriteLine($"Manager Years as manager is {developerWithManagerFirstnameLengthOfFour.Manager.YearsAsManager}");
                }

                if (personObject is Developer { YearOfBirth: >= 1980 and <= 1989 } devBornInEighties)
                {
                    Debug.WriteLine($"Year of birth {devBornInEighties.YearOfBirth}");
                }

                if (personObject is Developer { YearOfBirth: >= 1980 and <= 1989 and not 1984 } devBornInEighties1)
                {
                    Debug.WriteLine($"Not 1984 {devBornInEighties1.YearOfBirth}");
                }


                if (personObject is Developer { YearOfBirth: >= 1980 and <= 1989, Manager: var developersManager })
                {
                    Debug.WriteLine($"Manager's last name: {developersManager.LastName}");
                }

                if (personObject is Manager managerItem)
                {
                    Debug.WriteLine($"Manager first name is {managerItem.FirstName}");
                }
            }

            Developer developer = new ()
            {
                FirstName = "Karen", 
                YearOfBirth = 1986,
                CountryIdentifier = 10, 
                Manager = new Manager()
                {
                    FirstName = "Anne", 
                    LastName = "Roberts",
                    YearsAsManager = 4
                }
            };
            
            PatternMatching(developer);

            Manager manager = new()
            {
                FirstName = "Karen",
                CountryIdentifier = 10
            };
            
            PatternMatching(manager);

            developer = new()
            {
                FirstName = "Karen",
                YearOfBirth = 1986,
                CountryIdentifier = 10,
                Manager = new Manager()
                {
                    FirstName = "Anne",
                    LastName = "Roberts",
                    YearsAsManager = 4
                }
            };

            Conventional(developer);

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

            /*
             * local method where the average developer knows nothing about local methods/functions
             */
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


            /*
             * Hand write out the logic
             */
            Assert.IsTrue(numbersArray.All(item => item % 2 == 1));

            /*
             * Using an extension method which is reusable
             */
            Assert.IsTrue(numbersArray.All(item => item.IsOdd()));

            Assert.IsTrue(validator(numbersArray));


            numbersArray = new[] { 1, 12, 3, 19, 41, 65, 19 };
            Assert.IsFalse(numbersArray.All(item => item % 2 == 1));

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
        /// Testing with <see cref="NumericExtensions.GetMajor"/> and <see cref="GenericExtensions.Between"/>
        /// </summary>
        /// <remarks>
        /// This is a half-baked test, missing null assertions - expect issues which we will work through ✍(◔◡◔)
        /// </remarks>
        [TestMethod]
        [TestTraits(Trait.KarenTinkering)]
        public void ForEachJsonTrans()
        {

            var (transactionList, exception) = ReadIccTransactionRecordsFromFile();

            //  analyzer does not know it all
            if (exception is null)
            {

                var transResults = transactionList
                    .Where(item =>
                        item.TrGeoLongitude.HasValue &&
                        item.TrGeoLongitude.Value.GetMajor().Between(-155, -149));

                //  analyzer does not know it all
                if (transResults.Count() > 0)
                {
                    IOrderedEnumerable<IccTran> results = transResults.OrderBy(x => x.TrGeoLongitude);

                    foreach (var iccTran in results)
                    {
                        Console.WriteLine(iccTran.TrGeoLongitude);
                    }
                }

                Assert.AreEqual(transResults.Count(), 4);

            }
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

        /// <summary>
        /// Simple [do while] statement, mirrors the [for] statement below
        /// </summary>
        /// <remarks>
        /// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/do
        /// </remarks>
        [TestMethod]
        [TestTraits(Trait.WhileStatements)]
        public void Do_While_Simple()
        {

            var index = 0;

            var monthNames = Mocked.EnglishMonthList;

            do
            {
                Console.WriteLine(monthNames[index]);
                index++;

            } while (index <= 11);

            Console.WriteLine();

            index = 0;
            monthNames = Mocked.RussianMonthNames();
            while (index <= 11)
            {
                Console.WriteLine(monthNames[index]);
                index++;
            }


        }

        /// <summary>
        /// Demonstration for using while statement in <see cref="FileHelpers.ChunkLines"/> in tangent with yield
        /// in a foreach to split a file, in this case 10 lines for new file.
        /// 
        /// See <see cref="Learn_01.MainTest.Initialization"/> for code preparation
        /// 
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.WhileStatements)]
        public void WhileChunking()
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Orders.txt");
            int counter = 1;

            foreach (var lineArray in FileHelpers.ChunkLines(fileName, 10))
            {
                var currentFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", $"Order{counter}.txt");
                File.WriteAllLines(currentFileName, lineArray);
                counter += 1;
            }

        }

        /*
         * Switch statements
         * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements
         * https://social.technet.microsoft.com/wiki/contents/articles/54200.switch-statement-c.aspx
         */


        [TestMethod]
        [TestTraits(Trait.PlaceHolder)]
        public void CaseInsensitiveCaseString()
        {
           
            Debug.WriteLine(SwitchOperations.ExpressionBodiedMemberCaseInsensitive("YES"));
            Debug.WriteLine(SwitchOperations.ExpressionBodiedMemberCaseInsensitive("No"));
            Debug.WriteLine(SwitchOperations.ExpressionBodiedMemberCaseInsensitive("Maybe"));
            Debug.WriteLine(SwitchOperations.ExpressionBodiedMemberCaseInsensitive("Unsure"));
            Debug.WriteLine(SwitchOperations.ExpressionBodiedMemberCaseInsensitive(""));
        }
    
        
        /// <summary>
        /// Demonstrates switch expression as a language extension
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.SelectSwitch)]
        public void SimpleSwitchWithTernaryOperator()
        {
            var languageCode = LanguageCode.Russian;

            Debug.WriteLine("Russian");
            Debug.WriteLine(true.ToYesNoStringIs(languageCode));
            Debug.WriteLine(false.ToYesNoStringIs(languageCode));

            languageCode = LanguageCode.Spanish;

            Debug.WriteLine("Spanish");
            Debug.WriteLine(true.ToYesNoStringIs(languageCode));
            Debug.WriteLine(false.ToYesNoStringIs(languageCode));
        }

        [TestMethod]
        [TestTraits(Trait.SwitchExpressions)]
        public void EnvironDataCostCenter()
        {
            
            EnvironmentData.CostCenter = "040";
            SwitchOperations.ExpressionBodiedMember();
            
            var expected = "P O BOX 14135 * SALEM, OR  97309-5068(877) 345 - 3484 or Fax(503) 947 - 1335";
            
            Assert.AreEqual(EnvironmentData.UserAddress.Replace(Environment.NewLine, ""), expected);


            expected = "875 Union Street NESalem, OR  97311(800) 237-3710, Fax to (866) 345-1878";
            
            EnvironmentData.CostCenter = "999";
            SwitchOperations.ExpressionBodiedMember();
            Assert.AreEqual(EnvironmentData.UserAddress.Replace(Environment.NewLine, ""), expected);

        }

        [TestMethod]
        [TestTraits(Trait.SwitchExpressions)]
        public void SwitchNewAndConventional()  
        {
            /*
             * Local function
             */
            string FavoriteTask(object personObject) => personObject switch
            {
                Developer => "Write code",
                Manager   => "Create meetings",
                null      => "Unknown",
                not null  => "No idea"
            };

            Developer? developer = new() {FirstName = "Jim"};
            Debug.WriteLine($"{developer.FirstName} favorite task is {FavoriteTask(developer)}");

            /*
             * Passing a null Developer we will hit null case
             */
            developer = null;
            Debug.WriteLine(FavoriteTask(developer) == "Unknown");
            Debug.WriteLine(developer?.FirstName ?? "Null");

            /*
             * Employee is unknown, hit not null case
             */
            Employee employee = new();
            Debug.WriteLine(FavoriteTask(employee));
            

        }

        [TestMethod]
        [TestTraits(Trait.SwitchExpressions)]
        public void SwitchValueNamedTuple()
        {
            var expectedCapital = "Mexico City";
            var expectedFact    = "Is home to the world's largest pyramid";
            
            var country = CountryEnum.Mexico;
            var (capital, fact) = SwitchOperations.ExtractCountryDetails(country);

            Assert.AreEqual(capital, expectedCapital);
            Assert.AreEqual(fact, expectedFact);
        }

        [TestMethod]
        [TestTraits(Trait.Between)]
        public void BetweenDateGeneric()
        {
            var startHour = Now.AddHours(-1);
            var endHour = Now.AddHours(1);
            
            var start = new DateTime(Now.Year, Now.Month, Now.Day, startHour.Hour, 30, 0);
            var end = new DateTime(Now.Year, Now.Month, Now.Day, endHour.Hour, 59, 0);

            Debug.WriteLine($"{start}     {end}");
            Debug.WriteLine(Now.Between(start,end));
            
        }

        [TestMethod]
        [TestTraits(Trait.Between)]
        public void BetweenListInt_Elements()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> expected = new List<int>() {2, 3, 4 };

            List<int> items = list.BetweenElements(2, 4);
            foreach (var item in items)
            {
                Debug.WriteLine(item);
            }
            
            CollectionAssert.AreEqual(items, expected);
        }

        [TestMethod]
        [TestTraits(Trait.Between)]
        public void BetweenTwoIntGeneric()
        {


            int item = 3;
            
            Assert.IsTrue(item.Between(2,4));

            item = 12;
            Assert.IsFalse(item.Between(2,4));
        }

        /// <summary>
        /// Demonstrates
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.SelectSwitch)]
        public void CaseWhenInt()
        {
            static void CaseWhen(int sender)
            {
                switch (sender)
                {
                    case { } value when (value >= 7):
                        Debug.WriteLine($"I am 7 or above => {value}");
                        break;

                    case { } value when value.Between(4, 6):
                        Debug.WriteLine($"I am between 4 and 6 => {value}");
                        break;

                    case { } value when (value.LessThan(3)):
                        Debug.WriteLine($"I am 3 or less => {value}");
                        break;
                }
            }

            CaseWhen(5);
        }


    }
}
