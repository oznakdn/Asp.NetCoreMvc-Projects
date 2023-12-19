using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.DaireDtos;
using FaturaYonetimSistemi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Concrete
{
    public class DaireManager : IDaireService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DaireManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ListDaireDto> GetAllDaireler()
        {
            return _unitOfWork.Daire.GetAllDaireler();
        }

        public void AddDaire(InsertDaireDto model)
        {
            var daire = new Daire
            {
                Blokid = model.Blokid,
                DaireNo = model.DaireNo,
                Kat = model.Kat,
                BosMu = model.BosMu,
                Tipi = model.Tipi,
                SahibiMi = model.SahibiMi,
                AktifMi = model.AktifMi,
                OlusturmaTarihi = DateTime.Now.Date,
            };
            _unitOfWork.Daire.Insert(daire);
        }

        public void UpdateDaire(UpdateDaireDto model)
        {
            var daire = _unitOfWork.Daire.Get(x => x.ID == model.ID);
            daire.Blokid = model.Blokid;
            daire.DaireNo = model.DaireNo;
            daire.Kat = model.Kat;
            daire.Tipi = model.Tipi;
            daire.SahibiMi = model.SahibiMi;
            daire.BosMu = model.BosMu;
            daire.AktifMi = model.AktifMi;
            daire.GuncellemeTarihi = DateTime.Now.Date;
            _unitOfWork.Daire.Update(daire);
        }

        public Daire Get(Expression<Func<Daire, bool>> Predicate, params Expression<Func<Daire, object>>[] includeProperty)
        {
            return _unitOfWork.Daire.Get(Predicate);
        }

        public Daire SoftDelete(int id)
        {
            var daire = _unitOfWork.Daire.Get(x => x.ID == id);
            daire.AktifMi = false;
           return _unitOfWork.Daire.Update(daire);
        }
    }
}
