using System;

public class Account
{
    public int AccountNumber { get; private set; }
    public decimal Balance { get; protected set; }

    public Account(int accountNumber, decimal balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposit of {amount} successful. New balance: {Balance}");
    }

    public virtual void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawal of {amount} successful. New balance: {Balance}");
        }
        else
        {
            Console.WriteLine($"Withdrawal of {amount} failed. Insufficient funds.");
        }
    }
}
