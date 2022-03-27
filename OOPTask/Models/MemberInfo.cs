namespace OOPTask
{
    public class MemberInfo
    {
        public int MemberId { get; set; }
        public int AmountOfMoney { get; set; }
        public string Name { get; set; }
        public bool IsMage { get; set; }
        public bool IsVampire { get; set; }

        public Member Member { get; set; }
    }
}