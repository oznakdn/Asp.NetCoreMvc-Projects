using FaturaYonetimSistemi.Data.Abstract.BaseRepository;
using FaturaYonetimSistemi.Services.Abstract;
using FaturaYonetimSistemi.Shared.Dtos.KullaniciFaturaDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Services.Concrete
{
    public class KullaniciFaturaManager : IKullaniciFaturaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KullaniciFaturaManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ListKullaniciFaturaDto> GetAllKullaniciFatura(int kullaniciId)
        {
            return _unitOfWork.KullaniciFatura.GetAllKullaniciFatura(kullaniciId);
        }
    }
}
