using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Character
{
    public class AddPlayerToGroup
    {
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
}