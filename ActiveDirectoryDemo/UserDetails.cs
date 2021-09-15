using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace ActiveDirectoryDemo
{
    public class UserDetails
    {

        public static string UserName => $"{UserPrincipal.Current.GivenName.ToTitleCase()} {UserPrincipal.Current.Surname.ToTitleCase()}";
        public static string FirstName => $"{UserPrincipal.Current.GivenName.ToTitleCase()}";
        public static string LastName => $"{UserPrincipal.Current.Surname.ToTitleCase()}";
        public static string EmailAddress => UserPrincipal.Current.EmailAddress;
        public static string OfficePhone => UserPrincipal.Current.VoiceTelephoneNumber;
        public static string DistinguishedName => UserPrincipal.Current.DistinguishedName;
        public static List<Principal> AuthorizedPrincipals => UserPrincipal.Current.GetAuthorizationGroups().ToList();
        public static string LastLoginFormatted => UserPrincipal.Current.LastLogon != null ? UserPrincipal.Current.LastLogon.Value.ToString("F") : "";

    }
}
