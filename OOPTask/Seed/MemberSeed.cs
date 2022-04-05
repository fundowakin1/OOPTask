using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using OOPTask.Models;

namespace OOPTask.Seed
{
    public class MemberSeed
    {
        private static MemberInfoEntity[] _members = new MemberInfoEntity[]
            {
                new MemberInfoEntity {MemberId = 1, AmountOfMoney = 30, Name = "Joel Martin" , IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 2, AmountOfMoney = 20, Name = "Christopher Washington" , IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 3, AmountOfMoney = 12, Name = "Jaever Ricwil" , IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 4, AmountOfMoney = 19, Name = "Thonygard Da" , IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 5, AmountOfMoney = 10, Name = "Symes Neve" , IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 6, AmountOfMoney = 10, Name = "Gilex Albyng" , IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 7, AmountOfMoney = 10, Name = "Waltin Halle" , IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 8, AmountOfMoney = 10, Name = "Gileon Awlys" , IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 9, AmountOfMoney = 10, Name = "Cuthmund" , IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 10, AmountOfMoney = 10, Name = "Jamart Merde", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 11, AmountOfMoney = 3, Name = "Twitcher", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 12, AmountOfMoney = 2, Name = "Drooler", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 13, AmountOfMoney = 1, Name = "Dribbler", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 14, AmountOfMoney = 1, Name = "Mumbler", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 15, AmountOfMoney = 0.9m, Name = "Mutterer", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 16, AmountOfMoney = 0.8m, Name = "Walking-Along-Shouter", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 17, AmountOfMoney = 0.6m, Name = "Demander of a Chip", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 18, AmountOfMoney = 0.5m, Name = "Person Who Call Other People Jimmy", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 19, AmountOfMoney = 0.08m, Name = "Person Who Need Eightpence For A Meal", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 20, AmountOfMoney = 0.02m, Name = "Person Who Need Tuppence For A Cup Of Tea", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 21, AmountOfMoney = 0, Name = "Person With Placards Saying \"Why lie? I need a beer.\"", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 22, AmountOfMoney = 0.5m, Name = "Muggins", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 23, AmountOfMoney = 1, Name = "Gull", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 24, AmountOfMoney = 2, Name = "Dupe", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 25, AmountOfMoney = 3, Name = "Butt", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 26, AmountOfMoney = 5, Name = "Fool", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 27, AmountOfMoney = 6, Name = "Tomfool", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 28, AmountOfMoney = 7, Name = "Stupid Fool", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 29, AmountOfMoney = 8, Name = "Arch Fool", IsMage = false, IsVampire = false},
                new MemberInfoEntity {MemberId = 30, AmountOfMoney = 10, Name = "Complete Fool", IsMage = false, IsVampire = false}
            };

        private const int QuantityOfVampires = 4;
        private const int QuantityOfMages = 4;   
        public static void Seeding(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<MemberEntity>().HasData(new MemberEntity[]
            {
                new MemberEntity {Id = 1, GuildId = 1},
                new MemberEntity {Id = 2, GuildId = 1},
                new MemberEntity {Id = 3, GuildId = 1},
                new MemberEntity {Id = 4, GuildId = 1},
                new MemberEntity {Id = 5, GuildId = 2},
                new MemberEntity {Id = 6, GuildId = 2},
                new MemberEntity {Id = 7, GuildId = 2},
                new MemberEntity {Id = 8, GuildId = 2},
                new MemberEntity {Id = 9, GuildId = 2},
                new MemberEntity {Id = 10, GuildId = 2},
                new MemberEntity {Id = 11, GuildId = 3},
                new MemberEntity {Id = 12, GuildId = 3},
                new MemberEntity {Id = 13, GuildId = 3},
                new MemberEntity {Id = 14, GuildId = 3},
                new MemberEntity {Id = 15, GuildId = 3},
                new MemberEntity {Id = 16, GuildId = 3},
                new MemberEntity {Id = 17, GuildId = 3},
                new MemberEntity {Id = 18, GuildId = 3},
                new MemberEntity {Id = 19, GuildId = 3},
                new MemberEntity {Id = 20, GuildId = 3},
                new MemberEntity {Id = 21, GuildId = 3},
                new MemberEntity {Id = 22, GuildId = 4},
                new MemberEntity {Id = 23, GuildId = 4},
                new MemberEntity {Id = 24, GuildId = 4},
                new MemberEntity {Id = 25, GuildId = 4},
                new MemberEntity {Id = 26, GuildId = 4},
                new MemberEntity {Id = 27, GuildId = 4},
                new MemberEntity {Id = 28, GuildId = 4},
                new MemberEntity {Id = 29, GuildId = 4},
                new MemberEntity {Id = 30, GuildId = 4}
            });
            ChoosingVampireAndMage();
            modelBuilder.Entity<MemberInfoEntity>().HasData(_members);
        }

        private static void ChoosingVampireAndMage()
        {
            var counter = 0;
            while (counter < QuantityOfVampires+QuantityOfMages)
            {
                var random = RandomNumberGenerator.GetInt32(1, _members.Length);
                if (_members[random].IsVampire==false && counter<QuantityOfVampires)
                {
                    counter++;
                    _members[random].IsVampire = true;
                }
                else if (_members[random].IsMage==false)
                {
                    counter++;
                    _members[random].IsMage = true;
                }
            }
        }
    }
}