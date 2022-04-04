using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
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

        public void InteractionWithPlayersMoney(Player player)
        {
            Console.WriteLine("You found out that you’re under Assassins Guild contract");
            Console.WriteLine("What would you do?");
            Console.WriteLine("You can pay some money to hire an assassin for your protection (type \"1\") or you can pray for your life (type \"2\").");
            ChangingOccupationStatus();
            var notOccupiedAssassins = _occupationDictionary.Where(x => x.Value.Item1).ToList();
            var numberOfRetries = 2;
            while (true)
            {
                var playersAnswer = Console.ReadLine();
                switch (playersAnswer)
                {
                    case "1":
                        Console.WriteLine("Please, tell me how much you can pay for your life? :");
                        var amountOfMoney = Console.ReadLine();
                        if (string.IsNullOrEmpty(amountOfMoney)||string.IsNullOrWhiteSpace(amountOfMoney)
                                                               ||!decimal.TryParse(amountOfMoney,out var amountOfMoneyParsed))
                        {
                            Console.WriteLine("You have your last chance to hire an assassin!");
                            numberOfRetries--;
                            break;
                        }
                        var playersMoney = player.AmountOfMoney;
                        
                        if (player.AmountOfMoney<0)
                        {
                            Console.WriteLine("Your pockets are empty");
                            player.IsAlive = false;
                            break;
                        }
                        else if (notOccupiedAssassins.Any(x => x.Value.Item2 < amountOfMoneyParsed
                                                               && x.Value.Item3 > amountOfMoneyParsed))
                        {
                            Console.WriteLine("You successfully hired professional assassin, but it turned out that no one was hunting for you");
                            player.AmountOfMoney -= amountOfMoneyParsed;
                            break;
                        }

                        Console.WriteLine("There are no assassins for your amount of gold. Try once more.");
                        numberOfRetries--;
                        playersAnswer = " ";
                        break;
                    case "2":
                        player.IsAlive = false;
                        Console.WriteLine("You decided to choose death! Assassin kills you!");
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
        
        private void ChangingOccupationStatus()
        {
            var counter = 0;
            while (counter<_occupationDictionary.Count/2)
            {
                var random = new Random();
                var assassinId = random.Next(0, _occupationDictionary.Count);
                var valueTuple = _occupationDictionary[assassinId];
                if (valueTuple.Item1)
                {
                    valueTuple.Item1 = false;
                    _occupationDictionary[assassinId] = valueTuple;
                    counter++;
                }
            }
        }
    }
}