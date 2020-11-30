using System.Collections.Generic;

namespace FrameworkHangman_DL.Services
{
    public class ScoreboardService
    {
        public void Add(Scoreboard scoreboard)
        {
            using (var ctx = new HangmanDbConext())
            {
                ctx.Scoreboard.Add(scoreboard);
                ctx.SaveChanges();
            }
        }
    }
}
