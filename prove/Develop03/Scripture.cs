namespace ScriptureMemorizer
{
    class Scripture
    {
        public string Reference { get; }
        public string Text { get; }
        public bool[] HiddenWords { get; }

        public Scripture(string reference, string text)
        {
            Reference = reference;
            Text = text;
            HiddenWords = new bool[text.Split(' ').Length];
        }
    }
}
