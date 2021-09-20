using System;

namespace PlayGroundConsoleNetCoreApp.Classes
{
    public class Person1
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString() => $"{Id,6}  {BirthDate:MM/dd/yyyy}  ";

    }
}