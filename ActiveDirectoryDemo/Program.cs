using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Linq;


namespace ActiveDirectoryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine($"{UserDetails.FirstName} {UserDetails.LastName}");
            IterateEachCharacterInFirstName();
        }

        private static void IterateEachCharacterInFirstName()
        {
            foreach (char character in UserDetails.FirstName)
            {
                Debug.WriteLine($"{character}");
            }
        }
    }
}
