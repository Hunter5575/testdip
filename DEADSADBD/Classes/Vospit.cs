using System;
using System.Collections.Generic;

namespace DEADSADBD.Classes
{
    public partial class Vospit
    {
        public Vospit()
        {
            Grups = new HashSet<Grup>();
        }

        public int IdVospit { get; set; }
        public string Fio { get; set; } = null!;
        public long Nomer { get; set; }
        public string Grup { get; set; } = null!;
        public int IdRols { get; set; }
        public string? Login { get; set; }
        public string? Passvord { get; set; }

        public virtual Roll IdRolsNavigation { get; set; } = null!;
        public virtual ICollection<Grup> Grups { get; set; }
    }
}
