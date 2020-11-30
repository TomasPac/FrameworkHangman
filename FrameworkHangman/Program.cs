using FrameworkHangman.Models.Concrete;
using FrameworkHangman.Services;
using FrameworkHangman_BL.Models.Concrete;
using FrameworkHangman_DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrameworkHangman
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new GameInitializer();
            var userMessage = new UserMessage();
            var picture = new HangmanPicture();

            Console.Clear();
            userMessage.LoadingScreen();
            userMessage.GameStartMessage();
            userMessage.AskForName();

            var player = initializer.PlayerInitialize();
            userMessage.ChooseSubjectMessage();

            var subject = initializer.SubjectInitialize();
            var word = initializer.WordInitialize(subject);
            var answer = initializer.AnswerInitialize();


            var engine = new GameEngine(player, subject, word, answer);
            while (!engine.CheckIfWinner())
            {
                Console.Clear();
                Console.WriteLine(picture.Canvas[engine.Lives]);
                userMessage.ListItemsPrint(engine.Answer);
                Console.Write("\r\n\r\n\r\nPanaudoti spejimai: ");
                userMessage.ListItemsPrint(engine.UsedGuesses);
                if (engine.Lives == 0)
                {
                    engine._scoreboardService.Add(initializer.ScoreboardInitialize(engine.Player.PlayerId, engine.CharListToString(word), engine.GuessCount, engine.IsWinner, engine.StartTime, DateTime.UtcNow.ToString()));
                    userMessage.Loser(engine.CharListToString(engine.Word));
                    if (engine.TryAgain()) Main(args);
                    else Environment.Exit(0);
                }
                userMessage.GuessMessage();
                engine.Guess();
            }
            engine._scoreboardService.Add(initializer.ScoreboardInitialize(engine.Player.PlayerId, engine.CharListToString(word), engine.GuessCount, engine.IsWinner = true, engine.StartTime, DateTime.UtcNow.ToString()));
            userMessage.WinnerMessage(engine.Word);
            if (engine.TryAgain()) Main(args);
            else Environment.Exit(0);
            Console.ReadLine();
        }
    }
}
