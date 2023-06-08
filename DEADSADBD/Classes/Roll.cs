using System;
using System.Collections.Generic;

namespace DEADSADBD.Classes
{
    public partial class Roll
    {
        public Roll()
        {
            Polzovs = new HashSet<Polzov>();
            Vospits = new HashSet<Vospit>();
        }

        public int IdRoll { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Polzov> Polzovs { get; set; }
        public virtual ICollection<Vospit> Vospits { get; set; }
    }
}
