using System;
using OOPTask.Contexts;
using OOPTask.GameEntities.Guilds;
using OOPTask.GameEntities.Players;

namespace OOPTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerDb = new PlayerContext();
            var guildDB = new GuildContext();
            var player = new Player("Bububu", "man", 2, playerDb);
            var thiefsGuild = new ThievesGuild(guildDB, "Guild of Thieves, Cutpurses and Allied Trades");
            thiefsGuild.InteractionWithPlayersMoney(player);
            player.PutPlayerToDb();
            
        }
        
    }
}