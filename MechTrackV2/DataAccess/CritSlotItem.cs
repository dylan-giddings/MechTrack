using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CritSlotItem
    {
        public int CritSlotItemID { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public int MaxQuantity { get; set; }
        public int CurrentQuantity { get; set; }
    }
}
