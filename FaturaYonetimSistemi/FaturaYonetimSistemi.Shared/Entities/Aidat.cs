using FaturaYonetimSistemi.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Entities
{
    public class Aidat:EntityBase,IEntity
    {
        public string Donem { get; set; }
        public decimal Tutar { get; set; }
        public DateTime SonOdemeTarihi { get; set; }
        public string Aciklama { get; set; }

        public ICollection<KullaniciAidat> KullaniciAidatlar { get; set; }

    }
}
