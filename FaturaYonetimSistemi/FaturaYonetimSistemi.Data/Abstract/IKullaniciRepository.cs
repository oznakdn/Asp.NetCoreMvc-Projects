using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Shared.Dtos.KullaniciDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Data.Abstract
{
    public interface IKullaniciRepository:IRepository<Kullanici>
    {
        //List<KullaniciAidatlarDto> KullaniciAidatlar(int kullaniciId);
        List<ListKullaniciDto> GetAllKullanicilar();
        DetailKullaniciDto GetDetailKullanici(int kullaniciId);

    }
}
