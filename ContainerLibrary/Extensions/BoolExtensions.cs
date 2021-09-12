using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContainerLibrary.Classes;

namespace ContainerLibrary.Extensions
{
    public static class BoolExtensions
    {

        /// <summary>
        /// Resharper really wants us to use a more conventional expression body member switch statement
        /// </summary>
        /// <param name="value"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string ToYesNoStringIs(this bool value, LanguageCode code) =>
            code is LanguageCode.English ? value ? "Yes" : "No" :
            code is LanguageCode.Spanish ? value ? "sí" : "No" :
            code is LanguageCode.Russian ? value ? "da" : "Net" :
            code is LanguageCode.Vietnamese ? value ? "Đúng" : "Không" :
            throw new ArgumentOutOfRangeException("Unknown language code");

        /// <summary>
        /// Resharper wants to make this a switch expression
        /// </summary>
        /// <param name="value"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string ToYesNoStringConventional(this bool value, LanguageCode code)
        {
            switch (code)
            {
                case LanguageCode.English:
                    return value ? "Yes" : "No";
                case LanguageCode.Spanish:
                    return value ? "sí" : "No";
                case LanguageCode.Russian:
                    return value ? "da" : "Net";
                case LanguageCode.Vietnamese:
                    return value ? "Đúng" : "Không";
                default:
                    throw new ArgumentOutOfRangeException("Unknown language code");
            }
        }


    }
}
