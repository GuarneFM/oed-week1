using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ContainerLibrary.Extensions;
using ContainerLibrary.HelperClasses;
using PlayGroundConsoleNetCoreApp.Classes;

// ReSharper disable once CheckNamespace
namespace PlayGroundConsoleNetCoreApp
{
    partial class Program
    {
        protected static string _firstName = "Karen";
        protected static string _middleName = "Anne";
        protected static string FullFirstName => $"{_firstName} {_middleName}";


        static void IndexString()
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

            Debug.WriteLine("");

        }

        static void RemoveAllSpaces()
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
        static void WorkingWithRanges()
        {

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

        static void StringArraysLastSixMonths()
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

        static void AllCultureOnCurrentMachine()
        {
            Debug.WriteLine($"{nameof(AllCultureOnCurrentMachine)} running");

            CultureHelpers.GetAllCultureItems.ForEach(cultureItem => Debug.WriteLine($"{cultureItem}"));

            Debug.WriteLine("");

        }

        static void RandomInts()
        {

            Debug.WriteLine($"{nameof(AllCultureOnCurrentMachine)} running");

            var rand = new Random();
            List<int> listNumbers = new List<int>();
            int number;
            for (int index = 0; index < 20; index++)
            {

                do
                {
                    number = rand.Next(1, 49);
                } while (listNumbers.Contains(number));

                listNumbers.Add(number);
            }

            foreach (var listNumber in listNumbers.OrderBy(value => value))
            {
                Debug.WriteLine(listNumber.ToString("D2"));
            }

            Debug.WriteLine("");
        }

    }

}
