using FrameworkHangman_DL;
using FrameworkHangman_DL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkHangman.Services
{
    public class GameEngine
    {
        public ScoreboardService _scoreboardService; 
        public GameEngine(Player player, int subjectId, List<char> word, List<char> answer)
        {
            Player = player;
            SubjectId = this.SubjectId;
            this.Word = word;
            Answer = answer;
            Lives = 7;
            GuessCount = 0;
            StartTime = DateTime.UtcNow.ToString();
            IsWinner = false;
            _scoreboardService = new ScoreboardService();
            UsedGuesses = new List<char>();
        }

        public Player Player { get; set; }
        public int SubjectId { get; set; }
        public List<char> Word { get; set; }
        public List<char> Answer { get; set; }
        public List<char> UsedGuesses { get; set; }
        public int Lives { get; set; }
        public int GuessCount { get; set; }
        public bool IsWinner { get; set; }
        public string StartTime { get; set; }

        public void Guess()
        {
            string guess = Console.ReadLine();
            GuessCount++;
            if (guess.Length > 1) GuessFullWord(guess);
            else if (guess.Length < 2) GuessSingleChar(guess[0]);
            else
            {
                Console.Clear();
                Console.WriteLine("Neivedete jokio spejimo!");
                Console.WriteLine("\r\n\r\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        public void GuessSingleChar(char letter)
        {
            if (Char.IsLetter(letter))
            {
                UsedGuesses.Add(letter);
                if (Word.Contains(letter)) GoodGuess(letter);
                else BadGuess();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("(-_-)");
                Console.WriteLine("Ivedete neteisinga spejima!");
                Console.Write("Spekite dar karta: ");
                Guess();
            }
        }

        public bool TryAgain()
        {
            var choice = Console.ReadKey();
            if (choice.Key == ConsoleKey.T) return true;
            else return false;
        }

        public void GuessFullWord(string fullguess)
        {
            if (fullguess == CharListToString(Word))
            {
                for (int i = 0; i < Answer.Count; i++) Answer[i] = fullguess[i];
            }
            else Lives = 0;
        }

        public void BadGuess()
        {
            Lives--;
        }

        public void GoodGuess(char letter)
        {
            for (int i = 0; i < Word.Count; i++) if (Word[i] == letter) Answer[i] = letter;
        }

        public bool CheckIfWinner()
        {
            if (CharListToString(Word) == CharListToString(Answer)) return true;
            return false;
        }

        public string CharListToString(List<char> list)
        {
            var sb = new StringBuilder();
            foreach (var item in list) sb.Append(item);
            return sb.ToString();
        }
    }
}
