using System;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities.Players;
using OOPTask.Models;

namespace OOPTask.GameEntities.Guilds
{
    public class FoolsGuild : Guild, IChoosingMember 
    {
        public FoolsGuild(GuildContext context, string guildName) : base(context, guildName)
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
            Console.WriteLine($"You've met a very good friend of yours {ChosenMember.MemberInfoEntity.Name}");
            Console.WriteLine($" Greetings, {player.Name}, can you help me with some stuff...\n My partner clown-Jack is sick, can you replace him today");
            Console.WriteLine("What would you do?");
            Console.WriteLine("You can help your friend (type \"1\") or you can just go away (type \"2\") he probably will be upset.");
            var numberOfRetries = 3;
            while (true)
            {
                var playersAnswer = Console.ReadLine();
                switch (playersAnswer)
                {
                    case "1":
                        player.AmountOfMoney += ChosenMember.MemberInfoEntity.AmountOfMoney;
                        Console.WriteLine("You helped him, at the and of the day he gave you some cash.");
                            Console.WriteLine($"you received {ChosenMember.MemberInfoEntity.AmountOfMoney}");
                        break;
                    case "2":
                        player.IsAlive = false;
                        Console.WriteLine("You decided not to helped him. Sad clown goes away");
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