using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Shared.Dtos.KullaniciFaturaDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Abstract
{
    public interface IKullaniciFaturaRepository:IRepository<KullaniciFatura>
    {
        List<ListKullaniciFaturaDto> GetAllKullaniciFatura(int kullaniciId);
    }
}
