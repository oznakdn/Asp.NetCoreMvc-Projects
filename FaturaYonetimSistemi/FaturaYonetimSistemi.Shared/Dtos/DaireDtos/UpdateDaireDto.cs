using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.DaireDtos
{
    public class UpdateDaireDto
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Daire No boş geçilmemelidir!")]
        public short DaireNo { get; set; }

        [Required(ErrorMessage = "Kat No boş geçilmemelidir!")]
        public short Kat { get; set; }

        public bool BosMu { get; set; }
        public string Tipi { get; set; }

     
        public bool SahibiMi { get; set; }

        [Required(ErrorMessage = "BlokId boş geçilmemelidir!")]
        public int Blokid { get; set; }
        public bool AktifMi { get; set; }
    }
}
