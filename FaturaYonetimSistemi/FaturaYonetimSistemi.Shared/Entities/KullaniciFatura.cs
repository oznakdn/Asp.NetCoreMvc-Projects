using FaturaYonetimSistemi.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Entities
{
    public class KullaniciFatura : EntityBase, IEntity
    {
        public int KullaniciId { get; set; }
        public int FaturaId { get; set; }

        public Kullanici Kullanici { get; set; }
        public Fatura Fatura { get; set; }

        public bool OdendiMi { get; set; } = false;
        public DateTime? OdemeTarihi { get; set; }
    }
}
