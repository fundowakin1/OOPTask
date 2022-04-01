﻿using System.Collections.Generic;

namespace OOPTask
{
    public class GuildEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MemberEntity> Members { get; set; }
    }
}