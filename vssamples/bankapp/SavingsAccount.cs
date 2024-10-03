public class SavingsAccount : Account
{
    public decimal InterestRate { get; private set; }

    public SavingsAccount(int accountNumber, decimal balance, decimal interestRate)
        : base(accountNumber, balance)
    {
        InterestRate = interestRate;
    }

    // Override the Withdraw method to enforce a minimum balance of 500
    public override void Withdraw(decimal amount)
    {
        if (Balance - amount >= 500)
        {
            base.Withdraw(amount);
        }
        else
        {
            Console.WriteLine($"Withdrawal of {amount} failed. Minimum balance of 500 must be maintained.");
        }
    }
}
