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
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        break;

                }
            }

        }
    }
}
