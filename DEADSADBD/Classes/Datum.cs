using System;
using System.Collections.Generic;

namespace DEADSADBD.Classes
{
    public partial class Datum
    {
        public Datum()
        {
            Detis = new HashSet<Deti>();
        }

        public DateTime Data { get; set; }
        public int IdData { get; set; }

        public virtual ICollection<Deti> Detis { get; set; }
    }
}
