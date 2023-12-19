using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.BlokDtos
{
    public class InsertBlokDto
    {
        [Required(ErrorMessage ="Blok Adı alanı boş geçilmemelidir!")]
        public string BlokAdi { get; set; }

        [Required(ErrorMessage = "Toplam Daire alanı boş geçilmemelidir!")]
        public short ToplamDaire { get; set; }
        public bool AktifMi { get; set; }
    }
}
