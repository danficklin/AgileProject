using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Feat
{
    public class FeatDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ShortDescription { get; set; }
        public string Prerequisites { get; set; } // In theory this would be made into a list of some kind
        public string Benefits { get; set; }
        public string Normal { get; set; }
        public string Special { get; set; }
        public string Description { get; set; }
        public bool CombatFeat { get; set; }

        // public string Source { get; set; }  Add later
        public DateTime DateAdded { get; set; }
    }
}