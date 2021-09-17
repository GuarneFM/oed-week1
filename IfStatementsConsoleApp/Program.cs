using System;
using System.Diagnostics;
using System.IO;
using ContainerLibrary;
using ContainerLibrary.Extensions;
using IfStatementsConsoleApp.HelperClasses;


namespace IfStatementsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Logger.CreateLog();
            Logger.Timestamp();
            Logger.EmptyLine();

            Operations.Simple_If_Statement_2();
            Operations.If_Nullable_Property_IsNull_PropertyMatching();
            
            try
            {

                Operations.CrashNicely();
                Operations.SimpleDiscard();
            }
            finally
            {
                Logger.Close();
            }
        }
    }

    class Operations
    {

        public static void CrashNicely()
        {
            string obj = "A";

            try
            {
                var test = Convert.ToInt32(obj);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                Logger.Close();
            }

        }
        /// <summary>
        /// Standard [if statement] working with null
        /// </summary>
        /// <remarks>
        /// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/if-else
        /// </remarks>
        public static void Simple_If_Statement_2()
        {

            Logger.Info(" => Standard [if statement] working with null");
            Debug.WriteLine(nameof(Simple_If_Statement_2));
            
            if (MockedEntities.nullEmployee() is null)
            {
                Debug.WriteLine("Employee is null 1");
            }

            if (MockedEntities.nullEmployee() == null)
            {
                Debug.WriteLine("Employee is null 2");
            }


            if (MockedEntities.notNullEmployee() is not null)
            {
                Debug.WriteLine("Employee is not null 1");
            }

            if (MockedEntities.notNullEmployee() != null)
            {
                Debug.WriteLine("Employee is not null 2");
            }

            Logger.EmptyLine();
            Logger.Close();

        }
        
        public static void If_Nullable_Property_IsNull_PropertyMatching()
        {

            Logger.Info(" => Pattern matching");

            Debug.WriteLine(nameof(If_Nullable_Property_IsNull_PropertyMatching));
            
            var customer = MockedEntities.GetCustomer();
            customer.Value = 9;


            // traditional way to determine if a nullable property is null or not null
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (customer.Value.HasValue)
            {
                Debug.WriteLine(customer.Value.Value);
            }
            else
            {
                Debug.WriteLine("Customer.Value is null");
            }


            if (customer.Value is { })
            {
                Debug.WriteLine("Expected not null");
            }


            if (customer.Value.HasValue)
            {
                Debug.WriteLine("Expected not null");
            }

            if (customer.Value is { } value1)
            {
                Debug.WriteLine($"Value1 is {value1}");
            }
            else
            {
                Debug.WriteLine("Customer.Value is Null");
            }

            customer.Value = null;

            if (customer.Value is { } value2)
            {
                Debug.WriteLine($"Value2 is {value2}");
            }
            else
            {
                Debug.WriteLine("Customer.Value is Null");
            }


            customer.FirstName = null;

            if (customer.FirstName is { } firstName1)
            {
                Debug.WriteLine($"FirstName1 is {firstName1}");
            }
            else
            {
                Debug.WriteLine("FirstName is Null");
            }

            customer.FirstName = "Jon";
            if (customer.FirstName is { } firstName2)
            {
                Debug.WriteLine($"FirstName1 is {firstName2}");
            }
            else
            {
                Debug.WriteLine("FirstName is Null");
            }

            //-----------------------------------------------------------
            // Work against a class instance
            //-----------------------------------------------------------

            customer = null;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (customer is null)
            {
                Debug.WriteLine("Customer is null");
            }
            else
            {
                Debug.WriteLine("Customer is not null");
            }

            // ReSharper disable once ExpressionIsAlwaysNull
            if (customer.IsNull())
            {
                Debug.WriteLine("Customer is null");
            }
            else
            {
                Debug.WriteLine("Customer is not null");
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (customer is { })
            {
                Debug.WriteLine("Customer is null");
            }
            else
            {
                Debug.WriteLine("Customer is not null");
            }

            Debug.WriteLine(customer is { });


            switch (customer)
            {
                case { }:
                    Debug.WriteLine("Customer is null");
                    break;
                default:
                    Debug.WriteLine("Customer is not null");
                    break;
            }

            Logger.EmptyLine();
            Logger.Close();
        }

        public static void SimpleDiscard()
        {

            Logger.Info($"Starting {nameof(SimpleDiscard)}");

            string value = "100";

            int result1;
            Announce("local variable");
            if (int.TryParse(value, out result1))
            {
                Debug.WriteLine($"value {value} as int {result1}");
            }
            else
            {
                Debug.WriteLine("value can not be represented as an int");
            }

            Announce("inline variable");
            if (int.TryParse(value, out var result2))
            {
                Debug.WriteLine($"value {value} as int {result2}");
            }
            else
            {
                Debug.WriteLine("value can not be represented as an int");
            }

            Announce($"discard - we are only checking to see if value can represent an int");
            if (int.TryParse(value, out _))
            {
                Debug.WriteLine($"value {value} is an int");
            }
            else
            {
                Debug.WriteLine("value can not be represented as an int");
            }

            value = "1A2B";
            Announce($"value '{value}' does represent a decimal");
            if (int.TryParse(value, out _))
            {
                Debug.WriteLine($"value {value} is an int");
            }
            else
            {
                Debug.WriteLine("value can not be represented as an int");
            }


            value = "1.8";
            /*
             * 1.8  can not represent an int
             */
            Announce("value does represent a decimal - using discard");
            if (int.TryParse(value, out _))
            {
                Debug.WriteLine($"value {value} is an int");
            }
            else
            {
                Debug.WriteLine("value can not be represented as an int");
            }


            Announce("value does represent a decimal");

            if (decimal.TryParse(value, out _))
            {
                Debug.WriteLine($"value {value} is an int");
            }
            else
            {
                Debug.WriteLine("value can not be represented as an int");
            }

            Announce("double to int casting");

            double itemP = 2.4;
            double itemN = -2.4;

            Debug.WriteLine($"{(int)((double)(itemP))}");
            Debug.WriteLine($"{(int)((double)(itemN))}");

            Announce("double to int using Math.Floor");

            Debug.WriteLine($"{(int)(Math.Floor(Convert.ToDouble(itemP)))}");
            Debug.WriteLine($"{(int)(Math.Floor(Convert.ToDouble(itemN)))}");


            Logger.EmptyLine();
            Logger.Close();
        }

        private static void Announce(string message)
        {
            Debug.WriteLine(new string('_', 30));
            Debug.WriteLine(message);
            Debug.WriteLine(new string('‾', 30));

        }
    }
}
