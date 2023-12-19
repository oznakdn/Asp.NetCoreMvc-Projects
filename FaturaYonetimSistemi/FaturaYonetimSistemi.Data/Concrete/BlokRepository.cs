using FaturaYonetimSistemi.Data.Abstract;
using FaturaYonetimSistemi.Data.Concrete.BaseRepository;
using FaturaYonetimSistemi.Data.Context;
using FaturaYonetimSistemi.Shared.Dtos.BlokDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Concrete
{
    public class BlokRepository : EfRepositoryBase<Blok>, IBlokRepository
    {
        public List<ListBlokDto> GetAllBlok(Expression<Func<ListBlokDto, bool>> predicate = null)
        {
            using var context = new AppDbContext();
            var bloklar = from b in context.Bloklar
                          select new ListBlokDto
                          {
                              Id=b.ID,
                              BlokAdi=b.BlokAdi,
                              ToplamDaire=b.ToplamDaire,
                              OlusturmaTarihi=b.OlusturmaTarihi.ToShortDateString(),
                              GuncellemeTarihi=b.GuncellemeTarihi.ToString(),
                              AktifMi=b.AktifMi == true ? "Evet" : "Hayır"
                          };
            return bloklar.Where(predicate).ToList();
                        
        }
    }
}
