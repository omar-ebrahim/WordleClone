namespace WordleClone.Helpers
{
    public class GuessHelper
    {
        public int NumberOfGuesses { get; private set; }

        private readonly string wordToGuess;

        public int CorrectMatches { get; private set; }

        public GuessHelper(string wordToGuess)
        {
            this.wordToGuess = wordToGuess;
        }

        public string GuessWord(string input)
        {
            CorrectMatches = 0;
            NumberOfGuesses++;
            if (string.IsNullOrEmpty(input) || input.Length != wordToGuess.Length)
            {
                return input;
            }

            List<int> exactMatchIndexes = new List<int>();
            var guessedWord = new string[wordToGuess.Length];
            for (var i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == input[i])
                {
                    exactMatchIndexes.Add(i);
                    CorrectMatches++;
                    guessedWord[i] = $"{{{input[i]}}}";
                }
                else
                {
                    guessedWord[i] = input[i].ToString();
                }
            }

            // now go through them and check if any are the correct letter in wrong place

            for (var i = 0; i < wordToGuess.Length; i++)
            {
                if (!exactMatchIndexes.Contains(i) && wordToGuess.Any(x => x == input[i])) // it's not an exact match but it's a correct letter
                {
                    guessedWord[i] = $"<{input[i]}>";
                }
            }

            return string.Join("", guessedWord);
        }
    }
}
