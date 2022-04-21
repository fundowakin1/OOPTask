using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OOPTask.GameEntities.Guilds;

namespace OOPTask.Tests
{
    [TestFixture]
    internal class AssassinsGuildTests
    {
        [Test]
        public void ChangingOccupationStatus_WhenCalled_OccupationChanges()
        {
            var guild = new AssassinsGuild
            {
                OccupationDictionary = new Dictionary<int, InfoAboutAssassin>
                {
                    { 1, new InfoAboutAssassin(false, 15.5m, 25.5m) },
                    { 2, new InfoAboutAssassin(false, 15.5m, 25.5m) },
                    { 3, new InfoAboutAssassin(false, 15.5m, 25.5m) },
                    { 4, new InfoAboutAssassin(false, 15.5m, 25.5m) }
                }
            };

            var testKeys = guild.OccupationDictionary.Values.ToArray();

            guild.ChangingOccupationStatus();

            var guildKeys = guild.OccupationDictionary.Values.ToArray();

            Assert.AreNotSame(testKeys, guildKeys);

        }

    }
}
