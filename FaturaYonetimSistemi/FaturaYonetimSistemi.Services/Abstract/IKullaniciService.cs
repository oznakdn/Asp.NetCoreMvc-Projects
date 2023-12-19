using FaturaYonetimSistemi.Shared.Dtos.AidatDtos;
using FaturaYonetimSistemi.Shared.Dtos.KullaniciDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Abstract
{
    public interface IKullaniciService
    {
        //List<KullaniciAidatlarDto> KullaniciAidatlar(int kullaniciId);
        List<ListKullaniciDto> GetAllKullanicilar();
        DetailKullaniciDto GetDetailKullanici(int kullaniciId);
        Kullanici Get(Expression<Func<Kullanici, bool>> Predicate, params Expression<Func<Kullanici, object>>[] includeProperty);
        void AddKullanici(InsertKullaniciDto model);
        void UpdateKullanici(UpdateKullaniciDto model);
        Kullanici SoftDelete(int id);

    }
}
