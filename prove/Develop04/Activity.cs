using System;

class Activity
{

    string_activityName;
    string_activityDescription;
    int_activityDuration;

    public string GetName()
    {
        return _activityName;
    }
    public void SetName(string name)
    {
        _activityName = name;
    }

    public string GetDescription()
    {
        return _activityDescription;
    }
    public void SetDescription(string description)
    {
        _activityDescription = description;
    }

    public int GetDuration()
    {
        return _activityDuration;
    }
    public void SetDuration(int duration)
    {
        _activityDuration = duration;
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"Welcome to the {GetName()}");
        Console.WriteLine($"\n\n{GetDescription()}");
    }
    public void DisplayEndMessage()
    {
        Console.WriteLine($"\nGreat job on the {GetName()}");
    }
    public void GetReadySpinner(int time)
    {
        DateTime startTime = DateTime.Now;
        DateTime entTime = startTime.AddSeconds(time);

        DateTime currentTime = DateTime.Now;

        Console.WriteLine("Get Ready...");
        while (currentTime < entTime)
        {
            Console.Write("--");
            Thread.Sleep(500);
            Console.Write("\b\b");
            Console.Write("\\ ");
            Thread.Sleep(500);
            Console.Write("\b\b");
            Console.Write("| ");
            Thread.Sleep(500);
            Console.Write("\b\b");
            Console.Write("/ ");
            Thread.Sleep(500);
            Console.Write("\b\b");
            currentTime = DateTime.Now;
        }

        Console.Write("Go!");
        Thread.Sleep(500);

    }
}