using System;
using System.Collections.Generic;

namespace EternalQuestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestManager questManager = new QuestManager();
            questManager.LoadGoals(); // Load previously saved goals

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Eternal Quest Program");
                Console.WriteLine("---------------------");
                Console.WriteLine("1. Create new goal");
                Console.WriteLine("2. Record event");
                Console.WriteLine("3. Display goals");
                Console.WriteLine("4. Display score");
                Console.WriteLine("5. Save goals");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        questManager.CreateGoal();
                        break;
                    case "2":
                        questManager.RecordEvent();
                        break;
                    case "3":
                        questManager.DisplayGoals();
                        break;
                    case "4":
                        questManager.DisplayScore();
                        break;
                    case "5":
                        questManager.SaveGoals();
                        break;
                    case "6":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }

    public class QuestManager
    {
        private List<Goal> goals;
        private int score;

        public QuestManager()
        {
            goals = new List<Goal>();
            score = 0;
        }

        public void LoadGoals()
        {
            // Load goals from storage (e.g., file or database) and populate the "goals" list
            // This is just a placeholder method for demonstration purposes
            goals.Add(new SimpleGoal("Run a marathon", 1000));
            goals.Add(new EternalGoal("Read scriptures", 100));
            goals.Add(new ChecklistGoal("Attend the temple", 50, 10, 500));
        }

        public void CreateGoal()
        {
            Console.WriteLine("Goal Types");
            Console.WriteLine("-----------");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Enter goal type: ");
            string goalTypeChoice = Console.ReadLine();

            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();

            switch (goalTypeChoice)
            {
                case "1":
                    Console.Write("Enter goal value: ");
                    int value = int.Parse(Console.ReadLine());
                    goals.Add(new SimpleGoal(description, value));
                    Console.WriteLine("Simple goal created successfully.");
                    break;
                case "2":
                    Console.Write("Enter goal value: ");
                    value = int.Parse(Console.ReadLine());
                    goals.Add(new EternalGoal(description, value));
                    Console.WriteLine("Eternal goal created successfully.");
                    break;
                case "3":
                    Console.Write("Enter goal value per completion: ");
                    int valuePerCompletion = int.Parse(Console.ReadLine());
                    Console.Write("Enter number of completions required: ");
                    int requiredCompletions = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus value: ");
                    int bonusValue = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(description, valuePerCompletion, requiredCompletions, bonusValue));
                    Console.WriteLine("Checklist goal created successfully.");
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        public void RecordEvent()
        {
            Console.WriteLine("Select a goal to record an event:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i]}");
            }

            Console.Write("Enter goal number: ");
            int goalNumber = int.Parse(Console.ReadLine()) - 1;

            if (goalNumber >= 0 && goalNumber < goals.Count)
            {
                Goal selectedGoal = goals[goalNumber];
                score += selectedGoal.RecordEvent();
                Console.WriteLine("Event recorded successfully.");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        public void DisplayGoals()
        {
            Console.WriteLine("Goals");
            Console.WriteLine("-----");
            for (int i = 0; i < goals.Count; i++)
            {
                Goal goal = goals[i];
                string completionStatus = goal.IsCompleted ? "[X]" : "[ ]";
                string details = goal is ChecklistGoal ? $"Completed {((ChecklistGoal)goal).Completions}/{((ChecklistGoal)goal).RequiredCompletions} times" : string.Empty;
                Console.WriteLine($"{i + 1}. {completionStatus} {goal.Description} {details}");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"Score: {score}");
        }

        public void SaveGoals()
        {
            // Save goals to storage (e.g., file or database) for future use
            // This is just a placeholder method for demonstration purposes
            Console.WriteLine("Goals saved successfully.");
        }
    }

    public abstract class Goal
    {
        public string Description { get; }

        public bool IsCompleted { get; protected set; }

        public Goal(string description)
        {
            Description = description;
            IsCompleted = false;
        }

        public abstract int RecordEvent();
    }

    public class SimpleGoal : Goal
    {
        public int Value { get; }

        public SimpleGoal(string description, int value) : base(description)
        {
            Value = value;
        }

        public override int RecordEvent()
        {
            IsCompleted = true;
            return Value;
        }
    }

    public class EternalGoal : Goal
    {
        public int Value { get; }

        public EternalGoal(string description, int value) : base(description)
        {
            Value = value;
        }

        public override int RecordEvent()
        {
            return Value;
        }
    }

    public class ChecklistGoal : Goal
    {
        public int ValuePerCompletion { get; }
        public int RequiredCompletions { get; }
        public int BonusValue { get; }
        public int Completions { get; private set; }

        public ChecklistGoal(string description, int valuePerCompletion, int requiredCompletions, int bonusValue) : base(description)
        {
            ValuePerCompletion = valuePerCompletion;
            RequiredCompletions = requiredCompletions;
            BonusValue = bonusValue;
            Completions = 0;
        }

        public override int RecordEvent()
        {
            Completions++;
            if (Completions >= RequiredCompletions)
            {
                IsCompleted = true;
                return ValuePerCompletion * RequiredCompletions + BonusValue;
            }
            else
            {
                return ValuePerCompletion;
            }
        }
    }
}
