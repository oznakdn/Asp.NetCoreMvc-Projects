using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.KullaniciDtos
{
    public class KullaniciAidatlarDto
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public long TCNo { get; set; }
        public short Daire { get; set; }

        [DisplayName("Dönem")]
        public string Donem { get; set; }
        public decimal Tutar { get; set; }

        [DisplayName("Son Ödeme Tarihi")]
        public DateTime SonOdemeTarihi { get; set; }

        [DisplayName("Ödendi Mi?")]
        public bool OdendiMi { get; set; }

        [DisplayName("Ödenme Tarihi")]
        public DateTime? OdenmeTarihi { get; set; }
    }
}
