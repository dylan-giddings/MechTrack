using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Force> Forces { get; set; }
        public virtual ICollection<PlayerNote> PlayerNotes { get; set; }

    }
}
