using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.BlokDtos
{
    public class ListBlokDto
    {
        public int Id { get; set; }
        public string BlokAdi { get; set; }
        public short ToplamDaire { get; set; }
        public string AktifMi { get; set; }
        public string OlusturmaTarihi { get; set; }
        public string GuncellemeTarihi { get; set; }

    }
}
