using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FeatEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
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
        public DateTime DateAdded { get; set; }
    }
}