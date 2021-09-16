using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;


namespace PlayGroundConsoleNetCoreApp
{
    partial class Program
    {

        static void Main(string[] args)
        {

            string[] names = {"Karen", "Amelia", "Bick" };

            Debug.WriteLine("");

            for (int index = 0; index < names.Length; index++)
            {
                Debug.WriteLine($"{index}  {names[index]}");
            }

            Debug.WriteLine("");

            Debug.WriteLine(string.Join(", ", names));
            Debug.WriteLine("");

            //IndexString();
            //IterateStringBackwards();
            //RemoveAllSpaces();
            //WorkingWithRanges();
            //StringArraysLastSixMonths();
            //AllCultureOnCurrentMachine();
            //RandomInts();




            //AggregateStringConcatenateDelimited();
            //AggregateIntConcatenateDelimited();
        }
    }
}

