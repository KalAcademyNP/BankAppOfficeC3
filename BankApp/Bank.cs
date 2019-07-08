using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    static class Bank
    {
        private static BankContext db = new BankContext();

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
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        /// <summary>
        /// Get all the accounts associated with the email address
        /// </summary>
        /// <param name="emailAddress">Email address of the user</param>
        /// <returns>List of accounts</returns>
        /// <exception cref="ArgumentNullException" />
        /// 
        public static IEnumerable<Account> GetAllAccountsByEmailAddress(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(emailAddress.Trim()))
            {
                throw new ArgumentNullException("EmailAddress", "Email Address is required!");
            }

            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
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

            db.Transactions.Add(transaction);
            db.SaveChanges();
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

            db.Transactions.Add(transaction);
            db.SaveChanges();

        }

        public static Account GetAccountByAccountNumber(int accountNumber)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new ArgumentException("Invalid Account Number!");
            }

            return account;
        }


        public static IEnumerable<Transaction> GetTransactionsByAccountNumber(int accountNumber)
        {
            return db.Transactions
                    .Where(t => t.AccountNumber == accountNumber)
                    .OrderByDescending(t => t.TransactionDate);
        }
    }
}
