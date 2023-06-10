using System;

class BreathingActivity:Activity
{
    int _breathLenght;

    public BreathingActivity()
    {
        setBreathLenght(7);

        int duration;

        SetName("Breathing Activity");
        SetDescription("This Activity will help you relax by walking through breathing in and out slowly. Clear your mind and focus on your breathing.");

        Console.WriteLine("\nHow long, in seconds would you like for your session to be?");
        duration = int.Parse(Console.ReadLine());

        SetDuration(duration);

        Console.Clear();
        DisplayStartMessage();
    }
    public void setBreathLenght(int breathingPause)
    {
        _breathLenght = breathingPause;
    }

    public void GuidedBreathing()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        DateTime currentTime = DateTime.Now;

        GetReadySpinner(5);

        while (currentTime < endTime)
        {
            BreathIn();
            BreathOut();
            currentTime = DateTime.Now;
        }

        DisplayEndMessage();
        Thread.Sleep(4000);
    }

    private void BreathIn()
    {
        Console.WriteLine("\n\nBreath in");

        for(int x = 0; x < _breathLenght; x++)
        {
            Thread.Sleep(1000);
            Console.Write(".");
        }
    }

    private void BreathOut()
    {
        Console.Write("\nBreath out....... ");

        for(int x = 0; x < _breathLenght; x++)
        {
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write();
        }
    }

}