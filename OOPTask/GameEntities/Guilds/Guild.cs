using System;
using System.Collections.Generic;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.GameEntities.Players;
using OOPTask.Models;

namespace OOPTask.GameEntities.Guilds
{
    public abstract class Guild
    {
        protected List<int> _membersId;
        protected string _name;
        protected int _guildId;
        protected GuildContext _context;
        protected static int _numberOfRetries = 3;
        public MemberEntity ChosenMember { get; set; }
        protected ChosenMemberState MemberState { get; set; }
        protected Guild(GuildContext context, string guildName)
        {
            _context = context;
            _guildId = _context.Guilds.FirstOrDefault(x => x.Name == guildName)!.Id;
            _membersId = _context.Members.Where(x => x.GuildId==_guildId).Select(x=>x.Id).ToList();
            _name = _context.Guilds.FirstOrDefault(x => x.Name == guildName)!.Name;
        }

        public virtual void InteractionWithPlayer(Player player)
        {
            GreetingMessage();
            InteractionWithPlayersMoney(player);
        }

        private protected abstract void GreetingMessage();
        private protected abstract void InteractionWithPlayersMoney(Player player);
        private protected abstract void PositivePlayersAnswer(Player player);
        private protected abstract void NegativePlayersAnswer(Player player);
        private protected virtual void DefaultPlayersAnswer(Player player)
        {
            _numberOfRetries--;
            if (_numberOfRetries==0)
            {
                Console.WriteLine("You should have followed instructions and haven't written this bullshit!");
                player.IsAlive = false;
                return;
            }
            Console.WriteLine("Please, write 1 or 2!");
            Console.WriteLine($"Number of retries: {_numberOfRetries}");
        }

        protected void SetChosenMemberState()
        {
            MemberState = ChosenMember.MemberInfoEntity.IsVampire switch
            {
                true when ChosenMember.MemberInfoEntity.IsMage => ChosenMemberState.VampireMage,
                true => ChosenMemberState.Vampire,
                _ => ChosenMember.MemberInfoEntity.IsMage ? ChosenMemberState.Mage : ChosenMemberState.Common
            };
        }

        protected void GreetingSpecialChosenMember()
        {
            SetChosenMemberState();
            if (MemberState!=ChosenMemberState.Common)
            {
                Console.WriteLine("You feel some strange aura which emanates from this creep... (type \"3\" to find out what it is)");
            }
        }

        private protected void SpecialChosenMemberReaction(string playersAnswer, Player player)
        {
            if (MemberState == ChosenMemberState.Common || playersAnswer != "3") return;
            switch (MemberState)
            {
                case ChosenMemberState.Vampire when player.Race == Races.Vampire.ToString():
                    Console.WriteLine("You have met another vampire. After a long battle you won. His power now yours!");
                    player.HasWon = true;
                    return;
                case ChosenMemberState.Vampire:
                    Console.WriteLine("Oh no, this is vampire! You die(");
                    player.IsAlive = false;
                    return;
                case ChosenMemberState.Mage when player.Race == Races.Elven.ToString():
                    Console.WriteLine("You have met mage. You thought that fighting him will be a good practice for you!\nYou have won! But city has burnt(");
                    player.HasWon = true;
                    return;
                case ChosenMemberState.Mage:
                    Console.WriteLine("Oh no, this is mage! He made from you a well-done steak(");
                    player.IsAlive = false;
                    return;
            }
            Console.WriteLine("Oh no, this is vampire-mage! He made from you a medium-rare steak. You will be great meal for him");
            player.IsAlive = false;
        }

        protected enum ChosenMemberState
        {
            Vampire,
            Mage, 
            VampireMage,
            Common
        }
    }
}