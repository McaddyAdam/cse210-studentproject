using System;

public class SavingsAccount : BankAccount
{
    private double interestRate;

    public SavingsAccount(double initialBalance, double interestRate) : base(initialBalance)
    {
        this.interestRate = interestRate;
    }

    public override void Deposit(double amount)
    {
        balance += amount;
    }

    public override void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }

    public override double GetBalance()
    {
        return balance + balance * interestRate;
    }
}
