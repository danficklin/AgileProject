using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Feat
{
    public class FeatCreate
    {
        [Required, MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string FeatName { get; set; }
        public string FeatType { get; set; }
        public string FeatShortDescription { get; set; }
        public string FeatPrerequisites { get; set; } 
        public string FeatBenefits { get; set; }
        public string FeatNormal { get; set; }
        public string FeatSpecial { get; set; }
        [Required]
        public string FeatDescription { get; set; }
        public bool FeatCombatFeat { get; set; }
    }
}