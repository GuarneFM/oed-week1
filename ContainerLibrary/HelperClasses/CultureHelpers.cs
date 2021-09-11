using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ContainerLibrary.Classes;

namespace ContainerLibrary.HelperClasses
{
    public class CultureHelpers
    {
        /// <summary>
        /// Get all known cultures on the current machine
        /// </summary>
        public static List<CultureItem> GetAllCultureItems
            => CultureInfo
                .GetCultures(CultureTypes.AllCultures)
                .OrderBy(cultureInfo => cultureInfo.EnglishName)
                .Select(culture => new CultureItem { EnglishName = culture.EnglishName, Name = culture.Name })
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
}
