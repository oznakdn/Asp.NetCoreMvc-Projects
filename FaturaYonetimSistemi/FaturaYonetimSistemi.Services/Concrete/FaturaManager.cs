using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.FaturaDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Concrete
{
    public class FaturaManager : IFaturaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FaturaManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ListFaturaDto> GetAllFaturalar()
        {
            return _unitOfWork.Fatura.GetAllFaturalar();
        }

        public void Add(InsertFaturaDto model)
        {
            var fatura = new Fatura
            {
                FaturaAdi=model.FaturaAdi,
                SonOdemeTarihi=model.SonOdemeTarihi,
                Tutar=model.Tutar,
                Aciklama=model.Aciklama,
                AktifMi=model.AktifMi,
                OlusturmaTarihi=DateTime.Now.Date
            };
            _unitOfWork.Fatura.Insert(fatura);
        }

        public void Update(UpdateFaturaDto model)
        {
            var fatura = _unitOfWork.Fatura.Get(x => x.ID == model.Id);
            fatura.FaturaAdi = model.FaturaAdi;
            fatura.Tutar = model.Tutar;
            fatura.SonOdemeTarihi = model.SonOdemeTarihi;
            fatura.Aciklama = model.Aciklama;
            fatura.GuncellemeTarihi = DateTime.Now.Date;

            _unitOfWork.Fatura.Update(fatura);
        }

        public Fatura Get(Expression<Func<Fatura, bool>> Predicate, params Expression<Func<Fatura, object>>[] includeProperty)
        {
            return _unitOfWork.Fatura.Get(Predicate);
        }

        public Fatura SoftDelete(int id)
        {
            var fatura = _unitOfWork.Fatura.Get(x => x.ID == id);
            fatura.AktifMi = false;
            _unitOfWork.Fatura.Update(fatura);
            return fatura;
        }
    }
}
