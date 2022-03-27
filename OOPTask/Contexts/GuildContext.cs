using Microsoft.EntityFrameworkCore;

namespace OOPTask
{
    public class GuildContext : DbContext
    {
        public DbSet<Guild>Guilds { get; set; }
        public DbSet<Member>Members { get; set; }
        public DbSet<MemberInfo>MembersInfo { get; set; }
        public GuildContext() 
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder Options)  
        {
            Options.UseSqlServer("Server=DESKTOP-GFLE9ES\\MYSQLSERVER;Database=GuildDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guild>().HasKey(guild => guild.Id);
            modelBuilder.Entity<Member>().HasKey(member => member.Id);
            modelBuilder.Entity<MemberInfo>().HasKey(memberInfo => memberInfo.MemberId);
            
            modelBuilder.Entity<Member>().HasOne(x => x.Guild)
                .WithMany(y => y.Members).HasForeignKey(k => k.GuildId);
            
            modelBuilder.Entity<MemberInfo>().HasOne(x => x.Member)
                .WithOne(y => y.MemberInfo).HasForeignKey<MemberInfo>(k => k.MemberId);
        }

        public void DropDb()
        {
            Database.EnsureDeleted();
        }

    }
}