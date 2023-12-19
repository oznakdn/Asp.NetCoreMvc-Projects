using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.DaireDtos
{
    public class ListDaireDto
    {
        public int ID { get; set; }
        public short DaireNo { get; set; }
        public short Kat { get; set; }
        public string BosMu { get; set; }
        public string Tipi { get; set; }
        public string SahibiMi { get; set; }
        public string Blok { get; set; }
        public int ToplamDaire { get; set; }
        public int DoluDaire { get; set; }
        public int BosDaire { get; set; }


    }
}
