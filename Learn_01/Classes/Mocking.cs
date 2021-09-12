using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Learn_01_Week_2.Classes
{
    public class Mocking
    {
        
        /// <summary>
        /// Create some random files in <see cref="Initialization"/> so we are sure there are some files to work on
        /// </summary>
        public static readonly List<string> DummyFileNameList = new()
        {
            "fluid.html",
            "index.html",
            "dummy1.md",
            "Excel1.xlsx",
            "Data.xlsx",
            "Excel2.xls",
            "Customers.xls",
            "iccTrans.json",
            "login.html",
            "anotherDummy.md",
            "messages.json"
        };


        public static void Initialization()
        {
            try
            {
                foreach (var fileName in DummyFileNameList.Where(fileName => !File.Exists(fileName)))
                {
                    using var _ = File.Create(fileName);
                }
            }
            catch (Exception exception)
            {
                /*
                 * For class we should never land here but let's be cautious 
                 */
                Debug.WriteLine(exception.Message);
            }
        }
    }
    
}
