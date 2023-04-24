using System;
namespace VirtualWallet
{
    class Program
    {
        static VirtualWallet virtualWallet = new VirtualWallet();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Virtual Wallet app!");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Create a new e-wallet");
                Console.WriteLine("2. Show all e-wallets");
                Console.WriteLine("3. Select an e-wallet");
                Console.WriteLine("4. Add a new account");
                Console.WriteLine("5. Show all accounts in an e-wallet");
                Console.WriteLine("6. Select an account");
                Console.WriteLine("7. Show account details");
                Console.WriteLine("8. Deposit money into an account");
                Console.WriteLine("9. Withdraw money from an account");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice (1-10): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter a name for your e-wallet: ");
                        string name = Console.ReadLine();
                        virtualWallet.CreateVirtualWallet(name);
                        Console.WriteLine($"E-wallet {name} created successfully.");
                        break;

                    case "2":
                        virtualWallet.ShowAllVirtualWallets();
                        break;

                    case "3":
                        Console.Write("Enter the name of the e-wallet you want to select: ");
                        string selectedWalletName = Console.ReadLine();
                        virtualWallet.SelectVirtualWallet(selectedWalletName);
                        break;

                    case "4":
                        Console.Write("Enter the account number: ");
                        int accountNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter the account balance: ");
                        decimal balance = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter the currency: ");
                        string currency = Console.ReadLine();
                        Console.Write("Enter the description: ");
                        string description = Console.ReadLine();
                        virtualWallet.AddAccount(accountNumber, balance, currency, description);
                        Console.WriteLine($"Account {accountNumber} added successfully to {virtualWallet.SelectedVirtualWallet.Name}.");
                        break;

                    case "5":
                        virtualWallet.ShowAllAccounts();
                        break;

                    case "6":
                        Console.Write("Enter the account number: ");
                        int selectedAccountNumber = int.Parse(Console.ReadLine());
                        virtualWallet.SelectAccount(selectedAccountNumber);
                        break;

                    case "7":
                        virtualWallet.ShowAccountDetails();
                        break;

                    case "8":
                        Console.Write("Enter the amount to deposit: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        virtualWallet.DepositMoney(depositAmount);
                        Console.WriteLine($"Amount {depositAmount} deposited successfully into account {virtualWallet.SelectedAccount.AccountNumber}.");
                        break;

                    case "9":
                        Console.Write("Enter the amount to withdraw: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                        virtualWallet.WithdrawMoney(withdrawAmount);
                        Console.WriteLine($"Amount {withdrawAmount} withdrawn successfully from account {virtualWallet.SelectedAccount.AccountNumber}.");
                        break;

                    case "10":
                        Console.WriteLine("Thank you for using the Virtual Wallet app. Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 10.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
