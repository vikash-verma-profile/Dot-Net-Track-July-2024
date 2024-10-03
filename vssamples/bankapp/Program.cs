public class Program
{
    public static void Main()
    {
        // Create a SavingsAccount and perform operations
        SavingsAccount savings = new SavingsAccount(12345, 1000, 0.05m);
        savings.Deposit(500);    // Adds 500 to the account
        savings.Withdraw(200);   // Withdraws 200 successfully
        savings.Withdraw(1000);  // Should fail due to minimum balance requirement

        Console.WriteLine(); // Line break for readability

        // Create a CurrentAccount and perform operations
        CurrentAccount current = new CurrentAccount(54321, 1000);
        current.Deposit(1000);   // Adds 1000 to the account
        current.Withdraw(2500);  // Allows overdraft, balance goes negative
    }
}
