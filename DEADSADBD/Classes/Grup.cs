using System;
using System.Collections.Generic;

namespace DEADSADBD.Classes
{
    public partial class Grup
    {
        public Grup()
        {
            Detis = new HashSet<Deti>();
        }

        public int IdGrup { get; set; }
        public int Nomer { get; set; }
        public int Vospit { get; set; }

        public virtual Vospit VospitNavigation { get; set; } = null!;
        public virtual ICollection<Deti> Detis { get; set; }
    }
}
