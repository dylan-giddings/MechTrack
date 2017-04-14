using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Machine
    {
        public int MachineID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Tonnage { get; set; }
        public int? CharacterID { get; set; }
        public virtual Character Character { get; set; }
        public int ForceID { get; set; }
        public virtual Force Force { get; set; }
        public virtual List<Location> Locations { get; set; }
    }
}
