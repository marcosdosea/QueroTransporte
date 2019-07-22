using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class RotaFrota
    {
        public int Frota { get; set; }
        public int Rota { get; set; }

        public virtual Frota FrotaNavigation { get; set; }
        public virtual Rota RotaNavigation { get; set; }
    }
}
