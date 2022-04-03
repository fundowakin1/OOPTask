using System;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities.Players;
using OOPTask.Models;

namespace OOPTask.GameEntities.Guilds
{
    public class ThievesGuild : Guild, IChoosingMember
    {
        public MemberEntity ChosenMember { get; set; }
        public ThievesGuild(GuildContext context, string guildName) : base(context, guildName)
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
            Console.WriteLine($"Poor you. You've met ditty thief {ChosenMember.MemberInfoEntity.Name}");
            Console.WriteLine($" - He-he! Turn out your pockets {player.Name}!");
            Console.WriteLine("What would you do?");
            Console.WriteLine("You can give him some money (type \"1\") or you can try your best to run away (type \"2\").");
            var numberOfRetries = 3;
            while (true)
            {
                var playersAnswer = Console.ReadLine();
                switch (playersAnswer)
                {
                    case "1":
                        player.AmountOfMoney -= 10;
                        Console.WriteLine("You peacefully gave your cash to this thief.");
                        break;
                    case "2":
                        player.IsAlive = false;
                        Console.WriteLine("You decided to choose death! Thief stabbed you in the back(");
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
                    break;
            }
            
        }
    }
}