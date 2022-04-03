using System.Collections.Generic;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities.Players;

namespace OOPTask.GameEntities.Guilds
{
    public abstract class Guild
    {
        protected List<int> _membersId;
        protected string _name;
        protected int _guildId;
        protected GuildContext _context;
        protected Guild(GuildContext context, string guildName)
        {
            _context = context;
            _guildId = _context.Guilds.FirstOrDefault(x => x.Name == guildName)!.Id;
            _membersId = _context.Members.Where(x => x.GuildId==_guildId).Select(x=>x.Id).ToList();
            _name = _context.Guilds.FirstOrDefault(x => x.Name == guildName)!.Name;
        }

        protected void InteractionWithPlayersMoney(Player player)
        {
            
        }
    }
}