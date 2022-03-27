namespace OOPTask
{
    public class Member
    {
        public int Id { get; set; }
        public int GuildId { get; set; }
        public Guild Guild { get; set; }
        public MemberInfo MemberInfo { get; set; }
    }
}