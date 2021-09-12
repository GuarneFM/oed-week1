using System;
using ContainerLibrary.Interfaces;

namespace ContainerLibrary.Classes
{
    public class Person : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public int CountryIdentifier { get; set; }
        public int YearOfBirth { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public override string ToString() => $"{Id} {FullName}";
    }

 
}
