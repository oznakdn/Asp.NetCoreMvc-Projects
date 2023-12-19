using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.BlokDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Concrete
{
    public class BlokManager : IBlokService
    {

        private readonly IUnitOfWork _unitOfWork;

        public BlokManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddBlok(InsertBlokDto model)
        {
            var blok = new Blok
            {
                BlokAdi=model.BlokAdi,
                ToplamDaire=model.ToplamDaire,
                OlusturmaTarihi=DateTime.Now.Date,
                AktifMi=model.AktifMi
            };

            _unitOfWork.Blok.Insert(blok);
        }

        public void UpdateBlok(UpdateBlokDto model)
        {
            var blok = _unitOfWork.Blok.Get(x => x.ID == model.Id);
            blok.BlokAdi = model.BlokAdi;
            blok.ToplamDaire = model.ToplamDaire;
            blok.AktifMi = model.AktifMi;
            blok.GuncellemeTarihi = DateTime.Now;
            _unitOfWork.Blok.Update(blok);
        }

        public List<ListBlokDto> GetAllBlok(Expression<Func<ListBlokDto, bool>> predicate = null)
        {
            return _unitOfWork.Blok.GetAllBlok(x => x.AktifMi=="Evet");
        }

        public Blok Get(Expression<Func<Blok, bool>> Predicate, params Expression<Func<Blok, object>>[] includeProperty)
        {
            return _unitOfWork.Blok.Get(Predicate);
        }

        public Blok SoftDelete(int id)
        {
            var blok = _unitOfWork.Blok.Get(x => x.ID == id);
            blok.AktifMi = false;
            return _unitOfWork.Blok.Update(blok);
        }
    }
}
