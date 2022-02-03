using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class CharacterEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "{0} Must be at least {1} characters long.")]
        [MaxLength(50, ErrorMessage = "{0} Must be at most {1} characters long.")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "{0} Must be at least {1} characters long.")]
        [MaxLength(50, ErrorMessage = "{0} Must be at most {1} characters long.")]
        public string Class { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "{0} Must be at least {1} characters long.")]
        [MaxLength(50, ErrorMessage = "{0} Must be at most {1} characters long.")]
        public string Race { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public Dictionary<string, int> Attributes { get; set; }

        
        public string Backstory { get; set; }
        //public List<Feat> Feats { get; set; }
        //public Group GroupMembership { get; set; }

    }
}