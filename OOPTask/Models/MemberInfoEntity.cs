﻿namespace OOPTask
{
    public class MemberInfoEntity
    {
        public int MemberId { get; set; }
        public int AmountOfMoney { get; set; }
        public string Name { get; set; }
        public bool IsMage { get; set; }
        public bool IsVampire { get; set; }

        public MemberEntity MemberEntity { get; set; }
    }
}