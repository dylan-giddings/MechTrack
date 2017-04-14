using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Equipment")]
    public class Equipment : Item
    {
        public string EquipmentNotes { get; set; }
    }
}
