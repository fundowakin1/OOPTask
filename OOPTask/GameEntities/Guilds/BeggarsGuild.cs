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

        public override void InteractionWithPlayer(Player player)
        {
            ChoosingMember();
            base.InteractionWithPlayer(player);
        }

        public void ChoosingMember()
        {
            var random = new Random();
            var chosenMemberId = random.Next(0, _membersId.Count);
            var id = _membersId[chosenMemberId];
            ChosenMember = _context.Members.FirstOrDefault(x => x.Id == id);
        }

        private protected override void InteractionWithPlayersMoney(Player player)
        {
            if (ChosenMember.MemberInfoEntity.AmountOfMoney==0)
                return;
            
            while (_numberOfRetries>0)
            {
                var playersAnswer = Console.ReadLine();
                switch (playersAnswer)
                {
                    case "1":
                        PositivePlayersAnswer(player);
                        break;
                    case "2":
                        NegativePlayersAnswer(player);
                        break;
                    default:
                        DefaultPlayersAnswer(player);
                        break;
                }
                if (!player.IsAlive || playersAnswer=="1")
                {
                    Console.WriteLine(); 
                    break;
                }
                if (_numberOfRetries==0)
                {
                    player.IsAlive = false;
                }
            }
        }

        private protected override void PositivePlayersAnswer(Player player)
        {
            player.AmountOfMoney -= ChosenMember.MemberInfoEntity.AmountOfMoney;
            if (player.AmountOfMoney<0)
            {
                Console.WriteLine("You have been chased to death");
                player.IsAlive = false;
                return;
            }
            Console.WriteLine("You peacefully gave your cash to this beggar.");
        }
        private protected override void NegativePlayersAnswer(Player player) 
        {
            player.IsAlive = false;
            Console.WriteLine("You decided not to give him money. A bad idea. You have been chased to death");
        }
        private protected override void GreetingMessage()
        {
            if (ChosenMember.MemberInfoEntity.AmountOfMoney==0)
            {
                Console.WriteLine("You see a person with placard Saying \"Why lie? I need a beer.\"");
                Console.WriteLine("He doesn't bother you");
                return;
            }
            Console.WriteLine($"You've met poor man in baggy clothes, his name - {ChosenMember.MemberInfoEntity.Name}");
            Console.WriteLine(" - Please, give me some coins, good fellow\n How does he know your name?");
            Console.WriteLine("What would you do?");
            Console.WriteLine("You can give him some money (type \"1\") or you can try your best to run away (type \"2\").");
        }
    }
}