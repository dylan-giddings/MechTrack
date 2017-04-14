using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PlayerNote
    {
        public int PlayerNoteID { get; set; }
        public string Note { get; set; }
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }
    }
}
