using System;

class Program
{
    static void Main()
    {
        // Testing Abstraction (Banking Application)
        BankAccount account = new SavingsAccount(1000, 0.05);
        Console.WriteLine("Initial Balance: " + account.GetBalance());
        account.Deposit(500);
        Console.WriteLine("Balance after deposit: " + account.GetBalance());
        account.Withdraw(200);
        Console.WriteLine("Balance after withdrawal: " + account.GetBalance());

        // Testing Encapsulation (Healthcare Application)
        PatientRecords patient = new PatientRecords();
        patient.SetMedicalHistory("Allergies: Peanuts");
        patient.SetTestResults("Blood Pressure: Normal");
        patient.SetTreatments("Prescription: Antibiotics");
        patient.DisplayMedicalRecords();
    }
}
