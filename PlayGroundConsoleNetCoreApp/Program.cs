using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using PlayGroundConsoleNetCoreApp.Classes;
using PlayGroundNetClassLibrary.Classes;

namespace PlayGroundConsoleNetCoreApp
{


    partial class Program
    {

        static void Main(string[] args)
        {
            var russianMonthNames = CultureHelpers.RussianMonthNames();

            // get last six months of the year
            var lastSixMonthsVietnamese = russianMonthNames.ToArray()[^7..];

            // month names
            foreach (var result in lastSixMonthsVietnamese)
            {
                Debug.WriteLine(result);
            }
            
            Debug.WriteLine("Month name and month index");

            /*
             * Proof of concept which is why the last .ToList and .ForEach
             *
             * Note x.Index,-5:D2 means pad right 5 chars, place leading zero's on index
             */
            lastSixMonthsVietnamese
                .ToList()
                .Select((name, index) => new { Name = name, Index = index +6 })
                .ToList()
                .ForEach(x => Debug.WriteLine($"{x.Index,-5:D2}{x.Name}"));

  
            
        }




    }
}

public class CultureHelpers
{
    /// <summary>
    /// Get all known cultures on the current machine
    /// </summary>
    public static List<CultureItem> GetAllCultureItems
        => CultureInfo
            .GetCultures(CultureTypes.AllCultures)
            .OrderBy(cultureInfo => cultureInfo.EnglishName)
            .Select(culture => new CultureItem {EnglishName = culture.EnglishName, Name = culture.Name})
            .ToList();
    /// <summary>
    /// Returns a string list of month names for the current culture
    /// </summary>
    /// <returns>
    /// List of month names for current culture
    /// </returns>
    public static List<string> MonthNames() =>
        Enumerable.Range(1, 12)
            .Select((index) => DateTimeFormatInfo.CurrentInfo.GetMonthName(index))
            .ToList();


    public static List<string> RussianMonthNames() =>
        Enumerable.Range(1, 12)
            .Select((index) => new CultureInfo("ru-RU").DateTimeFormat.GetMonthName(index))
            .ToList();

    public static List<string> VietnameseMonthNames() =>
        Enumerable.Range(1, 12)
            .Select((index) => new CultureInfo("vi").DateTimeFormat.GetMonthName(index))
            .ToList();
}
    public class CultureItem
    {
        public string EnglishName { get; set; }
        public string Name { get; set; }
        public override string ToString() => $"{Name,-20}{EnglishName}";

    }

