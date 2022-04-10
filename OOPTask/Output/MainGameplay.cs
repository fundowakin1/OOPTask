using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using OOPTask.Contexts;
using OOPTask.GameEntities.Guilds;
using OOPTask.GameEntities.Players;

namespace OOPTask.Output
{
    public class MainGameplay
    {
        private static GuildContext GuildContext { get; set; }
        private static PlayerContext PlayerContext { get; set; }
        private static Player Player { get; set; }
        private static List<Guild> ListOfGuilds { get; set; }

        public static void MainOutput()
        {
            IntroductoryOutput();
            CharacterCreation();
            PlayersMoneyOutput();
            Gameplay();
            FinalOutput();
        }

        private static void CharacterCreation()
        {
            GuildContext   = new GuildContext();
            PlayerContext = new PlayerContext();
            Console.WriteLine("Type name of your character:");
            var name = Console.ReadLine();
            Console.WriteLine("Type gender of your character:");
            var gender = Console.ReadLine();
            Console.WriteLine("Type number of your character's race:");
            Console.WriteLine("Human: 1, Elven: 2, Gnome: 3, Vampire 4");
            var raceId = int.Parse(Console.ReadLine());
            Player = new Player(name,gender,raceId, PlayerContext);
        }

        private static void IntroductoryOutput()
        {
            Console.WriteLine("Welcome to the fine city of Ankh-Morpork!");
            Console.WriteLine("Ankh-Morpork lies on the River Ankh "+
                              "(the most polluted waterway on the Discworld and reputedly solid enough to walk on), "+
                              "where the fertile loam of the Sto Plains meets the Circle Sea. " +
                              "This, naturally, puts it in an excellent trading position.\n");
            Console.WriteLine("You can meet different fellows here but be careful, some of them are pretty dangerous");
            Console.WriteLine(
                "Watch your back, keep your coins safe and do not hang out with vampires!\n Good luck my friendo!\n");
        }

        private static void PlayersMoneyOutput()
        {
            var money = Player.AmountOfMoney.ToString("0.00", CultureInfo.InvariantCulture);
            var parts = money.Split('.'); 
            int? dollarPart = int.Parse(parts[0]);
            int? pennyPart = int.Parse(parts[1]);

            if (dollarPart!=0 && pennyPart!=0)
                Console.WriteLine($"Your balance: {dollarPart} AM$ and {pennyPart} pennies.");
            if (dollarPart==0&&pennyPart!=0)
                Console.WriteLine($"Your balance: {pennyPart} pennies.");
            if (dollarPart!=0&&pennyPart==0)
                Console.WriteLine($"Your balance: {dollarPart} AM$.");
        }

        private static void Gameplay()
        {
            var assassinsGuild = new AssassinsGuild(GuildContext, "Ankh-Morpork Assassins' Guild");
            var thievesGuild = new ThievesGuild(GuildContext, "Guild of Thieves, Cutpurses and Allied Trades");
            var beggarsGuild = new BeggarsGuild(GuildContext, "Ankh-Morpork Beggars' Guild");
            var foolsGuild = new FoolsGuild(GuildContext, "The Guild of Fools and Joculators and College of Clowns");
            var counter = 0;
            while (Player.IsAlive)
            {
                ListOfGuilds = new List<Guild>{assassinsGuild, beggarsGuild, foolsGuild, thievesGuild};
                var random = RandomNumberGenerator.GetInt32(0, ListOfGuilds.Count);
                if (random==4)
                {
                    counter++;
                }
                if (counter>6)
                {
                    ListOfGuilds.Remove(thievesGuild);
                }
                Guild chosenGuild = ListOfGuilds[random];
                chosenGuild.InteractionWithPlayer(Player);
                PlayersMoneyOutput();
                Player.AmountOfTurns++;
            }
        }

        private static void FinalOutput()
        {
            if (Player.IsAlive)
                Console.WriteLine($"Good job {Player.Name}. You were able to survive in this mad city!");
            else
                Console.WriteLine("You should have prepared to anything in this city, but unfortunately you didn't. " +
                                  "Now your body breathlessly lies on the ground");
            Player.PutPlayerToDb();
        }
    }
}