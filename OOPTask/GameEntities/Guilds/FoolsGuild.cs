using System;
using OOPTask.Contexts;

namespace OOPTask.GameEntities.Guilds
{
    public class FoolsGuild : Guild, IChoosingMember 
    {
        public FoolsGuild(GuildContext context, string guildName) : base(context, guildName)
        {
        }
        public void ChoosingMember()
        {
            var random = new Random();
            _chosenMemberId = random.Next(0, _membersId.Count);
        }
    }
}