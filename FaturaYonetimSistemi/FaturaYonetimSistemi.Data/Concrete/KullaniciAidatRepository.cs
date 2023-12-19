using FaturaYonetimSistemi.Data.Abstract;
using FaturaYonetimSistemi.Data.Concrete.BaseRepository;
using FaturaYonetimSistemi.Data.Context;
using FaturaYonetimSistemi.Shared.Dtos.KullaniciAidatDto;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Concrete
{
    public class KullaniciAidatRepository:EfRepositoryBase<KullaniciAidat>,IKullaniciAidatRepository
    {
      
        public List<ListKullaniciAidatDto> GetAllKullaniciAidatlar(int kullaniciId)
        {
            using var context = new AppDbContext();
            var kullaniciAidatlar = from a in context.Aidatlar
                                    join ka in context.KullaniciAidatlar
                                    on a.ID equals ka.AidatId
                                    where (ka.KullaniciId == kullaniciId && ka.AktifMi)
                                    select new ListKullaniciAidatDto
                                    {
                                        KullaniciID = ka.KullaniciId,
                                        Id=ka.ID,
                                        Donem = a.Donem,
                                        Tutar = a.Tutar,
                                        SonÖdemeTarihi = a.SonOdemeTarihi.ToShortDateString(),
                                        OdendiMi = ka.OdendiMi==true ? "Ödendi" : "Ödenmedi",
                                        OdenmeTarihi=ka.OdenmeTarihi.ToString()
                                    };
            return kullaniciAidatlar.ToList();

        }
    }
}
