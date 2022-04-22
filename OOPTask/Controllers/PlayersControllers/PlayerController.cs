using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities.Players;
using OOPTask.Models;

namespace OOPTask.Controllers.PlayersControllers
{
    public class PlayerController
    {
        private Player _player;
        private readonly PlayerContext _context;

        public PlayerController(Player player, PlayerContext context)
        {
            _player = player;
            _context = context;
        }
        public void PutPlayerToDb()
        {
            _context.Players.Add(new PlayerEntity
            {
                IsAlive = _player.IsAlive,
                AmountOfTurns = _player.AmountOfTurns,
                HasWon = _player.HasWon,
            });
            _context.SaveChanges();
            _context.PlayersInfo.Add(new PlayerInfoEntity
            {
                AmountOfMoney = _player.AmountOfMoney,
                Name = _player.Name,
                Race = _player.Race,
                PlayerId = _context.Players.Count()
            });
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}
