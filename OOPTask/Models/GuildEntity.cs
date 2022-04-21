using System.Collections.Generic;

namespace OOPTask.Models
{
    public class GuildEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MemberEntity> Members { get; set; }
    }
}