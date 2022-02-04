using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Feat
{
    public class FeatListItem
    {
        public int FeatId { get; set; }
        public string FeatName { get; set; }
        public string FeatShortDescription { get; set; }
        public bool FeatCombatFeat { get; set; }
    }
}