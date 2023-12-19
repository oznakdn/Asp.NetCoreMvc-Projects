using FaturaYonetimSistemi.Data.Abstract;
using FaturaYonetimSistemi.Data.Concrete.BaseRepository;
using FaturaYonetimSistemi.Data.Context;
using FaturaYonetimSistemi.Shared.Dtos.FaturaDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Concrete
{
    public class FaturaRepository:EfRepositoryBase<Fatura>, IFaturaRepository
    {
        public List<ListFaturaDto>GetAllFaturalar()
        {
            using var context = new AppDbContext();
            var faturalar = from f in context.Faturalar
                            where(f.AktifMi)
                            select new ListFaturaDto
                            {
                                Id=f.ID,
                                FaturaAdi=f.FaturaAdi,
                                Tutar=f.Tutar,
                                SonOdemeTarihi=f.SonOdemeTarihi.ToShortDateString(),
                                Aciklama=f.Aciklama
                            };
            return faturalar.ToList();
        }
    }
}
