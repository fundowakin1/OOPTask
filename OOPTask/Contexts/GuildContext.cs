using Microsoft.EntityFrameworkCore;
using OOPTask.Models;
using OOPTask.Seed;

namespace OOPTask.Contexts
{
    public class GuildContext : DbContext
    {
        public DbSet<GuildEntity>Guilds { get; set; }
        public DbSet<MemberEntity>Members { get; set; }
        public DbSet<MemberInfoEntity>MembersInfo { get; set; }
        public GuildContext() 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder Options)  
        {
            Options.UseLazyLoadingProxies()
                .UseSqlServer("Server=localhost;Database=GuildDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuildEntity>().HasKey(guild => guild.Id);
            modelBuilder.Entity<MemberEntity>().HasKey(member => member.Id);
            modelBuilder.Entity<MemberInfoEntity>().HasKey(memberInfo => memberInfo.MemberId);
            
            modelBuilder.Entity<MemberEntity>().HasOne(x => x.GuildEntity)
                .WithMany(y => y.Members).HasForeignKey(k => k.GuildId);
            
            modelBuilder.Entity<MemberInfoEntity>().HasOne(x => x.MemberEntity)
                .WithOne(y => y.MemberInfoEntity).HasForeignKey<MemberInfoEntity>(k => k.MemberId);
            
            GuildSeed.Seeding(modelBuilder);
            MemberSeed.Seeding(modelBuilder);
        }
    }
}