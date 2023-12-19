using FaturaYonetimSistemi.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Entities
{
    public class KullaniciAidat:EntityBase,IEntity
    {
        public int KullaniciId { get; set; }
        public int AidatId { get; set; }
        public Kullanici Kullanici { get; set; }
        public Aidat Aidat { get; set; }

        public bool OdendiMi { get; set; } = false;
        public DateTime? OdenmeTarihi { get; set; }
    }
}
