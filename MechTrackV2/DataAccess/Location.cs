using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }
        public int MachineID { get; set; }
        public LocationType LocationType { get; set; }
        public List<CritSlot> CritSlots { get; set; }                    
    }
}
