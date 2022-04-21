namespace OOPTask.Models
{
    public class MemberEntity
    {
        public int Id { get; set; }
        public int GuildId { get; set; }
        public virtual GuildEntity GuildEntity { get; set; }
        public virtual MemberInfoEntity MemberInfoEntity { get; set; }
    }
}