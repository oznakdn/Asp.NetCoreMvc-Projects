using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.FaturaDtos
{
    public class InsertFaturaDto
    {
       
        public DateTime SonOdemeTarihi { get; set; }
        [Required(ErrorMessage ="Fatura adı boş geçilmemelidir!")]
        public string FaturaAdi { get; set; }

        [Required(ErrorMessage ="Tutar alanı boş geçilmemelidir!")]
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
        public bool AktifMi { get; set; }
    }
}
