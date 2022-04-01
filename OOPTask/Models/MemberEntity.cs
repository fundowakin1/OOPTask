namespace OOPTask
{
    public class MemberEntity
    {
        public int Id { get; set; }
        public int GuildId { get; set; }
        public GuildEntity GuildEntity { get; set; }
        public MemberInfoEntity MemberInfoEntity { get; set; }
    }
}