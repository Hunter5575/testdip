using System;
using System.Collections.Generic;

namespace DEADSADBD.Classes
{
    public partial class Polzov
    {
        public int IdPolzov { get; set; }
        public string Fio { get; set; } = null!;
        public int IdRoll { get; set; }
        public string Login { get; set; } = null!;
        public string? Password { get; set; }
        public long Nomer { get; set; }
        public string Pochta { get; set; } = null!;

        public virtual Roll IdRollNavigation { get; set; } = null!;
    }
}
