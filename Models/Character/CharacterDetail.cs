using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Character
{
    public class CharacterDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public int Level { get; set; }
        public Dictionary<string, int> Attributes { get; set; }
        public string Backstory { get; set; }
        //public List<Feat> Feats { get; set; }
        //public Group GroupMembership { get; set; }
    }
}