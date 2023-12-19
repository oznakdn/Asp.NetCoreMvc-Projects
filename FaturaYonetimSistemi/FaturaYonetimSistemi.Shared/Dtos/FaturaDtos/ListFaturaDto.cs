using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.FaturaDtos
{
    public class ListFaturaDto
    {
        public int Id { get; set; }
        public string SonOdemeTarihi { get; set; }
        public string FaturaAdi { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}
