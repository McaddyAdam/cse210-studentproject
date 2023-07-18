using System;
using System.Threading;

namespace MindfulnessProgram
{
    class BreathingActivity : Activity
    {
        public override string GetActivityName()
        {
            return "Breathing";
        }

        public override string GetDescription()
        {
            return "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        protected override void PerformActivity()
        {
            for (int i = 0; i < duration; i++)
            {
                Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
                Pause(1);
            }
        }
    }
}
