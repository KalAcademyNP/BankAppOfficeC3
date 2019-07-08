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

        #region Properties
        /// <summary>
        /// Account number of the account
        /// </summary>
        public int AccountNumber { get;  set; }
        /// <summary>
        /// Money in the account
        /// </summary>
        public decimal Balance { get;  set; }
        public string EmailAddress { get; set; }

        public AccountTypes AccountType { get; set; }
        public DateTime CreatedDate { get;  set; }
        public string AccountName { get; set; }
        #endregion

        public Account()
        {
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
            if (amount > Balance)
            {
                throw new NSFException();
            }
            Balance -= amount;
            return Balance;
        }

        #endregion


    }
}
