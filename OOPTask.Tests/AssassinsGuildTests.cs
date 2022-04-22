using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OOPTask.Controllers.GuildControllers;
using OOPTask.GameEntities;

namespace OOPTask.Tests
{
    [TestFixture]
    internal class AssassinsGuildTests
    {
        [Test]
        public void ChangingOccupationStatus_WhenCalled_OccupationChanges()
        {
            var  guild = new AssassinsGuild(){
                OccupationDictionary = new Dictionary<int, InfoAboutAssassin>
                {
                    { 1, new InfoAboutAssassin(false, 15.5m, 25.5m) },
                    { 2, new InfoAboutAssassin(false, 15.5m, 25.5m) },
                    { 3, new InfoAboutAssassin(false, 15.5m, 25.5m) },
                    { 4, new InfoAboutAssassin(false, 15.5m, 25.5m) }
                }
            };
            var guildController = new AssassinsGuildController
            {
                _guild = guild,
                
            };

            var testKeys = guild.OccupationDictionary.Values.ToArray();

            guildController.ChangingOccupationStatus();

            var guildKeys = guild.OccupationDictionary.Values.ToArray();

            Assert.AreNotSame(testKeys, guildKeys);

        }

    }
}
