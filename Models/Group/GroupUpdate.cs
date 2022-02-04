using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Character;

namespace Models.Group
{
    public class GroupUpdate
    {
        public string GroupName { get; set; }
        public List<PlayerCharacterList> GroupPlayerCharacters { get; set; }
    }
}