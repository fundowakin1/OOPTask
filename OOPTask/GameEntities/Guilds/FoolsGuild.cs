using System;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities.Players;
using OOPTask.Interfaces;
using OOPTask.Output;

namespace OOPTask.GameEntities.Guilds
{
    public class FoolsGuild : Guild, IChoosingMember 
    {
        public FoolsGuild(GuildContext context, string guildName) : base(context, guildName)
        {
        }

        public override void InteractionWithPlayer(Player player)
        {
            ChoosingMember();
            base.InteractionWithPlayer(player);
        }

        private protected override void GreetingMessage()
        {
            Console.WriteLine($"You've met a very good friend of yours {ChosenMember.MemberInfoEntity.Name}");
            Console.WriteLine(" Greetings, can you help me with some stuff...\n My partner clown-Jack is sick, can you replace him today");
            Console.WriteLine("What would you do?");
            Console.WriteLine("You can help your friend (type \"1\") or you can just go away (type \"2\") he probably will be upset.");
            GreetingSpecialChosenMember();
        }

        private protected override void InteractionWithPlayersMoney(Player player)
        {
            while (_numberOfRetries>0)
            {
                var playersAnswer = Console.ReadLine();
                SpecialChosenMemberReaction(playersAnswer, player);
                if (player.HasWon || !player.IsAlive)
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
                if (!player.IsAlive || playersAnswer is "1" or "2" || player.HasWon)
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
            player.ReceiveMoney(ChosenMember.MemberInfoEntity.AmountOfMoney);
            var parts = MoneyFormatting.SplitDecimalToString(ChosenMember.MemberInfoEntity.AmountOfMoney);
            Console.WriteLine("You helped him, at the and of the day he gave you some cash.");
            if (parts[0] != 0 && parts[1] != 0)
                Console.WriteLine($"You received: {parts[0]} AM$ and {parts[1]} pennies.");
            if (parts[0] == 0 && parts[1] != 0)
                Console.WriteLine($"You received: {parts[1]} pennies.");
            if (parts[0] != 0 && parts[1] == 0)
                Console.WriteLine($"You received: {parts[0]} AM$.");
        }

        private protected override void NegativePlayersAnswer(Player player)
        {
            Console.WriteLine("You decided not to help him. Sad clown goes away");
        }

        public void ChoosingMember()
        {
            var random = new Random();
            var chosenMemberId = random.Next(0, _membersId.Count);
            var id = _membersId[chosenMemberId];
            ChosenMember = _context.Members.FirstOrDefault(x => x.Id == id);
        }
    }
}