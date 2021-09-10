using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PlayGroundConsoleNetCoreApp.Classes;
using PlayGroundNetClassLibrary.Classes;

namespace PlayGroundConsoleNetCoreApp
{

    partial class Program
    {
        

        
        static void Main(string[] args)
        {
            string firstName = "Karen";
            var lettersIndexed = firstName
                .Select((@char, index) => new CharIndexed {Char = @char, Index = index});


            lettersIndexed.ToList().ForEach(indexedItem => Debug.WriteLine($"{indexedItem.Index} {indexedItem.Char}"));
            Debug.WriteLine("");
            firstName.Indexed().ForEach(indexedItem => Debug.WriteLine($"{indexedItem} "));
        }
    }

    public static class Extensions
    {
        public static List<CharIndexed> Indexed(this string sender) 
            => sender.Select((@char, index) => 
                new CharIndexed { Char = @char, Index = index }).ToList();

    }
    public class CharIndexed
    {
        public char Char { get; set; }
        public int Index { get; set; }

        public override string ToString()
        {
            return $"{{ Char = {Char}, Index = {Index} }}";
        }
    }
}
