using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace ActiveDirectoryDemo
{
    /// <summary>
    /// No guarantees there will not be a permission
    /// </summary>
    public class UserDetails
    {
        /// <summary>
        /// Current user first and last name
        /// </summary>
        public static string UserName => $"{UserPrincipal.Current.GivenName.ToTitleCase()} {UserPrincipal.Current.Surname.ToTitleCase()}";
        /// <summary>
        /// Current user first name
        /// </summary>
        public static string FirstName => $"{UserPrincipal.Current.GivenName.ToTitleCase()}";
        /// <summary>
        /// Current user last name
        /// </summary>
        public static string LastName => $"{UserPrincipal.Current.Surname.ToTitleCase()}";
        /// <summary>
        /// Current user email
        /// </summary>
        public static string EmailAddress => UserPrincipal.Current.EmailAddress;
        /// <summary>
        /// Current user office phone number
        /// </summary>
        public static string OfficePhone => UserPrincipal.Current.VoiceTelephoneNumber;
        /// <summary>
        /// Current user's DN
        /// </summary>
        public static string DistinguishedName => UserPrincipal.Current.DistinguishedName;
        /// <summary>
        /// Current user authorized groups
        /// </summary>
        /// <remarks>
        /// Time intensive
        /// </remarks>
        public static List<Principal> AuthorizedPrincipals => UserPrincipal.Current.GetAuthorizationGroups().ToList();
        /// <summary>
        /// Last login formatted
        /// </summary>
        public static string LastLoginFormatted => UserPrincipal.Current.LastLogon != null ? UserPrincipal.Current.LastLogon.Value.ToString("F") : "";

    }
}
