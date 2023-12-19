using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.KullaniciDtos
{
    public class DetailKullaniciDto
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public long TCNo { get; set; }
        public string Fotograf { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Arac { get; set; }
        public string Plaka { get; set; }
        public short DaireNo { get; set; }
        public short Kat { get; set; }
        public string DaireTipi { get; set; }
        public string SahibiMi { get; set; }
       
    }
}
