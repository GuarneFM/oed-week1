using System;
using System.Diagnostics;
using System.IO;
using ContainerLibrary;
using ContainerLibrary.Extensions;


namespace IfStatementsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Operations.Simple_If_Statement_2();
            Operations.If_Nullable_Property_IsNull_PropertyMatching();
        }
    }

    class Operations
    {
        /// <summary>
        /// Standard [if statement] working with null
        /// </summary>
        /// <remarks>
        /// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/if-else
        /// </remarks>
        public static void Simple_If_Statement_2()
        {

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

        }


        public static void If_Nullable_Property_IsNull_PropertyMatching()
        {
            
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
        }
    }
}
