using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PlayerCharacterEntity
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
        public int Strength { get; set; }
        [Required]
        public int Dexterity { get; set; }
        [Required]
        public int Constitution { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int Wisdom { get; set; }
        [Required]
        public int Charisma { get; set; }
        [Required]
        public int HitPoints { get; set; }

        [MaxLength(4000, ErrorMessage = "{0} Must be at most {1} characters long.")]
        public string Backstory { get; set; }
        [Required]
        public List<FeatEntity> Feats { get; set; }
        
        [ForeignKey(nameof(Group))]
        public int? GroupId { get; set; }
        public virtual GroupEntity Group { get; set; }

    }
}