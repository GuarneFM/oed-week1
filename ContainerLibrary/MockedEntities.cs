using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContainerLibrary.Classes;

namespace ContainerLibrary
{
    public class MockedEntities
    {
        public static  Employee nullEmployee() => null;
        public static Employee notNullEmployee() => new();
        public static Customer GetCustomer() => new();
    }
}
