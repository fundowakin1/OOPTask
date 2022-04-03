using System;
using System.Collections.Generic;
using OOPTask.Contexts;

namespace OOPTask.GameEntities.Guilds
{
    public class AssassinsGuild : Guild
    {
        private Dictionary<int, bool> _occupationDictionary;
        public AssassinsGuild(GuildContext context, string guildName) : base(context, guildName)
        {
            _occupationDictionary = new Dictionary<int, bool>();
            for (int i = 0; i < _occupationDictionary.Count; i++)
            {
                _occupationDictionary.Add(_membersId[i], true);
            }
        }

        private void ChangingOccupationStatus()
        {
            var counter = 0;
            while (counter<_occupationDictionary.Count/2)
            {
                var random = new Random();
                var assassinId = random.Next(0, _occupationDictionary.Count);
                if (_occupationDictionary[assassinId])
                {
                    _occupationDictionary[assassinId] = false;
                    counter++;
                }
            }
        }
    }
}