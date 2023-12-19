using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.KullaniciAidatDto
{
    public class UpdateKullaniciAidatDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı ID alanı boş geçilmemelidir!")]
        public int KullaniciId { get; set; }

        [Required(ErrorMessage = "Aidat ID alanı boş geçilmemelidir!")]
        public int AidatId { get; set; }

        [Required(ErrorMessage = "Ödendi Mi alanı boş geçilmemelidir!")]
        public bool OdendiMi { get; set; }
        public Nullable<DateTime> OdenmeTarihi { get; set; }
        public bool AktifMi { get; set; }
    }
}
