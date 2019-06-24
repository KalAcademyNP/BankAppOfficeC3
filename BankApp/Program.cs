using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Welcome to my bank!");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create a new account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all accounts");
                Console.WriteLine("5. Print all transactions");

                Console.Write("Select an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the bank!");
                        return;
                    case "1":
                        Console.Write("Email Address: ");
                        var emailAddress = Console.ReadLine();
                        Console.Write("Account name: ");
                        var accountName = Console.ReadLine();
                        Console.Write("Initial Deposit: ");
                        var initialDeposit = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Select an accounttype: ");
                        var accountTypes = Enum.GetNames(typeof(AccountTypes));
                        for (int i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {accountTypes[i]}");
                        }
                        var accountType = Convert.ToInt32(Console.ReadLine());

                        var myAccount = Bank.CreateAccount(emailAddress, accountName, (AccountTypes)accountType, initialDeposit);
                        Console.WriteLine($"Account Number: {myAccount.AccountNumber}, " +
                            $"AName: {myAccount.AccountName}, " +
                            $"AType: {myAccount.AccountType}, " +
                            $"Email: {myAccount.EmailAddress}, " +
                            $"Balance: {myAccount.Balance:C}");

                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, amount);
                        Console.WriteLine("Deposit successful!");
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Account number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to withdraw: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNumber, amount);
                        Console.WriteLine("Withdrawal successful!");
                        break;
                    case "4":
                        PrintAllAccounts();

                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        var transactions = Bank.GetTransactionsByAccountNumber(accountNumber);
                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine($"TT: {transaction.TransactionType}, " +
                                $"TD: {transaction.TransactionDate}, " +
                                $"Amount: {transaction.Amount:C}");
                        }
                        break;
                    default:
                        break;

                }
            }

        }

        private static void PrintAllAccounts()
        {
            Console.WriteLine("Email Address: ");
            var emailAddress = Console.ReadLine();
            var accounts = Bank.GetAllAccountsByEmailAddress(emailAddress);
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}, " +
                    $"AName: {account.AccountName}, " +
                    $"AType: {account.AccountType}, " +
                    $"Email: {account.EmailAddress}, " +
                    $"Balance: {account.Balance:C}");
            }
        }
    }
}
