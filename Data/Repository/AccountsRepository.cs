using System.Collections.Generic;
using System.Linq;
using Test.Data.Interfaces;
using Test.Data.Models;

namespace Test.Data.Repository
{
    public class AccountsRepository : IAccount
    {
        private readonly AppDBContent appDBContent;

        public AccountsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Account> allAccounts => appDBContent.Accounts;
 

        public void createAccount(Account account)
        {
            appDBContent.Accounts.Add(account);
            appDBContent.SaveChanges();
        }

        public bool isCorrect(Account account)
        {
            var login = appDBContent.Accounts.FirstOrDefault(a => a.login == account.login);
            if (login.password == account.password)
                return true;
            return false;
        }
    }
}
