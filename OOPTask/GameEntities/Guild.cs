using System.Collections.Generic;
using OOPTask.Enums;
using OOPTask.Models;

namespace OOPTask.GameEntities
{
    public class Guild
    {
        public List<int> MembersId { get; set; }
        public static int NumberOfRetries = 3;
        public MemberEntity ChosenMember { get; set; }
        public ChosenMemberState MemberState { get; set; }
        public string Name { get; set; }
        public int GuildId { get; set; }
        public Dictionary<string,string> MessagesDictionary { get; set; } = new();

    }
}
