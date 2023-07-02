using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
}

class Journal
{
    private List<JournalEntry> entries;
    private List<string> prompts;

    public Journal()
    {
        entries = new List<JournalEntry>();
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    public void AddEntry(string prompt, string response, string date)
    {
        JournalEntry entry = new JournalEntry
        {
            Prompt = prompt,
            Response = response,
            Date = date
        };
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"Date: {entry.Date}");
                writer.WriteLine($"Prompt: {entry.Prompt}");
                writer.WriteLine($"Response: {entry.Response}");
                writer.WriteLine();
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            JournalEntry entry = null;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Date: "))
                {
                    entry = new JournalEntry();
                    entry.Date = line.Substring(6);
                }
                else if (line.StartsWith("Prompt: "))
                {
                    entry.Prompt = line.Substring(8);
                }
                else if (line.StartsWith("Response: "))
                {
                    entry.Response = line.Substring(10);
                    entries.Add(entry);
                }
            }
        }
        Console.WriteLine("Journal loaded from file.");
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        string filename = "";

        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("New Entry:");
                    string prompt = journal.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    journal.AddEntry(prompt, response, date);
                    Console.WriteLine("Entry added.");
                    Console.WriteLine();
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    if (string.IsNullOrEmpty(filename))
                    {
                        Console.Write("Enter filename to save the journal: ");
                        filename = Console.ReadLine();
                    }
                    journal.SaveToFile(filename);
                    Console.WriteLine();
                    break;

                case "4":
                    Console.Write("Enter filename to load the journal: ");
                    filename = Console.ReadLine();
                    journal.LoadFromFile(filename);
                    Console.WriteLine();
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
