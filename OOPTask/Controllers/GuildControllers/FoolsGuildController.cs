using System;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities;
using OOPTask.GameEntities.Players;
using OOPTask.Interfaces;
using OOPTask.Output;
using OOPTask.Seed.GuildMessages;

namespace OOPTask.Controllers.GuildControllers
{
    public class FoolsGuildController : GuildController, IChoosingMember 
    {
        protected new FoolsGuild _guild { get; set; }
        public FoolsGuildController(GuildContext context, Guild guild, string guildName) : base(context, guild, guildName)
        {
            _guild = (FoolsGuild)guild;
            FoolsMessages.AddFoolsMessages(_guild.MessagesDictionary);
        }

        public override void InteractionWithPlayer(Player player)
        {
            ChoosingMember();
            base.InteractionWithPlayer(player);
        }

        private protected override void GreetingMessage()
        {
            Console.WriteLine(_guild.MessagesDictionary["GreetingMessageWithName"] + _guild.ChosenMember.MemberInfoEntity.Name);
            Console.WriteLine(_guild.MessagesDictionary["GreetingMessage"]);


            GreetingSpecialChosenMember();
        }

        private protected override void InteractionWithPlayersMoney(Player player)
        {
            while (Guild.NumberOfRetries>0)
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
                if (Guild.NumberOfRetries == 0)
                {
                    player.IsAlive = false;
                }
            }
        }

        private protected override void PositivePlayersAnswer(Player player)
        {
            player.ReceiveMoney(_guild.ChosenMember.MemberInfoEntity.AmountOfMoney);
            var parts = MoneyFormatting.SplitDecimalToString(_guild.ChosenMember.MemberInfoEntity.AmountOfMoney);
            Console.WriteLine(_guild.MessagesDictionary["HelpMessage"]);
            if (parts[0] != 0 && parts[1] != 0)
                Console.WriteLine($"You received: {parts[0]} AM$ and {parts[1]} pennies.");
            if (parts[0] == 0 && parts[1] != 0)
                Console.WriteLine($"You received: {parts[1]} pennies.");
            if (parts[0] != 0 && parts[1] == 0)
                Console.WriteLine($"You received: {parts[0]} AM$.");
        }

        private protected override void NegativePlayersAnswer(Player player)
        {
            Console.WriteLine(_guild.MessagesDictionary["RejectMessage"]);
        }

        public void ChoosingMember()
        {
            var random = new Random();
            var chosenMemberId = random.Next(0, _guild.MembersId.Count);
            var id = _guild.MembersId[chosenMemberId];
            _guild.ChosenMember = _context.Members.FirstOrDefault(x => x.Id == id);
        }
    }
}