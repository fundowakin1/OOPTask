using Microsoft.EntityFrameworkCore;
using OOPTask.Models;

namespace OOPTask.Seed
{
    public class GuildSeed
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuildEntity>().HasData(new GuildEntity[]
            {
                new GuildEntity {Id = 1, Name = "Ankh-Morpork Assassins' Guild"},
                new GuildEntity {Id = 2, Name = "Guild of Thieves, Cutpurses and Allied Trades"},
                new GuildEntity {Id = 3, Name = "Ankh-Morpork Beggars' Guild"},
                new GuildEntity {Id = 4, Name = "The Guild of Fools and Joculators and College of Clowns"}
            });
        }
    }
}