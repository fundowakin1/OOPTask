using System.Collections.Generic;
using OOPTask.Controllers.GuildControllers;

namespace OOPTask.GameEntities
{
    public class AssassinsGuild : Guild
    {
        public const decimal Delta = 10;
        public Dictionary<int, InfoAboutAssassin> OccupationDictionary { get; set; }
    }
    public class InfoAboutAssassin
    {
        public bool IsOccupied { get; set; }
        public decimal LowerFeeBound { get; set; }
        public decimal UpperFeeBound { get; set; }

        public InfoAboutAssassin(bool isOccupied, decimal lowerFeeBound, decimal upperFeeBound)
        {
            IsOccupied = isOccupied;
            LowerFeeBound = lowerFeeBound;
            UpperFeeBound = upperFeeBound;
        }
    }
}
