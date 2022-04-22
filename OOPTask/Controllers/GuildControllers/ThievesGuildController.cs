using System;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities;
using OOPTask.GameEntities.Players;
using OOPTask.Interfaces;
using OOPTask.Seed.GuildMessages;

namespace OOPTask.Controllers.GuildControllers
{
    public class ThievesGuildController : GuildController, IChoosingMember
    {
        protected new ThievesGuild _guild { get; set; }

        public ThievesGuildController(GuildContext context, Guild guild, string guildName) : base(context, guild, guildName)
        {
            _guild = (ThievesGuild)guild;
            ThievesMessages.AddThievesMessages(_guild.MessagesDictionary);
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
            while (Guild.NumberOfRetries >0)
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
                if (Guild.NumberOfRetries ==0)
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
            player.GiveMoney(_guild.ChosenMember.MemberInfoEntity.AmountOfMoney);
            if (player.AmountOfMoney<0)
            {
                Console.WriteLine(_guild.MessagesDictionary["DeathThieveMessage"]);
                player.IsAlive = false;
                return;
            }
            Console.WriteLine(_guild.MessagesDictionary["GiveCashMessage"]);
        }

        private protected override void NegativePlayersAnswer(Player player)
        {
            player.IsAlive = false;
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