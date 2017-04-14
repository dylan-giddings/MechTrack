using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("WarMachines")]
    public class WarMachine : Machine
    {
        public string WarMachineNotes { get; set; }
    }
}
