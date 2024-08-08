using System;
using System.Collections.Generic;

using test;

   

    public class Program
    {
        static List<Account> accounts = new List<Account>();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an operation: View accounts, Create an account, Deposit, Withdraw, Exit");
                string? choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "view accounts":
                        ViewAccounts();
                        break;
                    case "create an account":
                        CreateAccount();
                        break;
                    case "deposit":
                        Deposit();
                        break;
                    case "withdraw":
                    Withdraw();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ViewAccounts()
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts found.");
            }
            else
            {
                foreach (var account in accounts)
                {
                    Console.WriteLine(account);
                }
            }
        }

        static void CreateAccount()
           {
            Console.Write("Enter the account owner's name: ");
            string ownerName = Console.ReadLine();
            if (string.IsNullOrEmpty(ownerName))
            {
                Console.WriteLine("Owner's name cannot be empty.");
                return;
            }

            Console.Write("Enter the initial account balance: ");
            if (double.TryParse(Console.ReadLine(), out double initialBalance) && initialBalance >= Account.MinimumInitialBalance)
            {
                Account newAccount = new Account(ownerName, initialBalance);
                accounts.Add(newAccount);
                Console.WriteLine("Account created successfully.");
                Console.WriteLine(newAccount);
            }
            else
            {
                Console.WriteLine($"Initial balance must be at least {Account.MinimumInitialBalance}.");
            }
        }

        static void Deposit()
        {
            Console.Write("Enter the account number: ");
            if (int.TryParse(Console.ReadLine(), out int accountNumber))
            {
          Account account = accounts.Find(acc => acc.AccountNumber == accountNumber);
                if (account == null)
                {
                    Console.WriteLine("Account not found.");
                    return;
                }

                Console.Write("Enter the deposit amount: ");
                if (double.TryParse(Console.ReadLine(), out double depositAmount) && depositAmount > 0)
                {
                    account.Deposit(depositAmount);
                    Console.WriteLine("Deposit successful.");
                    Console.WriteLine(account);
                }
                else
                {
                    Console.WriteLine("Invalid deposit amount.");
                }
            }
            else
            {
                Console.WriteLine("Invalid account number.");
            }
        }

        static void Withdraw()
        {
            Console.Write("Enter the account number: ");
          if (int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                Account account = accounts.Find(acc => acc.AccountNumber == accountNumber);
                if (account == null)
                {
                    Console.WriteLine("Account not found.");
                    return;
                }

                Console.Write("Enter the withdrawal amount: ");
                if (double.TryParse(Console.ReadLine(), out double withdrawAmount) && withdrawAmount > 0)
                {
                    if (withdrawAmount <= account.Balance)
                    {
                        account.Withdraw(withdrawAmount);
                        Console.WriteLine("Withdrawal successful.");
                        Console.WriteLine(account);
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid withdrawal amount.");
                }
            }
            else
            {
               Console.WriteLine("Invalid account number.");
            }
        }
    }
