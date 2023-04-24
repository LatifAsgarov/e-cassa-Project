
using System;


public class Account
{
    // Properties
    public int AccountNumber { get; }
    public decimal Balance { get; private set; }
    public string Currency { get; }
    public string Description { get; }
    public bool IsActive { get; private set; }

    // Constructor
    public Account(int accountNumber, decimal balance, string currency, string description, bool isActive)
    {
        AccountNumber = accountNumber;
        Balance = balance;
        Currency = currency;
        Description = description;
        IsActive = isActive;
    }

    // Methods
    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public override string ToString()
    {
        return string.Format("{0,-10} {1,10:C} {2,-5} {3,-20} {4}", AccountNumber, Balance, Currency, Description, IsActive ? "Active" : "Deactive");
    }
}
