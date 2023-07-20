using System;

public class PatientRecords
{
    private string medicalHistory;
    private string testResults;
    private string treatments;

    public void SetMedicalHistory(string history)
    {
        medicalHistory = history;
    }

    public void SetTestResults(string results)
    {
        testResults = results;
    }

    public void SetTreatments(string treatments)
    {
        this.treatments = treatments;
    }

    public void DisplayMedicalRecords()
    {
        Console.WriteLine("Medical History: " + medicalHistory);
        Console.WriteLine("Test Results: " + testResults);
        Console.WriteLine("Treatments: " + treatments);
    }
}
