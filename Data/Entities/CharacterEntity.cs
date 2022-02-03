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
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Race { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public Dictionary<string, int> Attributes { get; set; }
        [Required]
        public string Backstory { get; set; }
        //public List<Feat> Feats { get; set; }
        //public Group GroupMembership { get; set; }

    }
}