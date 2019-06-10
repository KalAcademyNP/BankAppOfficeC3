using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    enum AccountTypes
    {
        Checking,
        Savings,
        CD,
        Loan
    }
    
    /// <summary>
    /// This class defines a bank
    /// Account
    /// </summary>
    class Account
    {
        private static int lastAccountNumber = 0;

        #region Properties
        /// <summary>
        /// Account number of the account
        /// </summary>
        public int AccountNumber { get; private set; }
        /// <summary>
        /// Money in the account
        /// </summary>
        public decimal Balance { get; private set; }
        public string EmailAddress { get; set; }

        public AccountTypes AccountType { get; set; }
        public DateTime CreatedDate { get; private set; }
        public string AccountName { get; set; }
        #endregion

        public Account()
        {
            AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.Now;
        }

        #region Methods

        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount">Amount to be deposited</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public decimal Withdraw(decimal amount)
        {
            Balance -= amount;
            return Balance;
        }

        #endregion


    }
}
