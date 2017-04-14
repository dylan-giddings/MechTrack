using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Force
    {
        public int ForceID { get; set; }
        public string Name { get; set; }
        public ForceType ForceType { get; set; }
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
        [ForeignKey("ParentForce")]
        public int? ParentForceID { get; set; }
        public virtual Force ParentForce { get; set; }
        public virtual ICollection<Force> ChildForces { get; set; }
    }
}
