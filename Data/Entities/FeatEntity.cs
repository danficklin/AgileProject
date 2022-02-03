using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FeatEntity
    {
        [Key]
        public int FeatId { get; set; }
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
        public DateTime DateAdded { get; set; }
        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public PlayerCharacterEntity Character { get; set; }
    }
}