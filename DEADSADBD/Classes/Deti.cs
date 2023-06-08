using System;
using System.Collections.Generic;

namespace DEADSADBD.Classes
{
    public partial class Deti
    {
        public int IdDeti { get; set; }
        public string Fio { get; set; } = null!;
        public long NomerOt { get; set; }
        public string Status { get; set; } = null!;
        public int Data { get; set; }
        public int Grup { get; set; }

        public virtual Datum DataNavigation { get; set; } = null!;
        public virtual Grup GrupNavigation { get; set; } = null!;
    }
}
