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
            var guildDB = new GuildContext();
            Console.WriteLine("Type name of your character, gender and number of your race:");
            var name = Console.ReadLine();
            var gender = Console.ReadLine();
            var numberOfRace = Console.ReadLine();
            var player = new Player(name, gender, int.Parse(numberOfRace), playerDb);
            var assassinsGuild = new AssassinsGuild(guildDB, "Ankh-Morpork Assassins' Guild");
            var thievesGuild = new ThievesGuild(guildDB, "Guild of Thieves, Cutpurses and Allied Trades");
            var beggarsGuild = new BeggarsGuild(guildDB, "Ankh-Morpork Beggars' Guild");
            var foolsGuild = new FoolsGuild(guildDB, "The Guild of Fools and Joculators and College of Clowns");
            var counter = 0;
            while (player.IsAlive)
            {
                var guilds = new List<Guild>{assassinsGuild, beggarsGuild, foolsGuild, thievesGuild};
                var random = RandomNumberGenerator.GetInt32(1, guilds.Count+1);
                if (random==4)
                {
                    counter++;
                }
                if (counter>6)
                {
                    guilds.Remove(thievesGuild);
                }
                switch (random)
                {
                    case 1:
                        assassinsGuild.InteractionWithPlayersMoney(player);
                        break;
                    case 2:
                        beggarsGuild.InteractionWithPlayersMoney(player);
                        break;
                    case 3:
                        foolsGuild.InteractionWithPlayersMoney(player);
                        break;
                    case 4: 
                        thievesGuild.InteractionWithPlayersMoney(player);
                        break;
                }
            }

            Console.WriteLine("Finish!");
            
            player.PutPlayerToDb();
            
            
        }
        
    }
}