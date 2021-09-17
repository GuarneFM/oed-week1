using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ContainerLibrary.Extensions;
using ContainerLibrary.HelperClasses;

// ReSharper disable once CheckNamespace
namespace PlayGroundConsoleNetCoreApp
{
    partial class Program
    {


        /// <summary>
        /// Execute as first code 
        /// </summary>
        [ModuleInitializer]
        public static void Howdy()
        {
            Debug.WriteLine(new string('_', 30));
            Debug.WriteLine($"{"KarenPayne".SplitCamelCase()} ¯\\_(ツ)_/¯");
            Debug.WriteLine(new string('‾', 30));
        }
    }

}
