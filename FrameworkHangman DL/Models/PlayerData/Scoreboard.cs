using System;
using System.ComponentModel.DataAnnotations;

namespace FrameworkHangman_DL
{
    public class Scoreboard
    {
        public Scoreboard(int playerId, string word, int guessCount, bool isWinner, string dateStart, string dateEnd)
        {
            PlayerId = playerId;
            Word = word;
            GuessCount = guessCount;
            IsWinner = isWinner;
            DateStart = dateStart;
            DateEnd = dateEnd;
        }

        [Key]
        public int ScoreId { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public string  Word { get; set; }
        public int GuessCount { get; set; }
        public bool IsWinner { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
    }
}
