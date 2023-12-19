using FaturaYonetimSistemi.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Entities
{
    public class Blok:EntityBase,IEntity
    {
        public string BlokAdi { get; set; }
        public short ToplamDaire { get; set; }
        public virtual ICollection<Daire> Daireler { get; set; }
    }
}
