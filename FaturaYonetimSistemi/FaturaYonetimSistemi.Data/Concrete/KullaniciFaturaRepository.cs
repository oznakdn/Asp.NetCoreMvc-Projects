using FaturaYonetimSistemi.Data.Abstract;
using FaturaYonetimSistemi.Data.Concrete.BaseRepository;
using FaturaYonetimSistemi.Data.Context;
using FaturaYonetimSistemi.Shared.Dtos.KullaniciFaturaDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Concrete
{
    public class KullaniciFaturaRepository:EfRepositoryBase<Shared.Entities.KullaniciFatura>,IKullaniciFaturaRepository
    {
        public List<ListKullaniciFaturaDto>GetAllKullaniciFatura(int kullaniciId)
        {
            using var context= new AppDbContext();
            var kullaniciFaturalar = (from f in context.Faturalar
                                      join kf in context.KullaniciFaturalar on f.ID equals kf.FaturaId
                                      where (kf.KullaniciId == kullaniciId && kf.AktifMi)
                                      select new ListKullaniciFaturaDto
                                      {
                                          KullaniciID=kf.KullaniciId,
                                          Id = kf.ID,
                                          SonÖdemeTarihi = f.SonOdemeTarihi.ToShortDateString(),
                                          Tutar = f.Tutar,
                                          OdendiMi = kf.OdendiMi == true ? "Ödendi" : "Ödenmedi",
                                          OdenmeTarihi = kf.OdemeTarihi.ToString()
                                      }).ToList();
            return kullaniciFaturalar;
        }
    }
}
