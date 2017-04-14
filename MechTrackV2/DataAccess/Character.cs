using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Character
    {
        public int CharacterID { get; set; }
        public string Name { get; set; }
        public int PilotingSkill { get; set; }
        public int DrivingSkill { get; set; }
        public int GunnerySkill { get; set; }
        public int TotalExperience { get; set; }
        public int UnspentExperience { get; set; }
        public int MachineID { get; set; }
        [Required]
        public virtual Machine Machine { get; set; }
    }
}
