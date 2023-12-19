using FaturaYonetimSistemi.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Entities
{
    public class Kullanici : EntityBase, IEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public long TCNo { get; set; }
        public string Fotograf { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public bool Arac { get; set; }
        public string Plaka { get; set; } = string.Empty;
        public int DaireId { get; set; }
        public Daire Daire { get; set; }

        public ICollection<KullaniciAidat> KullaniciAidatlar { get; set; }
        public ICollection<KullaniciFatura> KullaniciFaturalar { get; set; }
        public ICollection<Mesaj> Mesajlar { get; set; }

    }
}
