using FaturaYonetimSistemi.Shared.Dtos.KullaniciAidatDto;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Abstract
{
    public interface IKullaniciAidatService
    {
        List<ListKullaniciAidatDto> GetAllKullaniciAidatlar(int kullaniciId);
        KullaniciAidat Get(Expression<Func<KullaniciAidat, bool>> Predicate, params Expression<Func<KullaniciAidat, object>>[] includeProperty);

        void AddKullaniciAidat(InsertKullaniciAidatDto model);
        void UpdateKullaniciAidat(UpdateKullaniciAidatDto model);
        KullaniciAidat SoftDelete(int id);

    }
}
