using System;
using System.Threading;

namespace MindfulnessProgram
{
    class ReflectionActivity : Activity
    {
        private string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public override string GetActivityName()
        {
            return "Reflection";
        }

        public override string GetDescription()
        {
            return "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }

        protected override void PerformActivity()
        {
            Random random = new Random();

            for (int i = 0; i < duration; i++)
            {
                Console.WriteLine(prompts[random.Next(prompts.Length)]);
                Pause(1);

                foreach (string question in questions)
                {
                    Console.WriteLine(question);
                    Pause(3);
                    ShowSpinner();
                }
            }
        }

        private void ShowSpinner()
        {
            string[] spinner = { "|", "/", "-", "\\" };

            for (int i = 0; i < 5; i++)
            {
                foreach (string symbol in spinner)
                {
                    Console.Write("\r{0} Reflecting {1} ", symbol, symbol);
                    Thread.Sleep(200);
                }
            }
            Console.WriteLine();
        }
    }
}
