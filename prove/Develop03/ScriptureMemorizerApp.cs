using System;

namespace ScriptureMemorizer
{
    class ScriptureMemorizerApp
    {
        private Scripture scripture;

        public void Run()
        {
            InitializeScripture();
            DisplayScripture();

            while (!AllWordsHidden())
            {
                Console.WriteLine("\nPress ENTER to hide more words or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
                    break;

                HideRandomWords();
                Console.Clear();
                DisplayScripture();
            }
        }

        private void InitializeScripture()
        {
            string reference = "John 3:16";
            string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
            scripture = new Scripture(reference, text);
        }

        private void DisplayScripture()
        {
            Console.WriteLine($"Reference: {scripture.Reference}");
            string[] words = scripture.Text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (scripture.HiddenWords[i])
                    Console.Write("**** ");
                else
                    Console.Write($"{words[i]} ");
            }
        }

        private bool AllWordsHidden()
        {
            foreach (bool hidden in scripture.HiddenWords)
            {
                if (!hidden)
                    return false;
            }
            return true;
        }

        private void HideRandomWords()
        {
            Random random = new Random();

            for (int i = 0; i < scripture.HiddenWords.Length; i++)
            {
                if (!scripture.HiddenWords[i])
                {
                    if (random.NextDouble() < 0.2) // 20% chance to hide a word
                        scripture.HiddenWords[i] = true;
                }
            }
        }
    }
}
