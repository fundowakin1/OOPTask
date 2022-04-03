using System;
using OOPTask.Contexts;
using OOPTask.Models;

namespace OOPTask.GameEntities.Guilds
{
    public class BeggarsGuild : Guild, IChoosingMember 
    {
        public MemberEntity ChosenMember { get; set; }
        public BeggarsGuild(GuildContext context, string guildName) : base(context, guildName)
        {
        }
        public void ChoosingMember()
        {
            var random = new Random();
            var chosenMemberId = random.Next(0, _membersId.Count);
            
        }

        
    }
}