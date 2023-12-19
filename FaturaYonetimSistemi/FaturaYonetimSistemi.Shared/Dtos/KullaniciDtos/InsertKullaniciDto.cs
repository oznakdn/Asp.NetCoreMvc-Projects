using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.KullaniciDtos
{
    public class InsertKullaniciDto
    {

        [Required(ErrorMessage ="Ad alanı boş olmamalı!")]
        [StringLength(30,ErrorMessage ="Ad alanı 30 karakterden fazla olmamalı!")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş olmamalı!")]
        [StringLength(30, ErrorMessage = "Soyad alanı 30 karakterden fazla olmamalı!")]
        public string Soyad { get; set; }


        [Required(ErrorMessage = "TC No alanı boş olmamalı!")]
        public long TCNo { get; set; }

        public string Fotograf { get; set; }

        [Required(ErrorMessage = "Email alanı boş olmamalı!")]
        [StringLength(50, ErrorMessage = "Email alanı 50 karakterden fazla olmamalı!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş olmamalı!")]
        [StringLength(11, ErrorMessage = "Telefon alanı 11 karakterden fazla olmamalı!")]
        public string Telefon { get; set; }
        public bool Arac { get; set; }
        public string Plaka { get; set; }

        [Required(ErrorMessage = "Daire alanı boş olmamalı!")]
        public int DaireId { get; set; }
        public bool AktifMi { get; set; }

    }
}
