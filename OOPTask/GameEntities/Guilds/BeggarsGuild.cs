using System;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities.Players;
using OOPTask.Models;

namespace OOPTask.GameEntities.Guilds
{
    public class BeggarsGuild : Guild, IChoosingMember 
    {
        public BeggarsGuild(GuildContext context, string guildName) : base(context, guildName)
        {
        }
        public void ChoosingMember()
        {
            var random = new Random();
            var chosenMemberId = random.Next(0, _membersId.Count);
            var id = _membersId[chosenMemberId];
            ChosenMember = _context.Members.FirstOrDefault(x => x.Id == id);
        }

        public void InteractionWithPlayersMoney(Player player)
        {
            ChoosingMember();
            if (ChosenMember.MemberInfoEntity.AmountOfMoney==0)
            {
                Console.WriteLine("You see a person with placard Saying \"Why lie? I need a beer.\"");
                Console.WriteLine("He doesn't bother you");
                return;
            }
            Console.WriteLine($"You've met poor man in baggy clothes {ChosenMember.MemberInfoEntity.Name}");
            Console.WriteLine($" - Please, {player.Name}, give me some coins, good fellow\n How does he know your name?");
            Console.WriteLine("What would you do?");
            Console.WriteLine("You can give him some money (type \"1\") or you can try your best to run away (type \"2\").");
            var numberOfRetries = 3;
            while (true)
            {
                var playersAnswer = Console.ReadLine();
                switch (playersAnswer)
                {
                    case "1":
                        player.AmountOfMoney -= ChosenMember.MemberInfoEntity.AmountOfMoney;
                        if (player.AmountOfMoney<0)
                        {
                            Console.WriteLine("You have been chased to death");
                            player.IsAlive = false;
                            break;
                        }
                        Console.WriteLine("You peacefully gave your cash to this beggar.");
                        break;
                    case "2":
                        player.IsAlive = false;
                        Console.WriteLine("You decided not to give him money. A bad idea. You have been chased to death");
                        break;
                    default:
                        Console.WriteLine("Please, write 1 or 2!");
                        if (numberOfRetries==0)
                        {
                            Console.WriteLine("You should have followed instructions and haven't written this bullshit!");
                            player.IsAlive = false;
                            break;
                        }
                        Console.WriteLine($"Number of retries: {--numberOfRetries}");
                        break;
                }
                if (!player.IsAlive || playersAnswer=="1")
                {
                    Console.WriteLine(); 
                    break;
                }
            }
        }
        
    }
}