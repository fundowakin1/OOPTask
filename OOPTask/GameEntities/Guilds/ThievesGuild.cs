using System;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities.Players;
using OOPTask.Models;

namespace OOPTask.GameEntities.Guilds
{
    public class ThievesGuild : Guild, IChoosingMember
    {
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

        public override void InteractionWithPlayer(Player player)
        {
            ChoosingMember();
            base.InteractionWithPlayer(player);
        }

        private protected override void GreetingMessage()
        {
            Console.WriteLine($"Poor you. You've met ditty thief {ChosenMember.MemberInfoEntity.Name}");
            Console.WriteLine(" - He-he! Turn out your pockets!");
            Console.WriteLine("What would you do?");
            Console.WriteLine("You can give him some money (type \"1\") or you can try your best to run away (type \"2\").");
            GreetingSpecialChosenMember();
        }

        private protected override void InteractionWithPlayersMoney(Player player)
        {
            while (_numberOfRetries>0)
            {
                var playersAnswer = Console.ReadLine();
                SpecialChosenMemberReaction(playersAnswer, player);
                if (player.HasWon||!player.IsAlive)
                    break;
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
                if (_numberOfRetries==0)
                {
                    player.IsAlive = false;
                }
                if (!player.IsAlive || playersAnswer=="1" || player.HasWon)
                {
                    Console.WriteLine(); 
                    break;
                }
            }
        }

        private protected override void PositivePlayersAnswer(Player player)
        {
            player.AmountOfMoney -= 10;
            if (player.AmountOfMoney<0)
            {
                Console.WriteLine("No money, no life(");
                player.IsAlive = false;
                return;
            }
            Console.WriteLine("You peacefully gave your cash to this thief.");
        }

        private protected override void NegativePlayersAnswer(Player player)
        {
            player.IsAlive = false;
            Console.WriteLine("You decided to choose death! Thief stabbed you in the back(");
        }
    }
}