public class CurrentAccount : Account
{
    public CurrentAccount(int accountNumber, decimal balance) : base(accountNumber, balance)
    {
    }

    // Override the Withdraw method to allow overdraft
    public override void Withdraw(decimal amount)
    {
        // Allow overdrafts (negative balance)
        Balance -= amount;
        Console.WriteLine($"Withdrawal of {amount} successful. New balance: {Balance}");
    }
}
