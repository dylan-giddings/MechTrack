using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Weapons")]
    public class Weapon : Item
    {
        public int StandardHeatGenerated { get; set; }
        public int StandardDamageValue { get; set; }
        public AmmoType AmmoType { get; set; }
    }
}
