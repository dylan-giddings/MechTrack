using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Vehicles")]
    public class Vehicle : WarMachine
    {
        public int BaseCruisingMP { get; set; }   
    }
}
