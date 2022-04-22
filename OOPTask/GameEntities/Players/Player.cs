using System.Linq;
using OOPTask.Contexts;
using OOPTask.Enums;
using OOPTask.Models;

namespace OOPTask.GameEntities.Players
{
    public class Player
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public int AmountOfTurns { get; set; } = 0;
        public bool HasWon { get; set; } = false;
        public decimal AmountOfMoney { get; set; } = 100m;
        public bool IsAlive { get; set; }
        

        public Player()
        {
        }

        public Player(string name, int raceId, PlayerContext context)
        {
            Name = name;
            IsAlive = true;
            Race = raceId switch
            {
                1 => Races.Human.ToString(),
                2 => Races.Elven.ToString(),
                3 => Races.Gnome.ToString(),
                4 => Races.Vampire.ToString(),
                _ => Races.Human.ToString()
            };
            if (string.Equals(Race, "Elven"))
            {
                AmountOfMoney = 150m;
            }
        }
        public void ReceiveMoney(decimal money)
        {
            AmountOfMoney += money;
        }

        public void GiveMoney(decimal money)
        {
            AmountOfMoney -= money;
        }
    }
}