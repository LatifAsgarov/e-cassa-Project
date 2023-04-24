using System;
using System.Collections.Generic;

public class List
{
    private List<VirtualWallet> wallets;

    public List()
    {
        wallets = new List<VirtualWallet>();
    }

    public void CreateVirtualWallet(string name)
    {
        VirtualWallet wallet = new VirtualWallet(name);
        wallets.Add(wallet);
        Console.WriteLine($"E-wallet {name} created successfully.");
    }

    public void AddAccount(int walletIndex, Account account)
    {
        VirtualWallet wallet = wallets[walletIndex];
        wallet.AddAccount(account);
        Console.WriteLine($"Account {account.AccountNumber} added successfully to {wallet.WalletName}.");
    }

    public void ShowAccountDetails(int walletIndex, int accountNumber)
    {
        VirtualWallet wallet = wallets[walletIndex];
        wallet.ShowAccountDetails(accountNumber);
    }

    public void ShowAllAccounts(int walletIndex)
    {
        VirtualWallet wallet = wallets[walletIndex];
        wallet.ShowAllAccounts();
    }

    public void Deposit(int walletIndex, int accountNumber, decimal amount)
    {
        VirtualWallet wallet = wallets[walletIndex];
        wallet.Deposit(accountNumber, amount);
    }

    public void Withdraw(int walletIndex, int accountNumber, decimal amount)
    {
        VirtualWallet wallet = wallets[walletIndex];
        wallet.Withdraw(accountNumber, amount);
    }

    public void Transfer(int walletIndex, int fromAccountNumber, int toAccountNumber, decimal amount)
    {
        VirtualWallet wallet = wallets[walletIndex];
        wallet.Transfer(fromAccountNumber, toAccountNumber, amount);
    }

    public int GetWalletIndex(string walletName)
    {
        int index = -1;
        for (int i = 0; i < wallets.Count; i++)
        {
            if (wallets[i].WalletName == walletName)
            {
                index = i;
                break;
            }
        }
        return index;
    }
}
