using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Group
{
    public class GroupCreate
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public List<string> GroupMembers { get; set; }
    }
}