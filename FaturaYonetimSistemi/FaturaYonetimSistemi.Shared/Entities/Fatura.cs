using FaturaYonetimSistemi.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Entities
{
    public class Fatura:EntityBase,IEntity
    {
        public DateTime SonOdemeTarihi { get; set; }
        public string FaturaAdi { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }

        public ICollection<KullaniciFatura> KullaniciFaturalar { get; set; }


    }
}
