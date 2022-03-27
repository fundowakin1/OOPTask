using Microsoft.EntityFrameworkCore;

namespace OOPTask
{
    public class GuildContext : DbContext
    {
        public DbSet<Guild>Guilds { get; set; }
        public DbSet<Member>Members { get; set; }
        public DbSet<MemberInfo>MembersInfo { get; set; }
    }
}