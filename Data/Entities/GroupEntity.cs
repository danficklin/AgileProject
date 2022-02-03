using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class GroupEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public List<string> GroupMembers { get; set; }

    }
}