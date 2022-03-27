using Microsoft.EntityFrameworkCore;

namespace OOPTask
{
    public class PlayerContext : DbContext
    {
        public DbSet<Player>Players { get; set; }
        public DbSet<PlayerInfo>PlayersInfo { get; set; }
    }
}