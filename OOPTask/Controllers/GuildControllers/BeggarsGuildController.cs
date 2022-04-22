using System;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities;
using OOPTask.GameEntities.Players;
using OOPTask.Interfaces;
using OOPTask.Models;
using OOPTask.Seed.GuildMessages;

namespace OOPTask.Controllers.GuildControllers
{
    public class BeggarsGuildController : GuildController, IChoosingMember 
    {
        protected new BeggarsGuild _guild { get; set; }
        public BeggarsGuildController(GuildContext context, Guild guild, string guildName) : base(context, guild, guildName)
        {
            _guild = (BeggarsGuild)guild;
            BeggarsMessages.AddBeggarsMessages(_guild.MessagesDictionary);
        }

        public override void InteractionWithPlayer(Player player)
        {
            ChoosingMember();
            base.InteractionWithPlayer(player);
        }

        private protected override void GreetingMessage()
        {
            if (_guild.ChosenMember.MemberInfoEntity.AmountOfMoney == 0)
            {
                Console.WriteLine(_guild.MessagesDictionary["GreetingMessageBeer"]);
                return;
            }
            Console.WriteLine(_guild.MessagesDictionary["GreetingMessageName"] + _guild.ChosenMember.MemberInfoEntity.Name);
            Console.WriteLine(_guild.MessagesDictionary["GreetingMessageFinal"]);
            GreetingSpecialChosenMember();
        }

        private protected override void InteractionWithPlayersMoney(Player player)
        {
            if (_guild.ChosenMember.MemberInfoEntity.AmountOfMoney==0)
                return;
            
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
                if (!player.IsAlive || playersAnswer=="1")
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
            player.GiveMoney(_guild.ChosenMember.MemberInfoEntity.AmountOfMoney); 
            if (player.AmountOfMoney<0)
            {
                Console.WriteLine(_guild.MessagesDictionary["ChasedToDeathMessage"]);
                player.IsAlive = false;
                return;
            }
            Console.WriteLine(_guild.MessagesDictionary["GiveMoneyMessage"]);
        }

        private protected override void NegativePlayersAnswer(Player player) 
        {
            player.IsAlive = false;
            Console.WriteLine(_guild.MessagesDictionary["NotGivingMoneyMessage"]);
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