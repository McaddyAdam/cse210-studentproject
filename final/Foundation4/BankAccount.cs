using System;

public abstract class BankAccount
{
    protected double balance;

    public BankAccount(double initialBalance)
    {
        balance = initialBalance;
    }

    public abstract void Deposit(double amount);
    public abstract void Withdraw(double amount);
    public abstract double GetBalance();
}
