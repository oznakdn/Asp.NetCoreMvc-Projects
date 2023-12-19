using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.KullaniciAidatDto
{
    public class ListKullaniciAidatDto
    {
        public int Id { get; set; }
        public int KullaniciID { get; set; }
        public string Donem { get; set; }
        public decimal Tutar { get; set; }
        public string SonÖdemeTarihi { get; set; }
        public string OdendiMi { get; set; }
        public string OdenmeTarihi { get; set; }
    }
}
