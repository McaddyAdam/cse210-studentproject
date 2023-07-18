using System;

namespace MindfulnessProgram
{
    class MindfulnessApp
    {
        private BreathingActivity breathingActivity;
        private ReflectionActivity reflectionActivity;
        private ListingActivity listingActivity;

        public MindfulnessApp()
        {
            breathingActivity = new BreathingActivity();
            reflectionActivity = new ReflectionActivity();
            listingActivity = new ListingActivity();
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        breathingActivity.Start();
                        break;
                    case "2":
                        reflectionActivity.Start();
                        break;
                    case "3":
                        listingActivity.Start();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
