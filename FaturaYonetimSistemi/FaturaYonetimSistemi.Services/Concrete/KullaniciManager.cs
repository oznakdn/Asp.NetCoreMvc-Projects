using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.AidatDtos;
using FaturaYonetimSistemi.Shared.Dtos.KullaniciDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KullaniciManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Kullanici Get(Expression<Func<Kullanici, bool>> Predicate, params Expression<Func<Kullanici, object>>[] includeProperty)
        {
            return _unitOfWork.Kullanici.Get(Predicate);
        }

        public List<ListKullaniciDto> GetAllKullanicilar()
        {
            return _unitOfWork.Kullanici.GetAllKullanicilar();
            
        }

        public DetailKullaniciDto GetDetailKullanici(int kullaniciId)
        {
            
            return _unitOfWork.Kullanici.GetDetailKullanici(kullaniciId);
        }

        //public List<KullaniciAidatlarDto> KullaniciAidatlar(int kullaniciId)
        //{
        //    var kullanici = _unitOfWork.Kullanici.GetById(kullaniciId);
        //    return _unitOfWork.Kullanici.KullaniciAidatlar(kullanici.ID);
        //}

        public void AddKullanici(InsertKullaniciDto model)
        {
            var kullanici = new Kullanici
            {
                Ad=model.Ad,
                Soyad=model.Soyad,
                TCNo=model.TCNo,
                Fotograf=model.Fotograf,
                Email=model.Email,
                Telefon=model.Telefon,
                Arac=model.Arac,
                Plaka=model.Plaka,
                DaireId=model.DaireId,
                AktifMi=model.AktifMi,
                OlusturmaTarihi=DateTime.Now.Date
            };

            _unitOfWork.Kullanici.Insert(kullanici);
        }

        public void UpdateKullanici(UpdateKullaniciDto model)
        {
            var kullanici = _unitOfWork.Kullanici.Get(x => x.ID == model.Id);
            kullanici.Ad = model.Ad;
            kullanici.Soyad = model.Soyad;
            kullanici.TCNo = model.TCNo;
            kullanici.Fotograf = model.Fotograf;
            kullanici.Email = model.Email;
            kullanici.Telefon = model.Telefon;
            kullanici.Arac = model.Arac;
            kullanici.Plaka = model.Plaka;
            kullanici.DaireId = model.DaireId;
            kullanici.AktifMi = model.AktifMi;
            kullanici.GuncellemeTarihi = DateTime.Now;

            _unitOfWork.Kullanici.Update(kullanici);
        }

        public Kullanici SoftDelete(int id)
        {
            var kullanici = _unitOfWork.Kullanici.Get(x => x.ID == id);
            kullanici.AktifMi = false;
            return _unitOfWork.Kullanici.Update(kullanici);
        }
    }
}
