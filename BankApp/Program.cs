using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine($"Account Number: {myAccount.AccountNumber}, " +
            //    $"AName: {myAccount.AccountName}, " +
            //    $"Email: {myAccount.EmailAddress}, " +
            //    $"Balance: {myAccount.Balance:C}");

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
