using AutoMapper;
using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.AidatDtos;
using FaturaYonetimSistemi.Shared.Entities;
using FaturaYonetimSistemi.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Concrete
{
    public class AidatManager : IAidatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AidatManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void SoftDelete(int id)
        {
            var aidat = _unitOfWork.Aidat.GetById(id);

            aidat.AktifMi = false;
            _unitOfWork.Aidat.Update(aidat);

        }

        public Aidat Get(Expression<Func<Aidat, bool>> Predicate, params Expression<Func<Aidat, object>>[] includeProperty)
        {
            return _unitOfWork.Aidat.Get(Predicate, includeProperty);


        }

        public Aidat GetById(int id)
        {
            var aidat = _unitOfWork.Aidat.GetById(id);
            if (aidat == null)
            {
                new Result($"{id} Id Nolu Aidat Bulunamadı", ResultStatus.Hata);
            }
            return _mapper.Map<Aidat>(aidat);

        }

        public void Update(UpdateAidatDto model)
        {
            var aidat = _unitOfWork.Aidat.Get(x => x.ID == model.ID);

            aidat.Donem = model.Donem != default ? model.Donem : aidat.Donem;
            aidat.Tutar = model.Tutar != default ? model.Tutar : aidat.Tutar;
            aidat.SonOdemeTarihi = model.SonOdemeTarihi != default ? model.SonOdemeTarihi : aidat.SonOdemeTarihi;
            aidat.GuncellemeTarihi = DateTime.Now.Date;
            aidat.AktifMi = model.AktifMi != default ? model.AktifMi : aidat.AktifMi;
            aidat.Aciklama = model.Aciklama != default ? model.Aciklama : aidat.Aciklama;

            _unitOfWork.Aidat.Update(aidat);
        }

        public void HardDelete(int id)
        {
            var aidat = _unitOfWork.Aidat.GetById(id);
            _unitOfWork.Aidat.Delete(aidat.ID);
        }

        public List<Aidat> GetAll(Expression<Func<Aidat, bool>> Predicate = null, params Expression<Func<Aidat, object>>[] includeProperty)
        {
            return _unitOfWork.Aidat.GetAll(x => x.AktifMi);

        }

        public void Insert(InsertAidatDto model)
        {
            var aidat = new Aidat
            {
                Donem = model.Donem,
                Tutar = model.Tutar,
                OlusturmaTarihi = DateTime.Now.Date,
                SonOdemeTarihi = model.SonOdemeTarihi,
                AktifMi = model.AktifMi,
                Aciklama = model.Aciklama
            };
            _unitOfWork.Aidat.Insert(aidat);
        }


    }
}
