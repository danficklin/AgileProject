using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Feat
{
    public class FeatEdit
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string FeatName { get; set; }
        public string FeatType { get; set; }
        public string FeatShortDescription { get; set; }
        public string FeatPrerequisites { get; set; } // In theory this would be made into a list of some kind
        public string FeatBenefits { get; set; }
        public string FeatNormal { get; set; }
        public string FeatSpecial { get; set; }
        [Required]
        public string FeatDescription { get; set; }
        public bool FeatCombatFeat { get; set; }
    }
}