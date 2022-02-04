using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Models.Group;

namespace Models.Character
{
    public class PlayerCharacterUpdate
    {
        [Required]
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
        [Required]
        public string Backstory { get; set; }
        //public List<Feat> Feats { get; set; }
        public GroupListItem GroupMembership { get; set; }
    }
}