using System;
using System.Linq;
using OOPTask.Contexts;
using OOPTask.Enums;
using OOPTask.GameEntities;
using OOPTask.GameEntities.Players;
using OOPTask.Seed.GuildMessages;

namespace OOPTask.Controllers.GuildControllers
{
    public abstract class GuildController
    {
        protected GuildContext _context;
        protected Guild _guild;

        protected GuildController()
        {
        }
        protected GuildController(GuildContext context, Guild guild, string guildName)
        {
            _context = context;
            _guild = guild;
            _guild.GuildId = _context.Guilds.FirstOrDefault(x => x.Name == guildName)!.Id;
            _guild.MembersId = _context.Members.Where(x => x.GuildId== _guild.GuildId).Select(x=>x.Id).ToList();
            _guild.Name = _context.Guilds.FirstOrDefault(x => x.Name == guildName)!.Name;
            GeneralMessages.AddGeneralMessages(_guild.MessagesDictionary);
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
            Guild.NumberOfRetries--;
            if (Guild.NumberOfRetries == 0)
            {
                Console.WriteLine(_guild.MessagesDictionary["EndOfRetriesMessage"]);
                player.IsAlive = false;
                return;
            }
            Console.WriteLine(_guild.MessagesDictionary["VariantsMessage"]);
            Console.WriteLine(_guild.MessagesDictionary["RetriesMessage"] + Guild.NumberOfRetries);
        }

        protected void SetChosenMemberState()
        {
            _guild.MemberState = _guild.ChosenMember.MemberInfoEntity.IsVampire switch
            {
                true when _guild.ChosenMember.MemberInfoEntity.IsMage => ChosenMemberState.VampireMage,
                true => ChosenMemberState.Vampire,
                _ => _guild.ChosenMember.MemberInfoEntity.IsMage ? ChosenMemberState.Mage : ChosenMemberState.Common
            };
        }

        protected void GreetingSpecialChosenMember()
        {
            SetChosenMemberState();
            if (_guild.MemberState !=ChosenMemberState.Common)
            {
                Console.WriteLine(_guild.MessagesDictionary["GreetingSpecialChosenMemberMessage"]);
            }
        }

        private protected void SpecialChosenMemberReaction(string playersAnswer, Player player)
        {
            if (_guild.MemberState == ChosenMemberState.Common || playersAnswer != "3") return;
            switch (_guild.MemberState)
            {
                case ChosenMemberState.Vampire when player.Race == Races.Vampire.ToString():
                    Console.WriteLine(_guild.MessagesDictionary["VampireCaseWonMessage"]);
                    player.HasWon = true;
                    return;
                case ChosenMemberState.Vampire:
                    Console.WriteLine(_guild.MessagesDictionary["VampireCaseLostMessage"]); ;
                    player.IsAlive = false;
                    return;
                case ChosenMemberState.Mage when player.Race == Races.Elven.ToString():
                    Console.WriteLine(_guild.MessagesDictionary["MageCaseLostMessage"]);
                    player.HasWon = true;
                    return;
                case ChosenMemberState.Mage:
                    Console.WriteLine(_guild.MessagesDictionary["MageCaseWonMessage"]);
                    player.IsAlive = false;
                    return;
            }
            Console.WriteLine(_guild.MessagesDictionary["Vampire-mageMessage"]);
            player.IsAlive = false;
        }
    }
}