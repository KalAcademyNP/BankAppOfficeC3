using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    static class Bank
    {
        private static readonly List<Account> accounts = new List<Account>();
        private static readonly List<Transaction> transactions = new List<Transaction>();

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
            return accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = "Bank deposit",
                Amount = amount,
                AccountNumber = accountNumber,
                TransactionType = TypeOfTransaction.Credit
            };

            transactions.Add(transaction);
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            account.Withdraw(amount);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = "Bank Withdrawal",
                Amount = amount,
                AccountNumber = accountNumber,
                TransactionType = TypeOfTransaction.Debit
            };

            transactions.Add(transaction);

        }

        public static Account GetAccountByAccountNumber(int accountNumber)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                return null;
            }

            return account;
        }


        public static IEnumerable<Transaction> GetTransactionsByAccountNumber(int accountNumber)
        {
            return transactions
                    .Where(t => t.AccountNumber == accountNumber)
                    .OrderByDescending(t => t.TransactionDate);
        }
    }
}
