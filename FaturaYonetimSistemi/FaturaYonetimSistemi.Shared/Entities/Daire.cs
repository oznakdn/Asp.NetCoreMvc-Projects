using FaturaYonetimSistemi.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Entities
{
    public class Daire:EntityBase,IEntity
    {
        public short DaireNo { get; set; }
        public short Kat { get; set; }
        public bool BosMu { get; set; } = true;
        public string Tipi { get; set; }
        public bool? SahibiMi { get; set; }
        public int Blokid { get; set; }
        public virtual Blok Blok { get; set; }


    }
}
