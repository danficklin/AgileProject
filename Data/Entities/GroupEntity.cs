using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Models.Character;

namespace Data.Entities
{
    public class GroupEntity
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "{0} Must be at least {1} characters long.")]
        [MaxLength(50, ErrorMessage = "{0} Must be at most {1} characters long.")]
        public string GroupName { get; set; }

        
        public List<PlayerCharacterList> GroupMembers { get; set; }

    }
}