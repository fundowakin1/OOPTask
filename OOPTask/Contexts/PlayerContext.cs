using Microsoft.EntityFrameworkCore;
using OOPTask.Models;

namespace OOPTask.Contexts
{
    public class PlayerContext : DbContext
    {
        public DbSet<PlayerEntity>Players { get; set; }
        public DbSet<PlayerInfoEntity>PlayersInfo { get; set; }
        
        public PlayerContext() 
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder Options)  
        {
            Options.UseLazyLoadingProxies()
                .UseSqlServer("Server=localhost;Database=PlayerDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerEntity>().HasKey(player => player.Id);
            modelBuilder.Entity<PlayerInfoEntity>().HasKey(playerInfo => playerInfo.PlayerId);
            
            modelBuilder.Entity<PlayerInfoEntity>().HasOne(x => x.PlayerEntity)
                .WithOne(y => y.PlayerInfoEntity).HasForeignKey<PlayerInfoEntity>(k => k.PlayerId);
        }
    }
}