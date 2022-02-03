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
        public string Name { get; set; }
        public string Type { get; set; }
        public string ShortDescription { get; set; }
        public string Prerequisites { get; set; } // In theory this would be made into a list of some kind
        public string Benefits { get; set; }
        public string Normal { get; set; }
        public string Special { get; set; }
        [Required]
        public string Description { get; set; }
        public bool CombatFeat { get; set; }
    }
}