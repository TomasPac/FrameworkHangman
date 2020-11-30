using FrameworkHangman_DL;
using FrameworkHangman_DL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrameworkHangman.Models.Concrete
{
    public class UserMessage
    {
        public void AskForName()
        {
            Console.Write("Please write your Name: ");
        }
        public void LoadingScreen()
        {
            var loader = "|||||||||||||||||||||||||||";
            Console.Write("loading....\r\n");

            for (int i = 0; i < loader.Length; i++)
            {
                Thread.Sleep(30);
                Console.Write(loader[i]);
            }
        }
        public void GameStartMessage()
        {
            Console.Clear();
            string title = "THE HANGMAN GAME";

            for (int i = 0; i < title.Length; i++)
            {
                Thread.Sleep(100);
                Console.Write(title[i]);
            }
            Console.WriteLine("\r\n_ _ _ _ _ _ _ _ _\r\n");
        }
        public void ChooseSubjectMessage()
        {
            var subjectService = new SubjectService();
            Console.Clear();
            Console.WriteLine(" ------------------------");
            Console.WriteLine("|   PASIRINKITE TEMA    |");
            Console.WriteLine(" ------------------------\r\n\r\n");
            foreach (var subject in subjectService.SubjectsGetAll())
            {
                Console.WriteLine($"=>{subject.SubjectId} {subject.Value}");
            }
        }

        internal void Loser(string word)
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("|      GAME     OVER      |");
            Console.WriteLine("|                         |");
            Console.WriteLine("|           *_*           |");
            Console.WriteLine("--------------------------");
            Console.Write($"Zodis buvo: {word.ToUpper()}");
            Console.WriteLine("\r\n\r\n\r\nZaisti dar karta ? -T");
        }

        public void WinnerMessage(List<char> word)
        {
            Console.Clear();
            Console.WriteLine("********************");
            Console.WriteLine("     SVEIKINAME\r\n");
            Console.WriteLine("Suradote atsakyma!");
            Console.Write($"Atsakymas buvo: ");
            foreach (var letter in word) Console.Write(letter);
            Console.WriteLine("\r\n\r\n");
            Console.WriteLine(@"       MMMMM");
            Console.WriteLine(@"    ` (^ u ^) `");
            Console.WriteLine(@"      \  |  /");
            Console.WriteLine(@"       \( )/");
            Console.WriteLine(@"        ( )");
            Console.WriteLine(@"        / \");
            Console.WriteLine(@"       /   \");
            Console.WriteLine(@"     _|     |_");
            Console.WriteLine(@"----------------------");
            Console.WriteLine("Zaisti dar karta? -T");
        }
        public void ListItemsPrint(List<char> answer)
        {
            foreach (var letter in answer) Console.Write($"{letter} ");
        }
        public void GuessMessage()
        {
            Console.Write("\r\n\r\n\r\nSpekite raide, arba visa zodi: ");
        }
        public void AnsweredWordPrint(string answer)
        {
            for (int i = 0; i < answer.Length; i++)
            {
                Console.WriteLine(answer[i]);
            }
        }
    }
}
