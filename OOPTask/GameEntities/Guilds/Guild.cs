using System;
using System.Collections.Generic;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities.Players;
using OOPTask.Models;

namespace OOPTask.GameEntities.Guilds
{
    public abstract class Guild
    {
        protected List<int> _membersId;
        protected string _name;
        protected int _guildId;
        protected GuildContext _context;
        protected static int _numberOfRetries = 3;
        public MemberEntity ChosenMember { get; set; }
        protected Guild(GuildContext context, string guildName)
        {
            _context = context;
            _guildId = _context.Guilds.FirstOrDefault(x => x.Name == guildName)!.Id;
            _membersId = _context.Members.Where(x => x.GuildId==_guildId).Select(x=>x.Id).ToList();
            _name = _context.Guilds.FirstOrDefault(x => x.Name == guildName)!.Name;
        }

        public virtual void InteractionWithPlayer(Player player)
        {
            GreetingMessage();
            InteractionWithPlayersMoney(player);
        }

        private protected abstract void GreetingMessage();
        private protected abstract void InteractionWithPlayersMoney(Player player);
        private protected abstract void PositivePlayersAnswer(Player player);
        private protected abstract void NegativePlayersAnswer(Player player);
        private protected virtual void DefaultPlayersAnswer(Player player)
        {
            _numberOfRetries--;
            if (_numberOfRetries==0)
            {
                Console.WriteLine("You should have followed instructions and haven't written this bullshit!");
                player.IsAlive = false;
                return;
            }
            Console.WriteLine("Please, write 1 or 2!");
            Console.WriteLine($"Number of retries: {_numberOfRetries}");
        }
    }
}