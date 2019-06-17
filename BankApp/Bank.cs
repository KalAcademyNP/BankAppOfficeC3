using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    static class Bank
    {
        private static readonly List<Account> accounts = new List<Account>();

        public static Account CreateAccount(string emailAddress, string accountName, 
            AccountTypes accountType = AccountTypes.Checking, decimal initialDeposit = 0)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountName = accountName,
                AccountType = accountType
            };
            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
            }
            accounts.Add(account);
            return account;
        }

        public static IEnumerable<Account> GetAllAccountsByEmailAddress(string emailAddress)
        {

        }
    }
}
