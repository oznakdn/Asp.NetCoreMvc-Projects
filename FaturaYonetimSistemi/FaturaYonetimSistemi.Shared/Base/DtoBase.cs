using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Base
{
    public abstract class DtoBase
    {
        public bool AktifMi { get; set; }
        public virtual DateTime OlusturmaTarihi { get; set; }
        public virtual DateTime? GuncellemeTarihi { get; set; }
    }
}
