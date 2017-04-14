using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Ammunition")]
    public class Ammunition : Item
    {
        public AmmoType AmmoType { get; set; }
    }
}
