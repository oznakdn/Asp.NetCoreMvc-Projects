using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Base
{
    public abstract class EntityBase
    {
        public int ID { get; set; }
        public bool AktifMi { get; set; } = true;
        public virtual DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public virtual DateTime? GuncellemeTarihi { get; set; }

    }
}
