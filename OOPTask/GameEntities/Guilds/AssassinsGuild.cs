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
        private Dictionary<int, (bool,decimal,decimal)> _occupationDictionary;
        private static decimal _delta = 10;
        
        public AssassinsGuild(GuildContext context, string guildName) : base(context, guildName)
        {
            _occupationDictionary = new Dictionary<int, (bool,decimal,decimal)>();
            for (int i = 0; i < _membersId.Count; i++)
            {
                var higherBound = context.Members.FirstOrDefault(x => x.Id == _membersId[i])!.MemberInfoEntity.AmountOfMoney;
                _occupationDictionary.Add(_membersId[i], (true, higherBound-_delta,higherBound));
            }
        }

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

        private void ChangingOccupationStatus()
        {
            for (int i = 1; i < _occupationDictionary.Count; i++)
            {
                var valueTuple = _occupationDictionary[i];
                valueTuple.Item1 = true;
                _occupationDictionary[i] = valueTuple;
            }
            var counter = 0;
            while (counter<_occupationDictionary.Count/2)
            {
                var random = new Random();
                var assassinId = random.Next(1 , _occupationDictionary.Count);
                var valueTuple = _occupationDictionary[assassinId];
                if (valueTuple.Item1)
                {
                    valueTuple.Item1 = false;
                    _occupationDictionary[assassinId] = valueTuple;
                    counter++;
                }
            }
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
            var notOccupiedAssassins = _occupationDictionary.Where(x => x.Value.Item1).ToList();
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

            if (notOccupiedAssassins.Any(x => x.Value.Item2 < amountOfMoneyParsed
                                              && x.Value.Item3 > amountOfMoneyParsed))
            {
                Console.WriteLine("You successfully hired professional assassin, but it turned out that no one was hunting for you");
                player.AmountOfMoney -= amountOfMoneyParsed;
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
        
    }
}