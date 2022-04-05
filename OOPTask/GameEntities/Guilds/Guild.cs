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
        public MemberEntity ChosenMember { get; set; }
        protected Guild(GuildContext context, string guildName)
        {
            _context = context;
            _guildId = _context.Guilds.FirstOrDefault(x => x.Name == guildName)!.Id;
            _membersId = _context.Members.Where(x => x.GuildId==_guildId).Select(x=>x.Id).ToList();
            _name = _context.Guilds.FirstOrDefault(x => x.Name == guildName)!.Name;
        }
    }
}