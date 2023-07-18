using System;
using System.Threading;

namespace MindfulnessProgram
{
    class ListingActivity : Activity
    {
        private string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public override string GetActivityName()
        {
            return "Listing";
        }

        public override string GetDescription()
        {
            return "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        protected override void PerformActivity()
        {
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Length)];

            Console.WriteLine(prompt);
            Pause(3);
            Console.WriteLine("Think about the prompt and start listing items:");

            DateTime endTime = DateTime.Now.AddSeconds(duration);
            int count = 0;
            string item;

            while (DateTime.Now < endTime)
            {
                Console.Write("Item {0}: ", count + 1);
                item = Console.ReadLine();
                count++;
            }

            Console.WriteLine("You have listed {0} items.", count);
        }
    }
}
