using System;
using System.Collections.Generic;

namespace OOPTask.Guilds
{
    public abstract class Guild
    {
        private List<Member> _members;
        private string _name;
        private Member _chosenMember;

        public void FacingGuild()
        {
            Console.WriteLine($"You have met {_name} guild!");
        }

        public void ChooseMember()
        {
            
        }
    }
}