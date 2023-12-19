using FaturaYonetimSistemi.OdemeAPI.Entities;
using System.Collections.Generic;

namespace FaturaYonetimSistemi.OdemeAPI.Data
{
    public class FakeData
    {
        public List<Hesap> hesaplar = new List<Hesap>
        {
            new Hesap{MusteriId=1,Ad="Mehmet", Soyad="Koşar",TCNo=45354664546,HesapNo="453563434",HesapBakiye=1000,KartNo="5676 3453 5467 4355",Limit=5000,Borc=2000}
        };
    }
}
