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

        // Testing Inheritance (Geometry Library)
        GeometryShape shape1 = new Circle(5);
        Console.WriteLine("Circle Area: " + shape1.CalculateArea());
        Console.WriteLine("Circle Perimeter: " + shape1.CalculatePerimeter());

        // Testing Polymorphism (Multimedia Processing Application)
        MultimediaItem[] items = new MultimediaItem[]
        {
            new Image(),
            new Video(),
            new Audio()
        };

        foreach (var item in items)
        {
            item.Process();
        }
    }
}
