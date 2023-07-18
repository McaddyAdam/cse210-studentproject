using System;
using System.Threading;

namespace MindfulnessProgram
{
    abstract class Activity
    {
        protected int duration;

        public void Start()
        {
            Console.WriteLine("Starting {0} activity...", GetActivityName());
            Console.WriteLine(GetDescription());
            SetDuration();
            Console.WriteLine("Prepare to begin...");
            Pause(3);
            Console.WriteLine("Starting {0} activity for {1} seconds...", GetActivityName(), duration);
            PerformActivity();
            Console.WriteLine("Good job! You have completed the {0} activity for {1} seconds.", GetActivityName(), duration);
            Pause(3);
            Console.WriteLine();
        }

        public abstract string GetActivityName();

        public abstract string GetDescription();

        protected void SetDuration()
        {
            Console.Write("Enter the duration in seconds: ");
            duration = int.Parse(Console.ReadLine());
        }

        protected void Pause(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write("Pause: {0}...", i);
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected abstract void PerformActivity();
    }
}
