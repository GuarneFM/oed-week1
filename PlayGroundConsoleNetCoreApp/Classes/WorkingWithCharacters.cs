using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ContainerLibrary.Extensions;
using ContainerLibrary.HelperClasses;


namespace PlayGroundConsoleNetCoreApp.Classes
{
    public class WorkingWithCharacters
    {
        protected static string _firstName = "Karen";
        protected static string _middleName = "Anne";
        protected static string FullFirstName => $"{_firstName} {_middleName}";


        private static void IndexString()
        {

            Debug.WriteLine($"{nameof(IndexString)} running");

            var lettersIndexed = _firstName
                .Select((@char, index) => new
                {
                    Char = @char,
                    Index = index
                }).ToList();


            foreach (var charItem in lettersIndexed)
            {
                Debug.WriteLine($"{charItem.Index,5:D3} {(int)charItem.Char,5} {char.GetUnicodeCategory(charItem.Char),16}");
            }

            Debug.WriteLine(new string('_', 30));
            Debug.WriteLine($"Last char conventional 1 {_firstName.LastOrDefault()}");

            // ReSharper disable once UseIndexFromEndExpression
            Debug.WriteLine($"Last char conventional 2 {_firstName[_firstName.Length - 1]}");

            /*
             * Indexer and assertion
             */
            if (_firstName.Length - 1 >= 0 && _firstName.Length > _firstName.Length - 1)
            {
                Debug.WriteLine($"           Last char new {_firstName[^1]}");
            }

            Debug.WriteLine($"            Next to last {_firstName[^2]}");
            Debug.WriteLine(new string('‾', 30));
            Debug.WriteLine("");



        }

        private static void IterateStringBackwards()
        {
            Debug.WriteLine($"{nameof(IterateStringBackwards)} running");

            // reverse string
            var firstNameBackwards = _firstName.ReverseEx();
            Debug.WriteLine(firstNameBackwards);

            // display first name as is
            for (int index = 0; index < firstNameBackwards.Length; index++)
            {
                Debug.WriteLine($"{firstNameBackwards[index]}");
            }

            Debug.WriteLine("");

            // for in reverse of last for statement
            for (int index = firstNameBackwards.Length - 1; index >= 0; index--)
            {
                Debug.WriteLine($"{firstNameBackwards[index]}");
            }

            Debug.WriteLine("");

        }

        private static void RemoveAllSpaces()
        {
            Debug.WriteLine($"{nameof(RemoveAllSpaces)} running");

            var builder = new StringBuilder();
            foreach (var character in _firstName)
            {
                builder.Append($"{character}  ");
            }


            Debug.WriteLine($"[{builder}]");
            Debug.WriteLine(builder.ToString().RemoveAllWhiteSpace());
            Debug.WriteLine("");

        }

        /// <summary>
        /// These code samples are based on <see cref="FullFirstName"/> as coded,
        /// less characters may raise an <see cref="IndexOutOfRangeException"/>
        /// </summary>
        private static void WorkingWithRanges()
        {

            Debug.WriteLine("");
            Debug.WriteLine($"{nameof(WorkingWithRanges)} running");

            var firstName = FullFirstName;

            /*
             * First char to next to last char
             */
            #region Two produce the same result
            Range range = 0..^1;
            firstName = firstName[range];
            Debug.WriteLine(firstName);



            Debug.WriteLine("");

            // variable method to get last 7 characters

            int indexer = 7;
            if (firstName.Length <= 10)
            {
                range = ^indexer..^0;
                Debug.WriteLine(firstName[range]);
            }
            #endregion

            /*
             * Exclude first two characters
             */
            firstName = firstName[^7..]; //Equivalent of input[^7..^0]
            Debug.WriteLine(firstName);
        }

        private static void StringArraysLastSixMonths()
        {
            Debug.WriteLine($"{nameof(StringArraysLastSixMonths)} running");

            var englishMonthNames = CultureHelpers.MonthNames();

            // get last six months of the year
            var lastSixMonthsEnglish = englishMonthNames.ToArray()[^7..];

            // month names
            foreach (var result in lastSixMonthsEnglish)
            {
                Debug.WriteLine(result);
            }

            Debug.WriteLine("");

            /*
             * Proof of concept which is why the last .ToList and .ForEach
             *
             * Note x.Index,-5:D2 means pad right 5 chars, place leading zero's on index
             */
            lastSixMonthsEnglish
                .ToList()
                .Select((name, index) => new { Name = name, Index = index + 6 })
                .ToList()
                // acceptable one char var
                .ForEach(x => Debug.WriteLine($"{x.Index,-5:D2}{x.Name}"));

            Debug.WriteLine("");
        }

        private static void AllCultureOnCurrentMachine()
        {
            Debug.WriteLine($"{nameof(AllCultureOnCurrentMachine)} running");

            CultureHelpers.GetAllCultureItems.ForEach(cultureItem => Debug.WriteLine($"{cultureItem}"));

            Debug.WriteLine("");

        }

        private static void RandomInts()
        {

            Debug.WriteLine($"{nameof(RandomInts)} running");

            Debug.WriteLine("");

            var rand = new Random();
            List<int> listNumbers = new List<int>();

            for (int index = 0; index < 20; index++)
            {
                int number;
                do
                {
                    number = rand.Next(1, 49);
                } while (listNumbers.Contains(number));

                listNumbers.Add(number);
            }

            Debug.WriteLine(string.Join(",", listNumbers));

            Debug.WriteLine("");
        }

        /// <summary>
        /// To assist with <seealso cref="StringExtensions.RemoveAllWhiteSpace"/> with explaining Aggregate,
        /// in this case with strings
        /// </summary>
        private static void AggregateStringConcatenateDelimited()
        {

            Debug.WriteLine($"{nameof(AggregateStringConcatenateDelimited)} running");

            List<string> monthNames = Enumerable.Range(1, 12)
                .Select((index) => DateTimeFormatInfo.CurrentInfo.GetMonthName(index))
                .ToList();

            string commaDelimited = monthNames.Aggregate((value1, value2) => value1 + ", " + value2);

            Debug.WriteLine(commaDelimited);

            Debug.WriteLine("");

            commaDelimited = string.Join(", ", monthNames.ToArray());

            Debug.WriteLine(commaDelimited);

            Debug.WriteLine("");


        }
        /// <summary>
        /// 
        /// To assist with <seealso cref="StringExtensions.RemoveAllWhiteSpace"/> with explaining Aggregate,
        /// in this case
        ///
        /// Step1: First it multiplies (2*3) to produce the result as 6
        /// Step2: Result of Step 1 i.e. 6 is then multiplied with 5 to produce the result as 30
        /// Step3: Result of Step 2 i.e. 30 is then multiplied with 7 to produce the result as 210.
        /// Step4: Result of Step 3 i.e. 210 is then multiplied with 9 to produce the final result as 1890.
        /// </summary>
        private static void AggregateIntConcatenateDelimited()
        {

            Debug.WriteLine($"{nameof(AggregateIntConcatenateDelimited)} running");

            int[] intNumbers = { 3, 5, 7, 9 };
            int result = intNumbers.Aggregate(2, (value1, value2) => value1 * value2);
            Debug.WriteLine(result);
        }
    }
}
