using System.Collections.Generic;
using Test.Data.Models;

namespace Test.Data.Interfaces
{
    public interface IAccount
    {
        IEnumerable<Account> allAccounts { get; }
        public void createAccount(Account account);
        public bool isCorrect(Account account);
    }
}
