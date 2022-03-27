using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace OOPTask
{
    public class PlayerContext : DbContext
    {
        public DbSet<Player>Players { get; set; }
        public DbSet<PlayerInfo>PlayersInfo { get; set; }
        
        public PlayerContext() 
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder Options)  
        {
            Options.UseSqlServer("Server=DESKTOP-GFLE9ES\\MYSQLSERVER;Database=PlayerDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasKey(player => player.Id);
            modelBuilder.Entity<PlayerInfo>().HasKey(playerInfo => playerInfo.PlayerId);
            
            modelBuilder.Entity<PlayerInfo>().HasOne(x => x.Player)
                .WithOne(y => y.PlayerInfo).HasForeignKey<PlayerInfo>(k => k.PlayerId);
        }
    }
}