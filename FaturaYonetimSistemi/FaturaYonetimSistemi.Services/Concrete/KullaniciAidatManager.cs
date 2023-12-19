using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.KullaniciAidatDto;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Concrete
{
    public class KullaniciAidatManager : IKullaniciAidatService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KullaniciAidatManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        public KullaniciAidat Get(Expression<Func<KullaniciAidat, bool>> Predicate, params Expression<Func<KullaniciAidat, object>>[] includeProperty)
        {
            return _unitOfWork.KullaniciAidat.Get(Predicate);
        }

        public List<ListKullaniciAidatDto> GetAllKullaniciAidatlar(int kullaniciId)
        {
            return _unitOfWork.KullaniciAidat.GetAllKullaniciAidatlar(kullaniciId);
        }

        public void AddKullaniciAidat(InsertKullaniciAidatDto model)
        {
            var kullaniciAidat = new KullaniciAidat
            {
                
                KullaniciId = model.KullaniciId,
                AidatId = model.AidatId,
                OdendiMi = model.OdendiMi,
                OdenmeTarihi = model.OdenmeTarihi,
                AktifMi = model.AktifMi,
                OlusturmaTarihi=DateTime.Now.Date
            };

            _unitOfWork.KullaniciAidat.Insert(kullaniciAidat);
           
        }

        public void UpdateKullaniciAidat(UpdateKullaniciAidatDto model)
        {
            var kullaniciAidat = _unitOfWork.KullaniciAidat.Get(x => x.ID==model.Id);

            kullaniciAidat.KullaniciId = model.KullaniciId;
            kullaniciAidat.AidatId = model.AidatId;
            kullaniciAidat.OdendiMi = model.OdendiMi;
            kullaniciAidat.OdenmeTarihi = model.OdenmeTarihi;
            kullaniciAidat.AktifMi = model.AktifMi;
            kullaniciAidat.GuncellemeTarihi = DateTime.Now;
            _unitOfWork.KullaniciAidat.Update(kullaniciAidat);
        }

        public KullaniciAidat SoftDelete(int id)
        {
            var kullaniciAidat = _unitOfWork.KullaniciAidat.Get(x => x.ID == id);
            kullaniciAidat.AktifMi = false;
            _unitOfWork.KullaniciAidat.Update(kullaniciAidat);
            return kullaniciAidat;
        }
    }
}
