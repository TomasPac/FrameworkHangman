using FrameworkHangman.Models.Concrete;
using FrameworkHangman_DL;
using FrameworkHangman_DL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkHangman.Services
{
    class GameInitializer
    {
        public List<char> _answer = new List<char>();
        Player _player = new Player();
        List<char> _word = new List<char>();
        Scoreboard _scoreboard;
        Subject _subject = new Subject();
        WordService _wordService = new WordService();
        PlayerService _playerService = new PlayerService();
        UserMessage _messageService = new UserMessage();
        SubjectService _subjectService = new SubjectService();

        public Player PlayerInitialize()
        {
            _player = _playerService.NewPlayer();
            return _player;
        }
        public int SubjectInitialize()
        {
            var subjectChoice = Console.ReadLine();
            if (_subjectService.SubjectPick(subjectChoice) != null)
            {
                _subject = _subjectService.SubjectPick(subjectChoice);
                return _subject.SubjectId;
            }
            else
            {
                Console.WriteLine("Subject NOT initialized!");
                return 0;
            }
        }
        public List<char> WordInitialize(int subjectId)
        {
            _word = _wordService.WordGenerator(subjectId).ToList<char>();
            return _word;
        }
        public List<char> AnswerInitialize()
        {
            for (int i = 0; i < _word.Count; i++)
            {
                _answer.Add('_');
            }
            return _answer;
        }
        public Scoreboard ScoreboardInitialize(int playerId, string word, int guessCount, bool isWinner, string dateStart, string dateEnd)
        {
            _scoreboard = new Scoreboard(playerId, word, guessCount, isWinner, dateStart, dateEnd);
            return _scoreboard;
        }
    }
}
