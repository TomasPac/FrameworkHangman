using System.Data.Entity;

namespace FrameworkHangman_DL
{
    public class HangmanDbConext : DbContext
    {
        public HangmanDbConext() : base("HangmanDB")
        {
            Database.SetInitializer(new HangmanInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scoreboard>()
                .HasKey(s => s.ScoreId);
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Scoreboard> Scoreboard { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
