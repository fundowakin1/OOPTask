using System.Collections.Generic;
using System.Linq;
using OOPTask.Contexts;

namespace OOPTask.GameEntities.Guilds
{
    public abstract class Guild
    {
        protected List<int> _membersId;
        protected string _name;
        protected int _guildId;
        protected int _chosenMemberId;

        protected Guild(GuildContext context, string guildName)
        {
            _guildId = context.Guilds.FirstOrDefault(x => x.Name == guildName)!.Id;
            _membersId = context.Members.Where(x => x.GuildId==_guildId).Select(x=>x.Id).ToList();
            _name = context.Guilds.FirstOrDefault(x => x.Name == guildName)!.Name;
        }
    }
}