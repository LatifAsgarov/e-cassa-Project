using System;
using System.Collections.Generic;

public class VirtualWallet
{
    private List<Account> accounts;
    private string walletName;

    public VirtualWallet(string name, List<Account> accounts = null)
    {
        walletName = name;
        this.accounts = accounts ?? new List<Account>();
    }

    public void CreateVirtualWallet(string name)
    {
        accounts = new List<Account>();
        walletName = name;
    }

    public void AddAccount(Account account)
    {
        accounts.Add(account);
    }

    public void ShowAccountDetails(int accountNumber)
    {
        Account account = accounts.Find(a => a.AccountNumber == accountNumber);
        if (account != null)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Balance: {account.Balance} {account.Currency}");
            Console.WriteLine($"Description: {account.Description}");
            Console.WriteLine($"Status: {(account.IsActive ? "Active" : "Inactive")}");
        }
        else
        {
            Console.WriteLine($"Account {accountNumber} not found.");
        }
    }

    public void ShowAllAccounts()
    {
        Console.WriteLine($"Accounts in {walletName}:");
        foreach (Account account in accounts)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Balance: {account.Balance} {account.Currency}");
            Console.WriteLine($"Description: {account.Description}");
            Console.WriteLine($"Status: {(account.IsActive ? "Active" : "Inactive")}");
            Console.WriteLine();
        }
    }

    public void Deposit(int accountNumber, decimal amount)
    {
        Account account = accounts.Find(a => a.AccountNumber == accountNumber);
        if (account != null)
        {
            account.Deposit(amount);
            Console.WriteLine($"Deposit of {amount} {account.Currency} to account {accountNumber} successful.");
        }
        else
        {
            Console.WriteLine($"Account {accountNumber} not found.");
        }
    }

    public void Withdraw(int accountNumber, decimal amount)
    {
        Account account = accounts.Find(a => a.AccountNumber == accountNumber);
        if (account != null)
        {
            if (account.Withdraw(amount))
            {
                Console.WriteLine($"Withdrawal of {amount} {account.Currency} from account {accountNumber} successful.");
            }
            else
            {
                Console.WriteLine($"Insufficient balance in account {accountNumber}.");
            }
        }
        else
        {
            Console.WriteLine($"Account {accountNumber} not found.");
        }
    }

    public void Transfer(int fromAccountNumber, int toAccountNumber, decimal amount)
    {
        Account fromAccount = accounts.Find(a => a.AccountNumber == fromAccountNumber);
        Account toAccount = accounts.Find(a => a.AccountNumber == toAccountNumber);

        if (fromAccount == null)
        {
            Console.WriteLine($"Account {fromAccountNumber} not found.");
        }
        else if (toAccount == null)
        {
            Console.WriteLine($"Account {toAccountNumber} not found.");
        }
        else if (fromAccount.Withdraw(amount))
        {
            toAccount.Deposit(amount);
            Console.WriteLine($"Transfer of {amount} {fromAccount.Currency} from account {fromAccountNumber} to account {toAccountNumber} successful.");
        }
        else
        {
            Console.WriteLine($"Insufficient balance in account {fromAccountNumber}.");
        }
    }
}
