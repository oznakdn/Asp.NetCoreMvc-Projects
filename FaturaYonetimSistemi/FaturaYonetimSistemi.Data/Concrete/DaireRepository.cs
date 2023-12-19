using FaturaYonetimSistemi.Data.Abstract;
using FaturaYonetimSistemi.Data.Concrete.BaseRepository;
using FaturaYonetimSistemi.Data.Context;
using FaturaYonetimSistemi.Shared.Dtos.DaireDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Concrete
{
    public class DaireRepository : EfRepositoryBase<Daire>, IDaireRepository
    {
        public List<ListDaireDto> GetAllDaireler()
        {
            using var context = new AppDbContext();
            var daireler = from d in context.Daireler
                           join b in context.Bloklar on d.Blokid equals b.ID
                           where(d.AktifMi)
                           select new ListDaireDto
                           {
                               ID=d.ID,
                               DaireNo = d.DaireNo,
                               Kat = d.Kat,
                               BosMu = d.BosMu == true ? "Evet" : "Hayır",
                               Tipi = d.Tipi,
                               SahibiMi = d.SahibiMi == true ? "Evet" : "Hayır",
                               Blok=b.BlokAdi,
                               ToplamDaire=b.ToplamDaire,
                               DoluDaire=DoluDaireSayisi(),
                               BosDaire=BosDaireSayisi()

                           };
            return daireler.ToList();
        }


        public int BosDaireSayisi()
        {
            using var context = new AppDbContext();
            return context.Set<Daire>().Count(x => x.BosMu);

        }

        public int DoluDaireSayisi()
        {
            using var context = new AppDbContext();
            return context.Set<Daire>().Count(x => !x.BosMu);

        }
    }
}
