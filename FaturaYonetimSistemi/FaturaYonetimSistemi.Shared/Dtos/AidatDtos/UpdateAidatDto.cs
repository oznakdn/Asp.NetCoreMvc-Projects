using FaturaYonetimSistemi.Shared.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.AidatDtos
{
    public class UpdateAidatDto
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter olmalıdır!")]
        public string Donem { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public decimal Tutar { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public bool AktifMi { get; set; }

        public DateTime SonOdemeTarihi { get; set; }

        [StringLength(250)]
        public string Aciklama { get; set; }
    }
}
