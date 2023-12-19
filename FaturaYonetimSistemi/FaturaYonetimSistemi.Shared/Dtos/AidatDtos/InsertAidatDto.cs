using FaturaYonetimSistemi.Shared.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.AidatDtos
{
    public class InsertAidatDto
    {
        [Required(ErrorMessage = "Dönem bilgisi boş geçilemez!")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter olmalıdır!")]
        public string Donem { get; set; }


        [Required(ErrorMessage ="Tutar bilgisi boş geçilemez!")]
        public decimal Tutar { get; set; }

        [Required(ErrorMessage = "Son ödeme bilgisi boş geçilemez!")]
        public DateTime SonOdemeTarihi { get; set; }

        public bool AktifMi { get; set; }


        [StringLength(250,ErrorMessage ="Açıklama bilgisi en fazla 250 karakter olmalıdır.")]
        public string Aciklama { get; set; }
    }
}
