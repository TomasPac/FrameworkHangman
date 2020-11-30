using FrameworkHangman_DL.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkHangman_DL.Services
{
    public class PlayerService : IGameServices
    {
        public Player NewPlayer()
        {
            var name = Console.ReadLine();
            Player player;
            if (IsPlayerNew(name))
            {
                player = new Player { Name = name };
                AddNew(player);
                return player;
            }
            else
            {
                using (var ctx = new HangmanDbConext())
                {
                    return ctx.Players.FirstOrDefault(p => p.Name == name);
                }
            }
        }
        public bool IsPlayerNew(string playerName)
        {
            using (var ctx = new HangmanDbConext())
            {
                if (ctx.Players.Any(p => p.Name == playerName)) return false;
                return true;
            }
        }

        public void AddNew(object player)
        {
            using (var ctx = new HangmanDbConext())
            {
                ctx.Players.Add((Player)player);
                ctx.SaveChanges();
            }
        }
    }
}
