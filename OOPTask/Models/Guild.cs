using System.Collections.Generic;

namespace OOPTask
{
    public class Guild
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Member> Members { get; set; }
    }
}