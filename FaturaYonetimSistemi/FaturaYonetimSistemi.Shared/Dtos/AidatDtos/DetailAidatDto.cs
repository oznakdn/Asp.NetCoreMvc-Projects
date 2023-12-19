using FaturaYonetimSistemi.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.AidatDtos
{
    public class DetailAidatDto:DtoBase
    {
        public int ID { get; set; }
        public string Donem { get; set; }
        public decimal Tutar { get; set; }
        public DateTime SonOdemeTarihi { get; set; }
        public string Aciklama { get; set; }
    }
}
