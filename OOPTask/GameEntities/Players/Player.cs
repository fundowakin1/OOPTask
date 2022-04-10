using System.Linq;
using OOPTask.Contexts;
using OOPTask.Models;

namespace OOPTask.GameEntities.Players
{
    public class Player
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public int AmountOfTurns { get; set; } = 0;
        public decimal AmountOfMoney { get; set; } = 100m;
        public bool IsAlive { get; set; }
        private PlayerContext _context;
        
        

        public Player(string name, string gender, int raceId, PlayerContext context)
        {
            Name = name;
            Gender = gender;
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

            _context = context;
        }

        public void PutPlayerToDb()
        {
            _context.Players.Add(new PlayerEntity
            {
                IsAlive = IsAlive,
                AmountOfTurns = AmountOfTurns
            });
            _context.SaveChanges();
            _context.PlayersInfo.Add(new PlayerInfoEntity
            {
                AmountOfMoney = AmountOfMoney,
                Name = Name,
                Gender = Gender,
                Race = Race,
                PlayerId = _context.Players.Count()
            });
            _context.SaveChanges();
        }
    }
}