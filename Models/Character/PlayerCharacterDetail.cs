using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Character
{
    public class PlayerCharacterDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int HitPoints { get; set; }
        public string Backstory { get; set; }
        //public List<Feat> Feats { get; set; }
        //public Group GroupMembership { get; set; }
    }
}