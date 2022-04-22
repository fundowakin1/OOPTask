using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities;
using OOPTask.GameEntities.Players;
using OOPTask.Seed.GuildMessages;

namespace OOPTask.Controllers.GuildControllers
{
    public class AssassinsGuildController : GuildController
    {
        public new AssassinsGuild _guild { get; set; }
        public AssassinsGuildController(GuildContext context, Guild guild, string guildName) : base(context, guild, guildName)
        {
            _guild = (AssassinsGuild)guild;
            _guild.OccupationDictionary = new Dictionary<int, InfoAboutAssassin>();
            for (int i = 0; i < _guild.MembersId.Count; i++)
            {
                var higherBound = context.Members.FirstOrDefault(x => x.Id == _guild.MembersId[i])!.MemberInfoEntity.AmountOfMoney;
                _guild.OccupationDictionary.Add(_guild.MembersId[i], new InfoAboutAssassin(true, higherBound - AssassinsGuild.Delta, higherBound));
            }

            AssassinsMessages.AddAssassinsMessages(_guild.MessagesDictionary);
        }

        public AssassinsGuildController() {}

        public override void InteractionWithPlayer(Player player)
        {
            ChangingOccupationStatus();
            base.InteractionWithPlayer(player);
        }

        private protected override void GreetingMessage()
        {
            Console.WriteLine(_guild.MessagesDictionary["GreetingMessage"]);
        }

        private protected override void InteractionWithPlayersMoney(Player player)
        {
            while (Guild.NumberOfRetries >0)
            {
                Console.WriteLine(_guild.MessagesDictionary["ChooseMessage"]);
                var playersAnswer = Console.ReadLine();
                var playersMoney = player.AmountOfMoney;
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
                if (Guild.NumberOfRetries == 0)
                {
                    Console.WriteLine(_guild.MessagesDictionary["Loose message"]);
                    player.IsAlive = false;
                    break;
                }
                if (!player.IsAlive || player.AmountOfMoney<playersMoney)
                {
                    Console.WriteLine(); 
                    break;
                }
            }
        }

        private protected override void PositivePlayersAnswer(Player player)
        {
            var notOccupiedAssassins = _guild.OccupationDictionary.Where(x => x.Value.IsOccupied).ToList();
            Console.WriteLine(_guild.MessagesDictionary["AskingForMoneyMessage"]);
            var amountOfMoney = Console.ReadLine();
            if (string.IsNullOrEmpty(amountOfMoney)||string.IsNullOrWhiteSpace(amountOfMoney)
                                                   ||!decimal.TryParse(amountOfMoney,NumberStyles.AllowDecimalPoint,
                                                        CultureInfo.CreateSpecificCulture("fr-FR"), out var amountOfMoneyParsed))
            {
                Console.WriteLine(_guild.MessagesDictionary["LostChanceMessage"]);
                Guild.NumberOfRetries--;
                return;
            }
                        
            if (player.AmountOfMoney<0)
            {
                Console.WriteLine(_guild.MessagesDictionary["NoMoneyMessage"]);
                player.IsAlive = false;
                return;
            }

            if (notOccupiedAssassins.Any(x => x.Value.LowerFeeBound < amountOfMoneyParsed
                                              && x.Value.UpperFeeBound > amountOfMoneyParsed))
            {
                Console.WriteLine(_guild.MessagesDictionary["SuccessMessage"]);
                player.GiveMoney(amountOfMoneyParsed);
                return;
            }

            Console.WriteLine(_guild.MessagesDictionary["NoAssassinsMessage"]);
            Guild.NumberOfRetries--;
            
        }

        private protected override void NegativePlayersAnswer(Player player)
        {
            player.IsAlive = false;
            Console.WriteLine(_guild.MessagesDictionary["DeadFromAssassinMessage"]);
        }

        public void ChangingOccupationStatus()
        {
            for (int i = 1; i < _guild.OccupationDictionary.Count; i++)
            {
                _guild.OccupationDictionary[i].IsOccupied = true;
            }
            var counter = 0;
            while (counter < _guild.OccupationDictionary.Count / 2)
            {
                var random = new Random();
                var assassinId = random.Next(1, _guild.OccupationDictionary.Count);
                if (!_guild.OccupationDictionary[assassinId].IsOccupied) continue;
                _guild.OccupationDictionary[assassinId].IsOccupied = false;
                counter++;
            }
        }

    }
    
}