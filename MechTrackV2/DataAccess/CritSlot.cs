using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CritSlot
    {
        public int CritSlotID { get; set; }
        public int LocationID { get; set; }
        public int? CritSlotItemID { get; set; }
        public virtual CritSlotItem CritSlotItem { get; set;}
    }
}
