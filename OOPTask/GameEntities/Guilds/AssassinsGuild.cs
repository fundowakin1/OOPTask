using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities.Players;

namespace OOPTask.GameEntities.Guilds
{
    public class AssassinsGuild : Guild
    {
        private const decimal Delta = 10;
        public Dictionary<int, InfoAboutAssassin> OccupationDictionary { get; set; }

        public AssassinsGuild(GuildContext context, string guildName) : base(context, guildName)
        {
            OccupationDictionary = new Dictionary<int, InfoAboutAssassin>();
            for (int i = 0; i < _membersId.Count; i++)
            {
                var higherBound = context.Members.FirstOrDefault(x => x.Id == _membersId[i])!.MemberInfoEntity.AmountOfMoney;
                OccupationDictionary.Add(_membersId[i], new InfoAboutAssassin(true, higherBound-Delta, higherBound));
            }
        }

        public AssassinsGuild() {}

        public override void InteractionWithPlayer(Player player)
        {
            ChangingOccupationStatus();
            base.InteractionWithPlayer(player);
        }

        private protected override void GreetingMessage()
        {
            Console.WriteLine("You found out that you’re under Assassins Guild contract");
            Console.WriteLine("What would you do?");
        }

        private protected override void InteractionWithPlayersMoney(Player player)
        {
            while (_numberOfRetries>0)
            {
                Console.WriteLine("You can pay some money to hire an assassin for your protection (type \"1\") or you can pray for your life (type \"2\").");
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
                if (_numberOfRetries==0)
                {
                    Console.WriteLine("You lost a chance to make decision. Now you die!");
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
            var notOccupiedAssassins = OccupationDictionary.Where(x => x.Value.IsOccupied).ToList();
            Console.WriteLine("Please, tell me how much you can pay for your life? :");
            var amountOfMoney = Console.ReadLine();
            if (string.IsNullOrEmpty(amountOfMoney)||string.IsNullOrWhiteSpace(amountOfMoney)
                                                   ||!decimal.TryParse(amountOfMoney,NumberStyles.AllowDecimalPoint,
                                                        CultureInfo.CreateSpecificCulture("fr-FR"), out var amountOfMoneyParsed))
            {
                Console.WriteLine("You have lost your chance to hire an assassin. Try again!");
                _numberOfRetries--;
                return;
            }
                        
            if (player.AmountOfMoney<0)
            {
                Console.WriteLine("Your pockets are empty");
                player.IsAlive = false;
                return;
            }

            if (notOccupiedAssassins.Any(x => x.Value.LowerFeeBound < amountOfMoneyParsed
                                              && x.Value.UpperFeeBound > amountOfMoneyParsed))
            {
                Console.WriteLine("You successfully hired professional assassin, but it turned out that no one was hunting for you");
                player.GiveMoney(amountOfMoneyParsed);
                return;
            }

            Console.WriteLine("There are no assassins for your amount of gold.");
            _numberOfRetries--;
            
        }

        private protected override void NegativePlayersAnswer(Player player)
        {
            player.IsAlive = false;
            Console.WriteLine("You decided to choose death! Assassin kills you!");
        }

        public void ChangingOccupationStatus()
        {
            for (int i = 1; i < OccupationDictionary.Count; i++)
            {
                OccupationDictionary[i].IsOccupied = true;
            }
            var counter = 0;
            while (counter < OccupationDictionary.Count / 2)
            {
                var random = new Random();
                var assassinId = random.Next(1, OccupationDictionary.Count);
                if (!OccupationDictionary[assassinId].IsOccupied) continue;
                OccupationDictionary[assassinId].IsOccupied = false;
                counter++;
            }
        }

    }
    public class InfoAboutAssassin
    {
        public bool IsOccupied { get; set; }
        public decimal LowerFeeBound { get; set; }
        public decimal UpperFeeBound { get; set; }

        public InfoAboutAssassin(bool isOccupied, decimal lowerFeeBound, decimal upperFeeBound)
        {
            IsOccupied = isOccupied;
            LowerFeeBound = lowerFeeBound;
            UpperFeeBound = upperFeeBound;
        }
    }
}