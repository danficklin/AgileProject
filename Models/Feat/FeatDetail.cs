using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Feat
{
    public class FeatDetail
    {
        public int Id { get; set; }
        public string FeatName { get; set; }
        public string FeatType { get; set; }
        public string FeatShortDescription { get; set; }
        public string FeatPrerequisites { get; set; } // In theory this would be made into a list of some kind
        public string FeatBenefits { get; set; }
        public string FeatNormal { get; set; }
        public string FeatSpecial { get; set; }
        public string FeatDescription { get; set; }
        public bool FeatCombatFeat { get; set; }

        // public string Source { get; set; }  Add later
        public DateTime DateAdded { get; set; }
    }
}