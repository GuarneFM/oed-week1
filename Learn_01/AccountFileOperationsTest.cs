using System.Linq;
using FileLibraryCore.Classes;
using Learn_01_Week_2.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Learn_01_Week_2
{
    [TestClass]
    public class AccountFileOperationsTest
    {
        /// <summary>
        /// Passing test
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.AccountFileOps)]
        public void First()
        {
            var identifier = 1221412;
            var accountList = AccountOperations.ReadClean();

            var account = accountList.FirstOrDefault(Account => Account.Id == identifier);
            Assert.IsNotNull(account);
            account.Active = !account.Active;
            
            AccountOperations.Write(accountList);

        }

        /// <summary>
        /// Failing code for testing :-)
        /// </summary>
        [TestMethod]
        [Ignore]
        [TestTraits(Trait.PlaceHolder)]
        public void Second()
        {
            var (success, accountList) = AccountOperations.Read();

            if (success)
            {
                var identifier = 1221412;

                var account = accountList.FirstOrDefault(Account => Account.Id == identifier);
                if (account != null)
                {
                    account.Active = true;
                }

                AccountOperations.Write(accountList);
            }
            else
            {
                // do not use the list
            }
        }


    }
}