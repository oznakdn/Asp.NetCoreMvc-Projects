using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Data.Context;
using FaturaYonetimSistemi.Shared.Dtos.KullaniciAidatDto;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Abstract
{
    public interface IKullaniciAidatRepository:IRepository<KullaniciAidat>
    {
        List<ListKullaniciAidatDto> GetAllKullaniciAidatlar(int kullaniciId);
    }
}
