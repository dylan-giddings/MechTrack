using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Mechs")]
    public class Mech : WarMachine
    {
        public int BaseWalkingMP { get; set; }
    }
}
