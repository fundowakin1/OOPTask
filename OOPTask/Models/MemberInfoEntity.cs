namespace OOPTask.Models
{
    public class MemberInfoEntity
    {
        public int MemberId { get; set; }
        public decimal AmountOfMoney { get; set; }
        public string Name { get; set; }
        public bool IsMage { get; set; }
        public bool IsVampire { get; set; }

        public virtual MemberEntity MemberEntity { get; set; }
    }
}