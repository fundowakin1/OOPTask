using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            var guildDb = new GuildContext();
            //Console.WriteLine("Type name of your character, gender and number of your race:");
            // var name = Console.ReadLine();
            // var gender = Console.ReadLine();
            //var numberOfRace = Console.ReadLine();
            var player = new Player("name", "jopa", 1, playerDb);
            var assassinsGuild = new AssassinsGuild(guildDb, "Ankh-Morpork Assassins' Guild");
            var thievesGuild = new ThievesGuild(guildDb, "Guild of Thieves, Cutpurses and Allied Trades");
            var beggarsGuild = new BeggarsGuild(guildDb, "Ankh-Morpork Beggars' Guild");
            var foolsGuild = new FoolsGuild(guildDb, "The Guild of Fools and Joculators and College of Clowns");
            var counter = 0;
            while (player.IsAlive)
            {
                var guilds = new List<Guild>{assassinsGuild, beggarsGuild, foolsGuild, thievesGuild};
                var random = RandomNumberGenerator.GetInt32(0, guilds.Count);
                if (random==4)
                {
                    counter++;
                }
                if (counter>6)
                {
                    guilds.Remove(thievesGuild);
                }
                Guild chosenGuild = guilds[random];
                chosenGuild.InteractionWithPlayer(player);
            }
            
            

            Console.WriteLine("Finish!");

            player.PutPlayerToDb();
        }
        
    }
}