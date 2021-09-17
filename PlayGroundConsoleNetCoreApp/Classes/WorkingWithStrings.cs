using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ContainerLibrary;
using ContainerLibrary.Extensions;

namespace PlayGroundConsoleNetCoreApp.Classes
{
    public class WorkingWithStrings
    {
        public static void ReplaceStringWithString()
        {
            Announce(nameof(ReplaceStringWithString));

            string value = "First Class Mail";
            
            Announce("C# is case sensitive so this fails");
            Debug.WriteLine(value.Replace("first", "Second"));
            
            Announce("Bring in RegEx");
            Debug.WriteLine(Regex.Replace(value, "first", "Second", RegexOptions.IgnoreCase));
            
            Announce("make it reusable via a extension method");
            Debug.WriteLine(value.ReplaceInsensitive("first", "Second"));

        }

        public static void FindStringInString()
        {
            Announce(nameof(FindStringInString));

            string value = "First Class Mail";

            // fail to find
            Announce("fail to find");
            Debug.WriteLine(value.Contains("class"));

            // got it
            Announce("got it");
            Debug.WriteLine(value.Contains("class", StringComparison.OrdinalIgnoreCase));

            // fail with -1
            Announce("fail with -1");
            var location = value.IndexOf("m");
            Debug.WriteLine(location);

            // finds it at position 12
            Announce("finds it at position 12");
            location = value.IndexOf("m", StringComparison.OrdinalIgnoreCase);
            Debug.WriteLine(location);

            Debug.WriteLine("");
        }

        public static void TrimmingWhitespace()
        {
            Announce(nameof(TrimmingWhitespace));

            string value = " First Class Mail ";

            Debug.WriteLine($"[{value.Trim()}]");
        }

        public static void ExtractPartOfString()
        {
            Announce(nameof(ExtractPartOfString));

            string value = "First Class Mail";
            Debug.WriteLine(value);


            Debug.WriteLine("");

            Debug.WriteLine(value.SubstringByIndexes(6, 11));

            Debug.WriteLine(value[6..]);


            /*
             * New to C#8
             * https://github.com/karenpayneoregon/csharp-features/tree/master/Ranges-examples
             */
            Console.WriteLine($"        Last char '{value[^1]}'");
            Console.WriteLine($"Next to last char '{value[^2]}'");

            Index index = new Index(value.IndexOf("Class", StringComparison.Ordinal) - 1, true);
            Debug.WriteLine($"Start of string to one char less than end char ");
            Debug.WriteLine($"{value[..^1]}\n");

            Debug.WriteLine($"Start of string to Class ");
            Debug.WriteLine($"{value[..index]}\n");
            

            Debug.WriteLine("");

            // hard coded
            Debug.WriteLine("Range");
            Range phrase1 = 6..11; // Get 'Class`
            Debug.WriteLine($"\t{value[phrase1]}");

            //  dynamic
            int position = value.IndexOf("Class", StringComparison.Ordinal);
            Range phrase2 = new Range(position, position + "Class".Length);
            Debug.WriteLine($"\t{value[phrase2]}");

            Debug.WriteLine("");

            /*
             * New to C# 8
             * https://github.com/karenpayneoregon/indexes-ranges-csharp
             */
            var sentence = "Just want to say, Hello World there!";
            Index indexStart = sentence.IndexOf("world", StringComparison.InvariantCultureIgnoreCase) - 1;
            Debug.WriteLine($"{sentence[..indexStart]} to you!!!");

            Ranger();

        }
        /// <summary>
        /// Advance code to work with obtaining parts of a string array (in this case).
        /// This is simply a peek for what is coming down the road.
        /// 
        /// Index Operator ^ (hat operator)
        /// Range Operator ..
        /// </summary>
        private static void Ranger()
        {
            
            Announce(nameof(Ranger));
            
            var list = Mocked.EnglishMonthList;

            Debug.WriteLine($" {list.JoinWith()}");
            Debug.WriteLine("");

            /*
             * Get first two elements as ^1 skips the last element
             * Which can also be expressed as
             *    list.GetRange(0..2)
             */

            Range range = new Range(0, ^1);
            List<string> subList1 = list.GetRange(range);

            /*
             * Get first element where 0 is first and ..1 get one
             */
            List<string> subList = list.GetRange(0..1);


            Debug.WriteLine($"        Range(0, ^1)\t{string.Join(",", subList1.ToArray())}");
            Debug.WriteLine($" list.GetRange(0..1)\t{string.Join(",", subList.ToArray())}");

            Debug.WriteLine("");

        }
        /// <summary>
        /// Strings are reallocated with each concatenation which for small operations
        /// this is okay while working with many strings will eat up memory
        /// </summary>
        public static void NoviceConcatenation()
        {
            Announce(nameof(NoviceConcatenation));

            List<string> monthList = Mocked.EnglishMonthList;
            var monthNames = "";

            foreach (var name in monthList)
            {
                monthNames += name + " ";
            }

            Console.WriteLine(monthNames);

        }
        public static void RecommendedConcatenation()
        {

            Announce(nameof(RecommendedConcatenation));

            List<string> monthList = Mocked.EnglishMonthList;

            StringBuilder builder = new();

            foreach (var name in monthList)
            {
                builder.Append($"{name} ");
            }

            Console.WriteLine(builder.ToString());


        }
        /// <summary>
        /// Message helper
        /// </summary>
        /// <param name="message"></param>
        private static void Announce(string message)
        {
            Debug.WriteLine(new string('_', 30));
            Debug.WriteLine(message);
            Debug.WriteLine(new string('‾', 30));

        }
    }
}
